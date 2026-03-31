import {
  Alert,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  MenuItem,
  Stack,
} from "@mui/material";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { AppFormTextField } from "../../components/AppFormTextField";
import type { Item, UpsertItemInput } from "./types";
import { itemCategories } from "./constants";
import { useEffect } from "react";

const itemFormSchema = z.object({
  categoryId: z.string().uuid("Select a valid category."),
  sku: z.string().trim().min(1, "SKU is required.").max(64, "SKU must be 64 characters or less."),
  name: z.string().trim().min(1, "Name is required.").max(200, "Name must be 200 characters or less."),
  description: z.string().max(1000, "Description must be 1000 characters or less.").optional().or(z.literal("")),
  unit: z.string().trim().min(1, "Unit is required.").max(32, "Unit must be 32 characters or less."),
  reorderLevel: z.coerce.number().int().min(0, "Reorder level cannot be negative."),
  standardCost: z.coerce.number().min(0, "Standard cost cannot be negative."),
});

export type ItemFormValues = z.infer<typeof itemFormSchema>;

type ItemFormDialogProps = {
  open: boolean;
  item?: Item | null;
  isSubmitting: boolean;
  errorMessage?: string | null;
  onClose: () => void;
  onSubmit: (values: UpsertItemInput) => Promise<void>;
};

const getDefaultValues = (item?: Item | null): ItemFormValues => ({
  categoryId: item?.categoryId ?? itemCategories[0].id,
  sku: item?.sku ?? "",
  name: item?.name ?? "",
  description: item?.description ?? "",
  unit: item?.unit ?? "EA",
  reorderLevel: item?.reorderLevel ?? 0,
  standardCost: item?.standardCost ?? 0,
});

export function ItemFormDialog({
  open,
  item,
  isSubmitting,
  errorMessage,
  onClose,
  onSubmit,
}: ItemFormDialogProps) {
  const { control, handleSubmit, reset, setError } = useForm<ItemFormValues>({
    defaultValues: getDefaultValues(item),
  });

  useEffect(() => {
    reset(getDefaultValues(item));
  }, [item, reset, open]);

  const submit = handleSubmit(async (values) => {
    const parsed = itemFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const fieldName = issue.path[0];

        if (
          fieldName === "categoryId" ||
          fieldName === "sku" ||
          fieldName === "name" ||
          fieldName === "description" ||
          fieldName === "unit" ||
          fieldName === "reorderLevel" ||
          fieldName === "standardCost"
        ) {
          setError(fieldName, { message: issue.message });
        }
      });
      return;
    }

    await onSubmit({
      ...parsed.data,
      description: parsed.data.description?.trim() || undefined,
      sku: parsed.data.sku.trim().toUpperCase(),
      name: parsed.data.name.trim(),
      unit: parsed.data.unit.trim().toUpperCase(),
    });
  });

  return (
    <Dialog open={open} onClose={isSubmitting ? undefined : onClose} fullWidth maxWidth="sm">
      <DialogTitle>{item ? "Edit item" : "Create item"}</DialogTitle>
      <DialogContent dividers>
        <Stack spacing={2} sx={{ pt: 1 }}>
          {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}

          <AppFormTextField
            control={control}
            name="categoryId"
            label="Category"
            select
            fullWidth
          >
            {itemCategories.map((category) => (
              <MenuItem key={category.id} value={category.id}>
                {category.name}
              </MenuItem>
            ))}
          </AppFormTextField>

          <AppFormTextField control={control} name="sku" label="SKU" fullWidth />
          <AppFormTextField control={control} name="name" label="Item name" fullWidth />
          <AppFormTextField
            control={control}
            name="description"
            label="Description"
            fullWidth
            multiline
            minRows={3}
          />

          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <AppFormTextField control={control} name="unit" label="Unit" fullWidth />
            <AppFormTextField
              control={control}
              name="reorderLevel"
              label="Reorder level"
              type="number"
              fullWidth
            />
            <AppFormTextField
              control={control}
              name="standardCost"
              label="Standard cost"
              type="number"
              fullWidth
            />
          </Stack>
        </Stack>
      </DialogContent>
      <DialogActions sx={{ px: 3, py: 2 }}>
        <Button onClick={onClose} color="inherit" disabled={isSubmitting}>
          Cancel
        </Button>
        <Button onClick={submit} variant="contained" disabled={isSubmitting}>
          {isSubmitting ? "Saving..." : item ? "Save changes" : "Create item"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}
