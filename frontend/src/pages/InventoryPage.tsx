import DownloadRoundedIcon from "@mui/icons-material/DownloadRounded";
import EditNoteRoundedIcon from "@mui/icons-material/EditNoteRounded";
import OutboundRoundedIcon from "@mui/icons-material/OutboundRounded";
import {
  Alert,
  Box,
  Button,
  Chip,
  CircularProgress,
  MenuItem,
  Stack,
  Tab,
  Tabs,
  TextField,
  Typography,
} from "@mui/material";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { useMemo, useState } from "react";
import { ApiClientError } from "../api/client";
import { AppDataTable, type TableColumn } from "../components/AppDataTable";
import { PageSection } from "../components/PageSection";
import { useAuth } from "../features/auth/AuthContext";
import { inventoryApi } from "../features/inventory/api";
import { AdjustStockDialog } from "../features/inventory/AdjustStockDialog";
import {
  inventoryItemOptions,
  inventoryTransactionTypes,
  warehouseOptions,
} from "../features/inventory/constants";
import { IssueStockDialog } from "../features/inventory/IssueStockDialog";
import type {
  AdjustStockInput,
  InventoryBalance,
  InventoryBalanceFilters,
  InventoryTransaction,
  InventoryTransactionFilters,
  IssueStockInput,
  LowStockItem,
} from "../features/inventory/types";

type InventoryView = "balances" | "transactions";

const ALL_ITEMS = "all";
const ALL_WAREHOUSES = "all";
const ALL_TRANSACTION_TYPES = "all";

const downloadCsv = (filename: string, rows: string[][]) => {
  const csv = rows
    .map((row) =>
      row
        .map((value) => `"${String(value).split('"').join('""')}"`)
        .join(","),
    )
    .join("\n");

  const blob = new Blob([csv], { type: "text/csv;charset=utf-8;" });
  const url = URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = filename;
  link.click();
  URL.revokeObjectURL(url);
};

