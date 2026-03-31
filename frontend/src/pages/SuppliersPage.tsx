import AddRoundedIcon from "@mui/icons-material/AddRounded";
import EditRoundedIcon from "@mui/icons-material/EditRounded";
import RefreshRoundedIcon from "@mui/icons-material/RefreshRounded";
import {
  Alert,
  Box,
  Button,
  Chip,
  CircularProgress,
  IconButton,
  MenuItem,
  Stack,
  TextField,
  Typography,
} from "@mui/material";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { useMemo, useState } from "react";
import { ApiClientError } from "../api/client";
import { AppDataTable, type TableColumn } from "../components/AppDataTable";
import { PageSection } from "../components/PageSection";
import { useAuth } from "../features/auth/AuthContext";
import { suppliersApi } from "../features/suppliers/api";
import { SupplierFormDialog } from "../features/suppliers/SupplierFormDialog";
import type { Supplier, SupplierFilters, UpsertSupplierInput } from "../features/suppliers/types";

const ALL_STATUSES = "all";

export function SuppliersPage() {
  const queryClient = useQueryClient();
  const { accessToken, primaryRole } = useAuth();
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState<string>(ALL_STATUSES);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [selectedSupplier, setSelectedSupplier] = useState<Supplier | null>(null);
  const [formError, setFormError] = useState<string | null>(null);

  const filters = useMemo<SupplierFilters>(
    () => ({
      search: search.trim() || undefined,
      isActive:
        statusFilter === ALL_STATUSES
          ? undefined
          : statusFilter === "active",
    }),
    [search, statusFilter],
  );

  const suppliersQuery = useQuery({
    queryKey: ["suppliers", filters],
    queryFn: async () => {
      if (!accessToken) {
        return [] as Supplier[];
      }

      return suppliersApi.list(accessToken, filters);
    },
    enabled: Boolean(accessToken),
  });

  const createSupplierMutation = useMutation({
    mutationFn: async (input: UpsertSupplierInput) => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return suppliersApi.create(accessToken, input);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["suppliers"] });
      setDialogOpen(false);
      setSelectedSupplier(null);
      setFormError(null);
    },
  });

  const updateSupplierMutation = useMutation({
    mutationFn: async ({ supplierId, input }: { supplierId: string; input: UpsertSupplierInput }) => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return suppliersApi.update(accessToken, supplierId, input);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["suppliers"] });
      setDialogOpen(false);
      setSelectedSupplier(null);
      setFormError(null);
    },
  });

  const toggleStatusMutation = useMutation({
    mutationFn: async (supplier: Supplier) => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return suppliersApi.setStatus(accessToken, supplier.id, !supplier.isActive);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["suppliers"] });
    },
  });

  const canManageSuppliers =
    primaryRole === "Admin" || primaryRole === "InventoryManager";

  const openCreateDialog = () => {
    setSelectedSupplier(null);
    setFormError(null);
    setDialogOpen(true);
  };

  const openEditDialog = (supplier: Supplier) => {
    setSelectedSupplier(supplier);
    setFormError(null);
    setDialogOpen(true);
  };

  const handleSubmit = async (values: UpsertSupplierInput) => {
    setFormError(null);

    try {
      if (selectedSupplier) {
        await updateSupplierMutation.mutateAsync({
          supplierId: selectedSupplier.id,
          input: values,
        });
        return;
      }

      await createSupplierMutation.mutateAsync(values);
    } catch (error) {
      if (error instanceof ApiClientError) {
        setFormError(error.message);
        return;
      }

      setFormError("Unable to save the supplier right now.");
    }
  };

  const columns: TableColumn<Supplier>[] = [
    { key: "name", header: "Supplier", render: (row) => row.name },
    { key: "contact", header: "Contact", render: (row) => row.contactName },
    { key: "email", header: "Email", render: (row) => row.email },
    { key: "phone", header: "Phone", render: (row) => row.phone },
    {
      key: "mappedItems",
      header: "Mapped Items",
      align: "right",
      render: (row) => row.items.length,
    },
    {
      key: "isActive",
      header: "Status",
      render: (row) => (
        <Chip
          label={row.isActive ? "Active" : "Inactive"}
          color={row.isActive ? "success" : "default"}
          size="small"
        />
      ),
    },
  ];

  if (canManageSuppliers) {
    columns.push({
      key: "actions",
      header: "Actions",
      align: "right",
      render: (row) => (
        <Stack direction="row" spacing={0.5} justifyContent="flex-end">
          <IconButton onClick={() => openEditDialog(row)} aria-label={`Edit ${row.name}`}>
            <EditRoundedIcon fontSize="small" />
          </IconButton>
          <Button
            size="small"
            variant="text"
            onClick={() => toggleStatusMutation.mutate(row)}
            disabled={toggleStatusMutation.isPending}
          >
            {row.isActive ? "Deactivate" : "Activate"}
          </Button>
        </Stack>
      ),
    });
  }

  return (
    <Stack spacing={3}>
      <PageSection
        eyebrow="Procurement"
        title="Suppliers"
        description="Maintain supplier records, contacts, sourcing notes, and optional supplier-item mappings."
        actions={
          canManageSuppliers ? (
            <Stack direction="row" spacing={1}>
              <Button
                variant="outlined"
                startIcon={<RefreshRoundedIcon />}
                onClick={() => suppliersQuery.refetch()}
                disabled={suppliersQuery.isFetching}
              >
                Refresh
              </Button>
              <Button variant="contained" startIcon={<AddRoundedIcon />} onClick={openCreateDialog}>
                New supplier
              </Button>
            </Stack>
          ) : undefined
        }
      >
        <Stack spacing={2.5}>
          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <TextField
              label="Search suppliers"
              value={search}
              onChange={(event) => setSearch(event.target.value)}
              placeholder="Search by name, contact, or email"
              fullWidth
            />
            <TextField
              select
              label="Status"
              value={statusFilter}
              onChange={(event) => setStatusFilter(event.target.value)}
              sx={{ minWidth: 180 }}
            >
              <MenuItem value={ALL_STATUSES}>All statuses</MenuItem>
              <MenuItem value="active">Active</MenuItem>
              <MenuItem value="inactive">Inactive</MenuItem>
            </TextField>
          </Stack>

          {suppliersQuery.isLoading ? (
            <Box sx={{ display: "grid", placeItems: "center", py: 8 }}>
              <Stack spacing={1.5} alignItems="center">
                <CircularProgress />
                <Typography color="text.secondary">Loading suppliers...</Typography>
              </Stack>
            </Box>
          ) : suppliersQuery.isError ? (
            <Alert severity="error">
              {suppliersQuery.error instanceof ApiClientError
                ? suppliersQuery.error.message
                : "Unable to load suppliers right now."}
            </Alert>
          ) : (
            <AppDataTable
              columns={columns}
              rows={suppliersQuery.data ?? []}
              emptyMessage="No suppliers match the current filters."
            />
          )}

          {toggleStatusMutation.isError ? (
            <Alert severity="error">
              {toggleStatusMutation.error instanceof ApiClientError
                ? toggleStatusMutation.error.message
                : "Unable to update supplier status right now."}
            </Alert>
          ) : null}
        </Stack>
      </PageSection>

      <SupplierFormDialog
        open={dialogOpen}
        supplier={selectedSupplier}
        isSubmitting={createSupplierMutation.isPending || updateSupplierMutation.isPending}
        errorMessage={formError}
        onClose={() => {
          setDialogOpen(false);
          setSelectedSupplier(null);
          setFormError(null);
        }}
        onSubmit={handleSubmit}
      />
    </Stack>
  );
}
