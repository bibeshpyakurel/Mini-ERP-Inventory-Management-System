import AddRoundedIcon from "@mui/icons-material/AddRounded";
import DeleteOutlineRoundedIcon from "@mui/icons-material/DeleteOutlineRounded";
import {
  Alert,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  MenuItem,
  Stack,
  Typography,
} from "@mui/material";
import { useEffect } from "react";
import { useFieldArray, useForm } from "react-hook-form";
import { z } from "zod";
import { AppFormTextField } from "../../components/AppFormTextField";
import { supplierItemOptions } from "./constants";
import type { Supplier, UpsertSupplierInput } from "./types";

const supplierFormSchema = z.object({
  name: z.string().trim().min(1, "Supplier name is required.").max(200, "Supplier name must be 200 characters or less."),
  contactName: z.string().trim().min(1, "Contact name is required.").max(120, "Contact name must be 120 characters or less."),
  email: z.string().trim().email("Enter a valid email address.").max(200, "Email must be 200 characters or less."),
  phone: z.string().trim().min(1, "Phone is required.").max(30, "Phone must be 30 characters or less."),
  notes: z.string().max(1000, "Notes must be 1000 characters or less.").optional().or(z.literal("")),
  items: z.array(
    z.object({
      itemId: z.string().uuid("Select a valid item."),
      supplierSku: z.string().trim().min(1, "Supplier SKU is required.").max(64, "Supplier SKU must be 64 characters or less."),
    }),
  ),
});

type SupplierFormValues = z.infer<typeof supplierFormSchema>;

type SupplierFormDialogProps = {
  open: boolean;
  supplier?: Supplier | null;
  isSubmitting: boolean;
  errorMessage?: string | null;
  onClose: () => void;
  onSubmit: (values: UpsertSupplierInput) => Promise<void>;
};

const getDefaultValues = (supplier?: Supplier | null): SupplierFormValues => ({
  name: supplier?.name ?? "",
  contactName: supplier?.contactName ?? "",
  email: supplier?.email ?? "",
  phone: supplier?.phone ?? "",
  notes: supplier?.notes ?? "",
  items:
    supplier?.items.map((item) => ({
      itemId: item.itemId,
      supplierSku: item.supplierSku,
    })) ?? [],
});

export function SupplierFormDialog({
  open,
  supplier,
  isSubmitting,
  errorMessage,
  onClose,
  onSubmit,
}: SupplierFormDialogProps) {
  const { control, handleSubmit, reset, setError } = useForm<SupplierFormValues>({
    defaultValues: getDefaultValues(supplier),
  });

  const { fields, append, remove } = useFieldArray({
    control,
    name: "items",
  });

  useEffect(() => {
    reset(getDefaultValues(supplier));
  }, [supplier, reset, open]);

  const submit = handleSubmit(async (values) => {
    const parsed = supplierFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const path = issue.path;
        const fieldName = path[0];

        if (
          fieldName === "name" ||
          fieldName === "contactName" ||
          fieldName === "email" ||
          fieldName === "phone" ||
          fieldName === "notes"
        ) {
          setError(fieldName, { message: issue.message });
          return;
        }

        if (fieldName === "items" && typeof path[1] === "number" && (path[2] === "itemId" || path[2] === "supplierSku")) {
          setError(`items.${path[1]}.${path[2]}`, { message: issue.message });
        }
      });
      return;
    }

    await onSubmit({
      ...parsed.data,
      notes: parsed.data.notes?.trim() || undefined,
      items: parsed.data.items,
    });
  });

  return (
    <Dialog open={open} onClose={isSubmitting ? undefined : onClose} fullWidth maxWidth="md">
      <DialogTitle>{supplier ? "Edit supplier" : "Create supplier"}</DialogTitle>
      <DialogContent dividers>
        <Stack spacing={2.5} sx={{ pt: 1 }}>
          {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}

          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <AppFormTextField control={control} name="name" label="Supplier name" fullWidth />
            <AppFormTextField control={control} name="contactName" label="Contact name" fullWidth />
          </Stack>

          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <AppFormTextField control={control} name="email" label="Email" fullWidth />
            <AppFormTextField control={control} name="phone" label="Phone" fullWidth />
          </Stack>

          <AppFormTextField
            control={control}
            name="notes"
            label="Notes"
            fullWidth
            multiline
            minRows={3}
          />

          <Stack spacing={1.5}>
            <Stack direction="row" justifyContent="space-between" alignItems="center">
              <Typography variant="subtitle1" sx={{ fontWeight: 700 }}>
                Supplier item mappings
              </Typography>
              <Button
                variant="outlined"
                size="small"
                startIcon={<AddRoundedIcon />}
                onClick={() => append({
                  itemId: supplierItemOptions[0].id,
                  supplierSku: "",
                })}
                disabled={isSubmitting}
              >
                Add mapping
              </Button>
            </Stack>

            {fields.length === 0 ? (
              <Typography variant="body2" color="text.secondary">
                No supplier-item mappings yet. You can add them later if needed.
              </Typography>
            ) : null}

            {fields.map((field, index) => (
              <Stack
                key={field.id}
                direction={{ xs: "column", md: "row" }}
                spacing={2}
                alignItems={{ md: "flex-start" }}
              >
                <AppFormTextField
                  control={control}
                  name={`items.${index}.itemId`}
                  label="Item"
                  select
                  fullWidth
                >
                  {supplierItemOptions.map((item) => (
                    <MenuItem key={item.id} value={item.id}>
                      {item.sku} - {item.name}
                    </MenuItem>
                  ))}
                </AppFormTextField>
                <AppFormTextField
                  control={control}
                  name={`items.${index}.supplierSku`}
                  label="Supplier SKU"
                  fullWidth
                />
                <IconButton
                  onClick={() => remove(index)}
                  aria-label="Remove mapping"
                  disabled={isSubmitting}
                  sx={{ alignSelf: { xs: "flex-end", md: "center" } }}
                >
                  <DeleteOutlineRoundedIcon />
                </IconButton>
              </Stack>
            ))}
          </Stack>
        </Stack>
      </DialogContent>
      <DialogActions sx={{ px: 3, py: 2 }}>
        <Button onClick={onClose} color="inherit" disabled={isSubmitting}>
          Cancel
        </Button>
        <Button onClick={submit} variant="contained" disabled={isSubmitting}>
          {isSubmitting ? "Saving..." : supplier ? "Save changes" : "Create supplier"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}
