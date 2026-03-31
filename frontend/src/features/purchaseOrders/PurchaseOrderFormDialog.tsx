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
import { useFieldArray, useForm } from "react-hook-form";
import { z } from "zod";
import { AppFormTextField } from "../../components/AppFormTextField";
import { inventoryItemOptions } from "../inventory/constants";
import { supplierOptions } from "./constants";
import type { CreatePurchaseOrderInput } from "./types";

const poFormSchema = z.object({
  poNumber: z.string().trim().min(1, "PO number is required.").max(50, "PO number must be 50 characters or less."),
  supplierId: z.string().uuid("Select a valid supplier."),
  orderDate: z.string().min(1, "Order date is required."),
  expectedDate: z.string().optional().or(z.literal("")),
  lines: z.array(
    z.object({
      itemId: z.string().uuid("Select a valid item."),
      orderedQuantity: z.coerce.number().int().min(1, "Quantity must be at least 1."),
      unitCost: z.coerce.number().min(0, "Unit cost cannot be negative."),
    }),
  ).min(1, "At least one purchase order line is required."),
});

type PurchaseOrderFormValues = z.infer<typeof poFormSchema>;

type PurchaseOrderFormDialogProps = {
  open: boolean;
  createdByUserId: string;
  isSubmitting: boolean;
  errorMessage?: string | null;
  onClose: () => void;
  onSubmit: (values: CreatePurchaseOrderInput) => Promise<void>;
};

const getDefaultValues = (): PurchaseOrderFormValues => ({
  poNumber: "",
  supplierId: supplierOptions[0].id,
  orderDate: new Date().toISOString().slice(0, 10),
  expectedDate: "",
  lines: [
    {
      itemId: inventoryItemOptions[0].id,
      orderedQuantity: 1,
      unitCost: 0,
    },
  ],
});

export function PurchaseOrderFormDialog({
  open,
  createdByUserId,
  isSubmitting,
  errorMessage,
  onClose,
  onSubmit,
}: PurchaseOrderFormDialogProps) {
  const { control, handleSubmit, reset, setError } = useForm<PurchaseOrderFormValues>({
    defaultValues: getDefaultValues(),
  });

  const { fields, append, remove } = useFieldArray({
    control,
    name: "lines",
  });

  const submit = handleSubmit(async (values) => {
    const parsed = poFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const path = issue.path;
        const fieldName = path[0];

        if (
          fieldName === "poNumber" ||
          fieldName === "supplierId" ||
          fieldName === "orderDate" ||
          fieldName === "expectedDate"
        ) {
          setError(fieldName, { message: issue.message });
          return;
        }

        if (fieldName === "lines" && typeof path[1] === "number" && (path[2] === "itemId" || path[2] === "orderedQuantity" || path[2] === "unitCost")) {
          setError(`lines.${path[1]}.${path[2]}`, { message: issue.message });
        }
      });
      return;
    }

    await onSubmit({
      poNumber: parsed.data.poNumber.trim().toUpperCase(),
      supplierId: parsed.data.supplierId,
      createdByUserId,
      orderDate: new Date(`${parsed.data.orderDate}T00:00:00Z`).toISOString(),
      expectedDate: parsed.data.expectedDate
        ? new Date(`${parsed.data.expectedDate}T00:00:00Z`).toISOString()
        : undefined,
      lines: parsed.data.lines,
    });

    reset(getDefaultValues());
  });

  return (
    <Dialog open={open} onClose={isSubmitting ? undefined : onClose} fullWidth maxWidth="md">
      <DialogTitle>Create purchase order</DialogTitle>
      <DialogContent dividers>
        <Stack spacing={2.5} sx={{ pt: 1 }}>
          {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}

          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <AppFormTextField control={control} name="poNumber" label="PO number" fullWidth />
            <AppFormTextField control={control} name="supplierId" label="Supplier" select fullWidth>
              {supplierOptions.map((supplier) => (
                <MenuItem key={supplier.id} value={supplier.id}>
                  {supplier.name}
                </MenuItem>
              ))}
            </AppFormTextField>
          </Stack>

          <Stack direction={{ xs: "column", md: "row" }} spacing={2}>
            <AppFormTextField
              control={control}
              name="orderDate"
              label="Order date"
              type="date"
              fullWidth
              InputLabelProps={{ shrink: true }}
            />
            <AppFormTextField
              control={control}
              name="expectedDate"
              label="Expected date"
              type="date"
              fullWidth
              InputLabelProps={{ shrink: true }}
            />
          </Stack>

          <Stack spacing={1.5}>
            <Stack direction="row" justifyContent="space-between" alignItems="center">
              <Typography variant="subtitle1" sx={{ fontWeight: 700 }}>
                Line items
              </Typography>
              <Button
                variant="outlined"
                size="small"
                startIcon={<AddRoundedIcon />}
                onClick={() =>
                  append({
                    itemId: inventoryItemOptions[0].id,
                    orderedQuantity: 1,
                    unitCost: 0,
                  })
                }
                disabled={isSubmitting}
              >
                Add line
              </Button>
            </Stack>

            {fields.map((field, index) => (
              <Stack key={field.id} direction={{ xs: "column", md: "row" }} spacing={2}>
                <AppFormTextField
                  control={control}
                  name={`lines.${index}.itemId`}
                  label="Item"
                  select
                  fullWidth
                >
                  {inventoryItemOptions.map((item) => (
                    <MenuItem key={item.id} value={item.id}>
                      {item.sku} - {item.name}
                    </MenuItem>
                  ))}
                </AppFormTextField>
                <AppFormTextField
                  control={control}
                  name={`lines.${index}.orderedQuantity`}
                  label="Quantity"
                  type="number"
                  fullWidth
                />
                <AppFormTextField
                  control={control}
                  name={`lines.${index}.unitCost`}
                  label="Unit cost"
                  type="number"
                  fullWidth
                />
                <IconButton
                  onClick={() => remove(index)}
                  aria-label="Remove line"
                  disabled={isSubmitting || fields.length === 1}
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
          {isSubmitting ? "Saving..." : "Create PO"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}
