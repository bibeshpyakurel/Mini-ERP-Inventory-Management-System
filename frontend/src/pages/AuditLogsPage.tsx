import { Alert, Box, CircularProgress, Stack, Typography } from "@mui/material";
import { useQuery } from "@tanstack/react-query";
import { AppDataTable, type TableColumn } from "../components/AppDataTable";
import { PageSection } from "../components/PageSection";
import { ApiClientError } from "../api/client";
import { useAuth } from "../features/auth/AuthContext";
import { auditLogsApi } from "../features/auditLogs/api";
import type { AuditLogEntry } from "../features/auditLogs/types";

const columns: TableColumn<AuditLogEntry>[] = [
  {
    key: "performedAt",
    header: "When",
    render: (row) => new Date(row.performedAt).toLocaleString(),
  },
  { key: "action", header: "Action", render: (row) => row.action },
  { key: "entityName", header: "Entity", render: (row) => row.entityName },
  { key: "details", header: "Details", render: (row) => row.details },
];

export function AuditLogsPage() {
  const { accessToken, primaryRole } = useAuth();

  const auditLogsQuery = useQuery({
    queryKey: ["audit-logs"],
    queryFn: async () => {
      if (!accessToken) {
        return [] as AuditLogEntry[];
      }

      return auditLogsApi.list(accessToken);
    },
    enabled: Boolean(accessToken),
  });

  return (
    <Stack spacing={3}>
      <PageSection
        eyebrow="Governance"
        title="Audit logs"
        description="Read-only admin view for key ERP actions such as login, purchasing, and stock changes."
      >
        {primaryRole !== "Admin" ? (
          <Alert severity="warning">
            Audit logs are only available to administrators.
          </Alert>
        ) : auditLogsQuery.isLoading ? (
          <Box sx={{ display: "grid", placeItems: "center", py: 6 }}>
            <Stack spacing={1.5} alignItems="center">
              <CircularProgress />
              <Typography color="text.secondary">Loading audit history...</Typography>
            </Stack>
          </Box>
        ) : auditLogsQuery.isError ? (
          <Alert severity="error">
            {auditLogsQuery.error instanceof ApiClientError
              ? auditLogsQuery.error.message
              : "Unable to load audit logs right now."}
          </Alert>
        ) : (
          <AppDataTable
            columns={columns}
            rows={auditLogsQuery.data ?? []}
            emptyMessage="No audit log entries available."
          />
        )}
      </PageSection>
    </Stack>
  );
}
