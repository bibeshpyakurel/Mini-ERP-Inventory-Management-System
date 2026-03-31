import { Alert, Box, CircularProgress, Grid, Paper, Stack, Typography } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { ApiClientError } from "../api/client";
import { PageSection } from "../components/PageSection";
import { useAuth } from "../features/auth/AuthContext";
import { reportsApi } from "../features/reports/api";

export function DashboardPage() {
  const { accessToken } = useAuth();

  const stockSummaryQuery = useQuery({
    queryKey: ["dashboard-stock-summary"],
    queryFn: async () => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return reportsApi.getStockSummary(accessToken);
    },
    enabled: Boolean(accessToken),
  });

  const poSummaryQuery = useQuery({
    queryKey: ["dashboard-po-summary"],
    queryFn: async () => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return reportsApi.getPurchaseOrderSummary(accessToken);
    },
    enabled: Boolean(accessToken),
  });

  const recentTransactionsQuery = useQuery({
    queryKey: ["dashboard-recent-transactions"],
    queryFn: async () => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return reportsApi.getRecentTransactions(accessToken, 6);
    },
    enabled: Boolean(accessToken),
  });

  const statCards = stockSummaryQuery.data && poSummaryQuery.data
    ? [
        {
          label: "Total Items",
          value: String(stockSummaryQuery.data.totalTrackedItems),
          accent: `${stockSummaryQuery.data.totalQuantityOnHand} units on hand`,
        },
        {
          label: "Low-Stock Items",
          value: String(stockSummaryQuery.data.lowStockItemCount),
          accent: "Replenishment required",
        },
        {
          label: "Open POs",
          value: String(
            poSummaryQuery.data.draftCount +
              poSummaryQuery.data.approvedCount +
              poSummaryQuery.data.partiallyReceivedCount,
          ),
          accent: `$${poSummaryQuery.data.totalOpenPurchaseOrderValue.toFixed(2)} open value`,
        },
        {
          label: "Recent Transactions",
          value: String(recentTransactionsQuery.data?.length ?? 0),
          accent: "Latest warehouse activity",
        },
      ]
    : [];

  return (
    <Stack spacing={3}>
      <PageSection
        eyebrow="Overview"
        title="Operations dashboard"
        description="Real-time summary of inventory, purchasing, and recent warehouse activity."
      >
        {stockSummaryQuery.isError || poSummaryQuery.isError ? (
          <Alert severity="error">
            {stockSummaryQuery.error instanceof ApiClientError
              ? stockSummaryQuery.error.message
              : poSummaryQuery.error instanceof ApiClientError
                ? poSummaryQuery.error.message
                : "Unable to load dashboard KPIs right now."}
          </Alert>
        ) : stockSummaryQuery.isLoading || poSummaryQuery.isLoading ? (
          <Box sx={{ display: "grid", placeItems: "center", py: 8 }}>
            <Stack spacing={1.5} alignItems="center">
              <CircularProgress />
              <Typography color="text.secondary">Loading dashboard KPIs...</Typography>
            </Stack>
          </Box>
        ) : (
          <Grid container spacing={2}>
            {statCards.map((card) => (
              <Grid key={card.label} size={{ xs: 12, md: 6, xl: 3 }}>
                <Paper
                  elevation={0}
                  sx={{
                    p: 3,
                    borderRadius: 4,
                    background:
                      "linear-gradient(180deg, rgba(15,82,87,0.06) 0%, rgba(255,255,255,0.9) 100%)",
                  }}
                >
                  <Typography variant="body2" color="text.secondary">
                    {card.label}
                  </Typography>
                  <Typography variant="h4" sx={{ mt: 1 }}>
                    {card.value}
                  </Typography>
                  <Typography variant="body2" sx={{ mt: 1.25, color: "primary.main" }}>
                    {card.accent}
                  </Typography>
                </Paper>
              </Grid>
            ))}
          </Grid>
        )}
      </PageSection>

      <PageSection
        eyebrow="Activity"
        title="Recent operations"
        description="Latest inventory movements coming from the recent-transactions report API."
      >
        {recentTransactionsQuery.isError ? (
          <Alert severity="error">
            {recentTransactionsQuery.error instanceof ApiClientError
              ? recentTransactionsQuery.error.message
              : "Unable to load recent transactions right now."}
          </Alert>
        ) : recentTransactionsQuery.isLoading ? (
          <Box sx={{ display: "grid", placeItems: "center", py: 6 }}>
            <Stack spacing={1.5} alignItems="center">
              <CircularProgress />
              <Typography color="text.secondary">Loading recent operations...</Typography>
            </Stack>
          </Box>
        ) : (recentTransactionsQuery.data?.length ?? 0) === 0 ? (
          <Alert severity="info">
            No recent warehouse activity has been recorded yet.
          </Alert>
        ) : (
          <Stack spacing={1.25}>
            {(recentTransactionsQuery.data ?? []).map((entry) => (
              <Paper
                key={entry.transactionId}
                elevation={0}
                sx={{
                  p: 2,
                  borderRadius: 3,
                  border: "1px solid rgba(15,82,87,0.12)",
                }}
              >
                <Typography variant="body2" sx={{ fontWeight: 600 }}>
                  {entry.itemSku} - {entry.itemName}
                </Typography>
                <Typography variant="body2" color="text.secondary" sx={{ mt: 0.5 }}>
                  {entry.transactionType} • {entry.quantityChange > 0 ? "+" : ""}
                  {entry.quantityChange} • {entry.referenceType}
                </Typography>
                <Typography variant="caption" color="text.secondary">
                  {new Date(entry.performedAt).toLocaleString()}
                </Typography>
              </Paper>
            ))}
          </Stack>
        )}
      </PageSection>
    </Stack>
  );
}
