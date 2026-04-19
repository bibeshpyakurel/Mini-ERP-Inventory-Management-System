import AddRoundedIcon from "@mui/icons-material/AddRounded";
import OpenInNewRoundedIcon from "@mui/icons-material/OpenInNewRounded";
import {
  Alert,
  Box,
  Button,
  Chip,
  CircularProgress,
  MenuItem,
  Stack,
  TextField,
  Typography,
} from "@mui/material";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { useMemo, useState } from "react";
import { Link as RouterLink } from "react-router-dom";
import { ApiClientError } from "../api/client";
import { useDemo } from "../features/demo/DemoContext";
import { AppDataTable, type TableColumn } from "../components/AppDataTable";
import { PageSection } from "../components/PageSection";
import { useAuth } from "../features/auth/AuthContext";
import { purchaseOrdersApi } from "../features/purchaseOrders/api";
import { suppliersApi } from "../features/suppliers/api";
import { itemsApi } from "../features/items/api";
import { purchaseOrderStatusOptions } from "../features/purchaseOrders/constants";
import { PurchaseOrderFormDialog } from "../features/purchaseOrders/PurchaseOrderFormDialog";
import type { CreatePurchaseOrderInput, PurchaseOrder, PurchaseOrderFilters } from "../features/purchaseOrders/types";
import type { Supplier } from "../features/suppliers/types";
import type { Item } from "../features/items/types";

const ALL_SUPPLIERS = "all";
const ALL_STATUSES = "all";

const statusChipColor = (status: string) => {
  switch (status) {
    case "Approved":
      return "success";
    case "PartiallyReceived":
      return "warning";
    case "Completed":
      return "info";
    case "Cancelled":
      return "default";
    default:
      return "default";
  }
};

