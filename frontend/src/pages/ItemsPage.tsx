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
import { AppDataTable, type TableColumn } from "../components/AppDataTable";
import { PageSection } from "../components/PageSection";
import { useAuth } from "../features/auth/AuthContext";
import { categoriesApi, type CategoryOption } from "../features/items/categoriesApi";
import { ItemFormDialog } from "../features/items/ItemFormDialog";
import { itemsApi } from "../features/items/api";
import type { Item, ItemFilters, UpsertItemInput } from "../features/items/types";
import { ApiClientError } from "../api/client";
import { useDemo } from "../features/demo/DemoContext";

const ALL_STATUSES = "all";
const ALL_CATEGORIES = "all";

export function ItemsPage() {
  const queryClient = useQueryClient();
  const { accessToken, primaryRole } = useAuth();
  const { notifyWrite } = useDemo();
  const [search, setSearch] = useState("");
  const [statusFilter, setStatusFilter] = useState<string>(ALL_STATUSES);
  const [categoryFilter, setCategoryFilter] = useState<string>(ALL_CATEGORIES);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [selectedItem, setSelectedItem] = useState<Item | null>(null);
  const [formError, setFormError] = useState<string | null>(null);

  const filters = useMemo<ItemFilters>(
    () => ({
      search: search.trim() || undefined,
      categoryId: categoryFilter !== ALL_CATEGORIES ? categoryFilter : undefined,
      isActive:
        statusFilter === ALL_STATUSES
          ? undefined
          : statusFilter === "active",
    }),
    [categoryFilter, search, statusFilter],
  );

  const categoriesQuery = useQuery({
    queryKey: ["categories"],
    queryFn: async () => {
      if (!accessToken) return [] as CategoryOption[];
      return categoriesApi.list(accessToken);
    },
    enabled: Boolean(accessToken),
  });

  const itemsQuery = useQuery({
    queryKey: ["items", filters],
    queryFn: async () => {
      if (!accessToken) return [] as Item[];
      return itemsApi.list(accessToken, filters);
    },
    enabled: Boolean(accessToken),
  });

  const createItemMutation = useMutation({
    mutationFn: async (input: UpsertItemInput) => {
      if (!accessToken) throw new Error("Missing access token.");
      return itemsApi.create(accessToken, input);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["items"] });
      setDialogOpen(false);
      setSelectedItem(null);
      setFormError(null);
      notifyWrite();
    },
  });

  const updateItemMutation = useMutation({
    mutationFn: async ({ itemId, input }: { itemId: string; input: UpsertItemInput }) => {
      if (!accessToken) throw new Error("Missing access token.");
      return itemsApi.update(accessToken, itemId, input);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["items"] });
      setDialogOpen(false);
      setSelectedItem(null);
      setFormError(null);
      notifyWrite();
    },
  });

  const toggleStatusMutation = useMutation({
    mutationFn: async (item: Item) => {
      if (!accessToken) throw new Error("Missing access token.");
      return itemsApi.setStatus(accessToken, item.id, {
        isActive: !item.isActive,
      });
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["items"] });
      notifyWrite();
    },
  });

  const canManageItems =
    primaryRole === "Admin" || primaryRole === "InventoryManager";

  const openCreateDialog = () => {
    setSelectedItem(null);
    setFormError(null);
    setDialogOpen(true);
  };

  const openEditDialog = (item: Item) => {
    setSelectedItem(item);
    setFormError(null);
    setDialogOpen(true);
  };

  const handleSubmit = async (values: UpsertItemInput) => {
    setFormError(null);

    try {
      if (selectedItem) {
        await updateItemMutation.mutateAsync({
          itemId: selectedItem.id,
          input: values,
        });
        return;
      }

      await createItemMutation.mutateAsync(values);
    } catch (error) {
      if (error instanceof ApiClientError) {
        setFormError(error.message);
        return;
      }

      setFormError("Unable to save the item right now.");
    }
  };

  const categories = categoriesQuery.data ?? [];

  const columns: TableColumn<Item>[] = [
    { key: "sku", header: "SKU", render: (row) => row.sku },
    { key: "name", header: "Item", render: (row) => row.name },
    { key: "category", header: "Category", render: (row) => row.categoryName },
    {
      key: "unit",
      header: "Unit",
      render: (row) => row.unit,
    },
    {
      key: "standardCost",
      header: "Cost",
      align: "right",
      render: (row) => `$${row.standardCost.toFixed(2)}`,
    },
    {
      key: "reorderLevel",
      header: "Reorder Level",
      align: "right",
      render: (row) => row.reorderLevel,
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

  if (canManageItems) {
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
        eyebrow="Item Master"
        title="Items"
        description="Search, create, edit, and manage item records tied to category assignment, reorder levels, and active status."
        actions={
          canManageItems ? (
            <Stack direction="row" spacing={1}>
              <Button
                variant="outlined"
                startIcon={<RefreshRoundedIcon />}
                onClick={() => itemsQuery.refetch()}
                disabled={itemsQuery.isFetching}
              >
                Refresh
              </Button>
              <Button variant="contained" startIcon={<AddRoundedIcon />} onClick={openCreateDialog}>
                New item
              </Button>
            </Stack>
          ) : undefined
        }
      >
        <Stack spacing={2.5}>
          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <TextField
              label="Search items"
              value={search}
              onChange={(event) => setSearch(event.target.value)}
              placeholder="Search by SKU, name, or description"
              fullWidth
            />
            <TextField
              select
              label="Category"
              value={categoryFilter}
              onChange={(event) => setCategoryFilter(event.target.value)}
              sx={{ minWidth: 200 }}
            >
              <MenuItem value={ALL_CATEGORIES}>All categories</MenuItem>
              {categories.map((category) => (
                <MenuItem key={category.id} value={category.id}>
                  {category.name}
                </MenuItem>
              ))}
            </TextField>
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

          {itemsQuery.isLoading ? (
            <Box sx={{ display: "grid", placeItems: "center", py: 8 }}>
              <Stack spacing={1.5} alignItems="center">
                <CircularProgress />
                <Typography color="text.secondary">Loading items...</Typography>
              </Stack>
            </Box>
          ) : itemsQuery.isError ? (
            <Alert severity="error">
              {itemsQuery.error instanceof ApiClientError
                ? itemsQuery.error.message
                : "Unable to load items right now."}
            </Alert>
          ) : (
            <AppDataTable
              columns={columns}
              rows={itemsQuery.data ?? []}
              emptyMessage="No items match the current filters."
            />
          )}

          {toggleStatusMutation.isError ? (
            <Alert severity="error">
              {toggleStatusMutation.error instanceof ApiClientError
                ? toggleStatusMutation.error.message
                : "Unable to update item status right now."}
            </Alert>
          ) : null}
        </Stack>
      </PageSection>

      <ItemFormDialog
        open={dialogOpen}
        item={selectedItem}
        isSubmitting={createItemMutation.isPending || updateItemMutation.isPending}
        errorMessage={formError}
        categories={categories}
        onClose={() => {
          setDialogOpen(false);
          setSelectedItem(null);
          setFormError(null);
        }}
        onSubmit={handleSubmit}
      />
    </Stack>
  );
}