export function InventoryPage() {
  const queryClient = useQueryClient();
  const { accessToken, primaryRole } = useAuth();
  const [view, setView] = useState<InventoryView>("balances");
  const [itemFilter, setItemFilter] = useState(ALL_ITEMS);
  const [warehouseFilter, setWarehouseFilter] = useState(ALL_WAREHOUSES);
  const [transactionTypeFilter, setTransactionTypeFilter] = useState(ALL_TRANSACTION_TYPES);
  const [fromDate, setFromDate] = useState("");
  const [toDate, setToDate] = useState("");
  const [selectedBalance, setSelectedBalance] = useState<InventoryBalance | null>(null);
  const [issueOpen, setIssueOpen] = useState(false);
  const [adjustOpen, setAdjustOpen] = useState(false);
  const [issueError, setIssueError] = useState<string | null>(null);
  const [adjustError, setAdjustError] = useState<string | null>(null);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);

  const balanceFilters = useMemo<InventoryBalanceFilters>(
    () => ({
      itemId: itemFilter !== ALL_ITEMS ? itemFilter : undefined,
      warehouseId: warehouseFilter !== ALL_WAREHOUSES ? warehouseFilter : undefined,
    }),
    [itemFilter, warehouseFilter],
  );

  const transactionFilters = useMemo<InventoryTransactionFilters>(
    () => ({
      itemId: itemFilter !== ALL_ITEMS ? itemFilter : undefined,
      warehouseId: warehouseFilter !== ALL_WAREHOUSES ? warehouseFilter : undefined,
      fromDateUtc: fromDate ? new Date(`${fromDate}T00:00:00Z`).toISOString() : undefined,
      toDateUtc: toDate ? new Date(`${toDate}T23:59:59Z`).toISOString() : undefined,
      transactionType:
        transactionTypeFilter !== ALL_TRANSACTION_TYPES
          ? transactionTypeFilter
          : undefined,
    }),
    [fromDate, itemFilter, toDate, transactionTypeFilter, warehouseFilter],
  );

  const balancesQuery = useQuery({
    queryKey: ["inventory-balances", balanceFilters],
    queryFn: async () => {
      if (!accessToken) {
        return [] as InventoryBalance[];
      }

      return inventoryApi.getBalances(accessToken, balanceFilters);
    },
    enabled: Boolean(accessToken),
  });

  const transactionsQuery = useQuery({
    queryKey: ["inventory-transactions", transactionFilters],
    queryFn: async () => {
      if (!accessToken) {
        return [] as InventoryTransaction[];
      }

      return inventoryApi.getTransactions(accessToken, transactionFilters);
    },
    enabled: Boolean(accessToken),
  });

  const lowStockQuery = useQuery({
    queryKey: ["inventory-low-stock"],
    queryFn: async () => {
      if (!accessToken) {
        return [] as LowStockItem[];
      }

      return inventoryApi.getLowStock(accessToken);
    },
    enabled: Boolean(accessToken),
  });

  const lowStockMap = useMemo(() => {
    const map = new Map<string, LowStockItem>();
    (lowStockQuery.data ?? []).forEach((item) => {
      map.set(item.itemId, item);
    });
    return map;
  }, [lowStockQuery.data]);

  const issueMutation = useMutation({
    mutationFn: async (input: IssueStockInput) => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return inventoryApi.issueStock(accessToken, input);
    },
    onSuccess: async () => {
      setIssueOpen(false);
      setIssueError(null);
      setSuccessMessage("Stock issued successfully.");
      await queryClient.invalidateQueries({ queryKey: ["inventory-balances"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-transactions"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-low-stock"] });
    },
  });

  const adjustMutation = useMutation({
    mutationFn: async (input: AdjustStockInput) => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return inventoryApi.adjustStock(accessToken, input);
    },
    onSuccess: async () => {
      setAdjustOpen(false);
      setAdjustError(null);
      setSuccessMessage("Stock adjustment applied successfully.");
      await queryClient.invalidateQueries({ queryKey: ["inventory-balances"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-transactions"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-low-stock"] });
    },
  });

  const canIssue =
    primaryRole === "Admin" ||
    primaryRole === "InventoryManager" ||
    primaryRole === "WarehouseStaff";
  const canAdjust = primaryRole === "Admin" || primaryRole === "InventoryManager";

  const balanceColumns: TableColumn<InventoryBalance>[] = [
    {
      key: "item",
      header: "Item",
      render: (row) => (
        <Stack spacing={0.5}>
          <Typography variant="body2" sx={{ fontWeight: 600 }}>
            {row.itemName}
          </Typography>
          <Typography variant="caption" color="text.secondary">
            {row.itemSku}
          </Typography>
        </Stack>
      ),
    },
    {
      key: "warehouse",
      header: "Warehouse",
      render: (row) => `${row.warehouseCode} - ${row.locationCode}`,
    },
    {
      key: "quantityOnHand",
      header: "On Hand",
      align: "right",
      render: (row) => row.quantityOnHand,
    },
    {
      key: "quantityReserved",
      header: "Reserved",
      align: "right",
      render: (row) => row.quantityReserved,
    },
    {
      key: "quantityAvailable",
      header: "Available",
      align: "right",
      render: (row) => row.quantityAvailable,
    },
    {
      key: "status",
      header: "Reorder Status",
      render: (row) => {
        const lowStock = lowStockMap.get(row.itemId);
        return lowStock ? (
          <Chip
            label={`Low stock: short ${lowStock.shortfall}`}
            color="warning"
            size="small"
          />
        ) : (
          <Chip label="Healthy" color="success" size="small" />
        );
      },
    },
  ];

  if (canIssue || canAdjust) {
    balanceColumns.push({
      key: "actions",
      header: "Actions",
      align: "right",
      render: (row) => (
        <Stack direction="row" spacing={0.75} justifyContent="flex-end">
          {canIssue ? (
            <Button
              size="small"
              variant="text"
              startIcon={<OutboundRoundedIcon />}
              onClick={() => {
                setSelectedBalance(row);
                setIssueError(null);
                setSuccessMessage(null);
                setIssueOpen(true);
              }}
            >
              Issue
            </Button>
          ) : null}
          {canAdjust ? (
            <Button
              size="small"
              variant="text"
              startIcon={<EditNoteRoundedIcon />}
              onClick={() => {
                setSelectedBalance(row);
                setAdjustError(null);
                setSuccessMessage(null);
                setAdjustOpen(true);
              }}
            >
              Adjust
            </Button>
          ) : null}
        </Stack>
      ),
    });
  }

  const transactionColumns: TableColumn<InventoryTransaction>[] = [
    {
      key: "performedAt",
      header: "When",
      render: (row) => new Date(row.performedAt).toLocaleString(),
    },
    {
      key: "item",
      header: "Item",
      render: (row) => (
        <Stack spacing={0.5}>
          <Typography variant="body2" sx={{ fontWeight: 600 }}>
            {row.itemName}
          </Typography>
          <Typography variant="caption" color="text.secondary">
            {row.itemSku}
          </Typography>
        </Stack>
      ),
    },
    {
      key: "transactionType",
      header: "Type",
      render: (row) => (
        <Chip
          label={row.transactionType}
          size="small"
          color={row.quantityChange >= 0 ? "success" : "warning"}
        />
      ),
    },
    {
      key: "quantityChange",
      header: "Qty Change",
      align: "right",
      render: (row) => row.quantityChange,
    },
    {
      key: "balanceAfter",
      header: "Balance After",
      align: "right",
      render: (row) => row.balanceAfter,
    },
    {
      key: "referenceType",
      header: "Reference",
      render: (row) => row.referenceType,
    },
    {
      key: "reason",
      header: "Reason",
      render: (row) => row.reason ?? "Not provided",
    },
  ];

  const exportBalances = () => {
    const rows = [
      ["Item SKU", "Item Name", "Warehouse", "Location", "On Hand", "Reserved", "Available", "Reorder Status"],
      ...(balancesQuery.data ?? []).map((row) => [
        row.itemSku,
        row.itemName,
        row.warehouseCode,
        row.locationCode,
        String(row.quantityOnHand),
        String(row.quantityReserved),
        String(row.quantityAvailable),
        lowStockMap.has(row.itemId) ? "Low Stock" : "Healthy",
      ]),
    ];

    downloadCsv("inventory-balances.csv", rows);
  };

  const exportTransactions = () => {
    const rows = [
      ["Performed At", "Item SKU", "Item Name", "Type", "Quantity Change", "Balance After", "Reference Type", "Reason"],
      ...(transactionsQuery.data ?? []).map((row) => [
        new Date(row.performedAt).toISOString(),
        row.itemSku,
        row.itemName,
        row.transactionType,
        String(row.quantityChange),
        String(row.balanceAfter),
        row.referenceType,
        row.reason ?? "",
      ]),
    ];

    downloadCsv("inventory-transactions.csv", rows);
  };

  const currentQuery = view === "balances" ? balancesQuery : transactionsQuery;

  const handleIssue = async (input: IssueStockInput) => {
    setIssueError(null);
    setSuccessMessage(null);

    try {
      await issueMutation.mutateAsync(input);
    } catch (error) {
      if (error instanceof ApiClientError) {
        setIssueError(error.message);
        return;
      }

      setIssueError("Unable to issue stock right now.");
    }
  };

  const handleAdjust = async (input: AdjustStockInput) => {
    setAdjustError(null);
    setSuccessMessage(null);

    try {
      await adjustMutation.mutateAsync(input);
    } catch (error) {
      if (error instanceof ApiClientError) {
        setAdjustError(error.message);
        return;
      }

      setAdjustError("Unable to adjust stock right now.");
    }
  };

  return (
    <Stack spacing={3}>
      <PageSection
        eyebrow="Stock"
        title="Inventory operations"
        description="Monitor current balances and transaction history with filters for item, warehouse, date range, and transaction type."
        actions={
          <Button
            variant="outlined"
            startIcon={<DownloadRoundedIcon />}
            onClick={view === "balances" ? exportBalances : exportTransactions}
            disabled={currentQuery.isLoading || currentQuery.isError}
          >
            Export CSV
          </Button>
        }
      >
        <Stack spacing={2.5}>
          {successMessage ? <Alert severity="success">{successMessage}</Alert> : null}
          <Tabs
            value={view}
            onChange={(_, nextValue: InventoryView) => setView(nextValue)}
          >
            <Tab label="Balances" value="balances" />
            <Tab label="Transactions" value="transactions" />
          </Tabs>

          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <TextField
              select
              label="Item"
              value={itemFilter}
              onChange={(event) => setItemFilter(event.target.value)}
              sx={{ minWidth: 220 }}
            >
              <MenuItem value={ALL_ITEMS}>All items</MenuItem>
              {inventoryItemOptions.map((item) => (
                <MenuItem key={item.id} value={item.id}>
                  {item.sku} - {item.name}
                </MenuItem>
              ))}
            </TextField>

            <TextField
              select
              label="Warehouse"
              value={warehouseFilter}
              onChange={(event) => setWarehouseFilter(event.target.value)}
              sx={{ minWidth: 220 }}
            >
              <MenuItem value={ALL_WAREHOUSES}>All warehouses</MenuItem>
              {warehouseOptions.map((warehouse) => (
                <MenuItem key={warehouse.id} value={warehouse.id}>
                  {warehouse.name}
                </MenuItem>
              ))}
            </TextField>

            {view === "transactions" ? (
              <>
                <TextField
                  select
                  label="Transaction type"
                  value={transactionTypeFilter}
                  onChange={(event) => setTransactionTypeFilter(event.target.value)}
                  sx={{ minWidth: 220 }}
                >
                  <MenuItem value={ALL_TRANSACTION_TYPES}>All types</MenuItem>
                  {inventoryTransactionTypes.map((type) => (
                    <MenuItem key={type} value={type}>
                      {type}
                    </MenuItem>
                  ))}
                </TextField>

                <TextField
                  label="From date"
                  type="date"
                  value={fromDate}
                  onChange={(event) => setFromDate(event.target.value)}
                  InputLabelProps={{ shrink: true }}
                />
                <TextField
                  label="To date"
                  type="date"
                  value={toDate}
                  onChange={(event) => setToDate(event.target.value)}
                  InputLabelProps={{ shrink: true }}
                />
              </>
            ) : null}
          </Stack>

          {lowStockQuery.isSuccess && lowStockQuery.data.length > 0 ? (
            <Alert severity="warning">
              {lowStockQuery.data.length} item(s) are currently below reorder threshold.
            </Alert>
          ) : null}

          {currentQuery.isLoading ? (
            <Box sx={{ display: "grid", placeItems: "center", py: 8 }}>
              <Stack spacing={1.5} alignItems="center">
                <CircularProgress />
                <Typography color="text.secondary">
                  {view === "balances" ? "Loading balances..." : "Loading transaction history..."}
                </Typography>
              </Stack>
            </Box>
          ) : currentQuery.isError ? (
            <Alert severity="error">
              {currentQuery.error instanceof ApiClientError
                ? currentQuery.error.message
                : "Unable to load inventory data right now."}
            </Alert>
          ) : view === "balances" ? (
            <AppDataTable
              columns={balanceColumns}
              rows={balancesQuery.data ?? []}
              emptyMessage="No inventory balances match the current filters."
            />
          ) : (
            <AppDataTable
              columns={transactionColumns}
              rows={transactionsQuery.data ?? []}
              emptyMessage="No transactions match the current filters."
            />
          )}
        </Stack>
      </PageSection>

      <IssueStockDialog
        open={issueOpen}
        balance={selectedBalance}
        isSubmitting={issueMutation.isPending}
        errorMessage={issueError}
        onClose={() => {
          setIssueOpen(false);
          setIssueError(null);
        }}
        onSubmit={handleIssue}
      />

      <AdjustStockDialog
        open={adjustOpen}
        balance={selectedBalance}
        isSubmitting={adjustMutation.isPending}
        errorMessage={adjustError}
        onClose={() => {
          setAdjustOpen(false);
          setAdjustError(null);
        }}
        onSubmit={handleAdjust}
      />
    </Stack>
  );
}