export function PurchaseOrdersPage() {
  const queryClient = useQueryClient();
  const { accessToken, primaryRole } = useAuth();
  const { notifyWrite } = useDemo();
  const [supplierFilter, setSupplierFilter] = useState(ALL_SUPPLIERS);
  const [statusFilter, setStatusFilter] = useState(ALL_STATUSES);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [formError, setFormError] = useState<string | null>(null);

  const filters = useMemo<PurchaseOrderFilters>(
    () => ({
      supplierId: supplierFilter !== ALL_SUPPLIERS ? supplierFilter : undefined,
      status: statusFilter !== ALL_STATUSES ? statusFilter : undefined,
    }),
    [statusFilter, supplierFilter],
  );

  const purchaseOrdersQuery = useQuery({
    queryKey: ["purchase-orders", filters],
    queryFn: async () => {
      if (!accessToken) return [] as PurchaseOrder[];
      return purchaseOrdersApi.list(accessToken, filters);
    },
    enabled: Boolean(accessToken),
  });

  const suppliersQuery = useQuery({
    queryKey: ["suppliers-all"],
    queryFn: async () => {
      if (!accessToken) return [] as Supplier[];
      return suppliersApi.list(accessToken, { isActive: true });
    },
    enabled: Boolean(accessToken),
  });

  const itemsQuery = useQuery({
    queryKey: ["items-all"],
    queryFn: async () => {
      if (!accessToken) return [] as Item[];
      return itemsApi.list(accessToken, { isActive: true });
    },
    enabled: Boolean(accessToken),
  });

  const createPurchaseOrderMutation = useMutation({
    mutationFn: async (input: CreatePurchaseOrderInput) => {
      if (!accessToken) throw new Error("Missing access token.");
      return purchaseOrdersApi.create(accessToken, input);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["purchase-orders"] });
      setDialogOpen(false);
      setFormError(null);
      notifyWrite();
    },
  });

  const canManagePurchaseOrders =
    primaryRole === "Admin" || primaryRole === "InventoryManager";

  const handleCreate = async (values: CreatePurchaseOrderInput) => {
    setFormError(null);
    try {
      await createPurchaseOrderMutation.mutateAsync(values);
    } catch (error) {
      if (error instanceof ApiClientError) {
        setFormError(error.message);
        return;
      }
      setFormError("Unable to create the purchase order right now.");
    }
  };

  const columns: TableColumn<PurchaseOrder>[] = [
    {
      key: "poNumber",
      header: "PO Number",
      render: (row) => row.poNumber,
    },
    {
      key: "supplier",
      header: "Supplier",
      render: (row) => row.supplierName,
    },
    {
      key: "status",
      header: "Status",
      render: (row) => (
        <Chip label={row.status} size="small" color={statusChipColor(row.status)} />
      ),
    },
    {
      key: "orderDate",
      header: "Order Date",
      render: (row) => new Date(row.orderDate).toLocaleDateString(),
    },
    {
      key: "totalAmount",
      header: "Total",
      align: "right",
      render: (row) => `$${row.totalAmount.toFixed(2)}`,
    },
    {
      key: "actions",
      header: "Actions",
      align: "right",
      render: (row) => (
        <Button
          component={RouterLink}
          to={`/purchase-orders/${row.id}`}
          size="small"
          endIcon={<OpenInNewRoundedIcon />}
        >
          Details
        </Button>
      ),
    },
  ];

  const suppliers = suppliersQuery.data ?? [];

  return (
    <Stack spacing={3}>
      <PageSection
        eyebrow="Purchasing"
        title="Purchase orders"
        description="Draft, review, approve, and receive vendor orders with line-level visibility."
        actions={
          canManagePurchaseOrders ? (
            <Button variant="contained" startIcon={<AddRoundedIcon />} onClick={() => setDialogOpen(true)}>
              New purchase order
            </Button>
          ) : undefined
        }
      >
        <Stack spacing={2.5}>
          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <TextField
              select
              label="Supplier"
              value={supplierFilter}
              onChange={(event) => setSupplierFilter(event.target.value)}
              sx={{ minWidth: 260 }}
            >
              <MenuItem value={ALL_SUPPLIERS}>All suppliers</MenuItem>
              {suppliers.map((supplier) => (
                <MenuItem key={supplier.id} value={supplier.id}>
                  {supplier.name}
                </MenuItem>
              ))}
            </TextField>

            <TextField
              select
              label="Status"
              value={statusFilter}
              onChange={(event) => setStatusFilter(event.target.value)}
              sx={{ minWidth: 220 }}
            >
              <MenuItem value={ALL_STATUSES}>All statuses</MenuItem>
              {purchaseOrderStatusOptions.map((status) => (
                <MenuItem key={status} value={status}>
                  {status}
                </MenuItem>
              ))}
            </TextField>
          </Stack>

          {purchaseOrdersQuery.isLoading ? (
            <Box sx={{ display: "grid", placeItems: "center", py: 8 }}>
              <Stack spacing={1.5} alignItems="center">
                <CircularProgress />
                <Typography color="text.secondary">Loading purchase orders...</Typography>
              </Stack>
            </Box>
          ) : purchaseOrdersQuery.isError ? (
            <Alert severity="error">
              {purchaseOrdersQuery.error instanceof ApiClientError
                ? purchaseOrdersQuery.error.message
                : "Unable to load purchase orders right now."}
            </Alert>
          ) : (
            <AppDataTable
              columns={columns}
              rows={purchaseOrdersQuery.data ?? []}
              emptyMessage="No purchase orders match the current filters."
            />
          )}
        </Stack>
      </PageSection>

      <PurchaseOrderFormDialog
        open={dialogOpen}
        isSubmitting={createPurchaseOrderMutation.isPending}
        errorMessage={formError}
        suppliers={suppliers}
        items={itemsQuery.data ?? []}
        onClose={() => {
          setDialogOpen(false);
          setFormError(null);
        }}
        onSubmit={handleCreate}
      />
    </Stack>
  );
}
