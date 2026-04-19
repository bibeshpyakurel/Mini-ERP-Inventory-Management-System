import {
  Alert,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  MenuItem,
  Stack,
  Typography,
} from "@mui/material";
import { useEffect } from "react";
import { useForm, useWatch } from "react-hook-form";
import { z } from "zod";
import { AppFormTextField } from "../../components/AppFormTextField";
import type { WarehouseOption } from "../inventory/warehousesApi";
import type { PurchaseOrder, ReceivePurchaseOrderInput } from "./types";

const receiveFormSchema = z.object({
  receiptNumber: z.string().trim().min(1, "Receipt number is required.").max(50, "Receipt number must be 50 characters or less."),
  warehouseId: z.string().uuid("Select a valid warehouse."),
  locationId: z.string().uuid("Select a valid location."),
  lines: z.array(
    z.object({
      purchaseOrderLineId: z.string().uuid(),
      itemId: z.string().uuid(),
      receivedQuantity: z.coerce.number().int().min(1, "Quantity must be at least 1."),
    }),
  ).min(1, "At least one receivable line is required."),
});

type ReceiveFormValues = z.infer<typeof receiveFormSchema>;

type ReceivePurchaseOrderDialogProps = {
  open: boolean;
  purchaseOrder: PurchaseOrder;
  isSubmitting: boolean;
  errorMessage?: string | null;
  warehouses: WarehouseOption[];
  onClose: () => void;
  onSubmit: (values: ReceivePurchaseOrderInput) => Promise<void>;
};

const getDefaultValues = (purchaseOrder: PurchaseOrder, warehouses: WarehouseOption[]): ReceiveFormValues => {
  const firstWarehouse = warehouses[0];
  const firstLocation = firstWarehouse?.locations[0];
  return {
    receiptNumber: `GR-${purchaseOrder.poNumber.replace("PO-", "")}`,
    warehouseId: firstWarehouse?.id ?? "",
    locationId: firstLocation?.id ?? "",
    lines: purchaseOrder.lines
      .filter((line) => line.receivedQuantity < line.orderedQuantity)
      .map((line) => ({
        purchaseOrderLineId: line.id,
        itemId: line.itemId,
        receivedQuantity: line.orderedQuantity - line.receivedQuantity,
      })),
  };
};

export function ReceivePurchaseOrderDialog({
  open,
  purchaseOrder,
  isSubmitting,
  errorMessage,
  warehouses,
  onClose,
  onSubmit,
}: ReceivePurchaseOrderDialogProps) {
  const { control, handleSubmit, reset, setError, setValue } = useForm<ReceiveFormValues>({
    defaultValues: getDefaultValues(purchaseOrder, warehouses),
  });

  const selectedWarehouseId = useWatch({ control, name: "warehouseId" });
  const selectedWarehouse = warehouses.find((w) => w.id === selectedWarehouseId) ?? null;
  const locations = selectedWarehouse?.locations ?? [];

  // When warehouse changes, reset location to first available
  useEffect(() => {
    const first = locations[0];
    if (first) setValue("locationId", first.id);
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [selectedWarehouseId, setValue]);

  const receivableLines = purchaseOrder.lines.filter(
    (line) => line.receivedQuantity < line.orderedQuantity,
  );

  useEffect(() => {
    reset(getDefaultValues(purchaseOrder, warehouses));
  }, [open, purchaseOrder, warehouses, reset]);

  const submit = handleSubmit(async (values) => {
    const parsed = receiveFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        if (issue.path[0] === "receiptNumber") {
          setError("receiptNumber", { message: issue.message });
        }

        if (issue.path[0] === "warehouseId") {
          setError("warehouseId", { message: issue.message });
        }

        if (issue.path[0] === "locationId") {
          setError("locationId", { message: issue.message });
        }

        if (
          issue.path[0] === "lines" &&
          typeof issue.path[1] === "number" &&
          issue.path[2] === "receivedQuantity"
        ) {
          setError(`lines.${issue.path[1]}.receivedQuantity`, { message: issue.message });
        }
      });
      return;
    }

    await onSubmit({
      purchaseOrderId: purchaseOrder.id,
      receiptNumber: parsed.data.receiptNumber.trim().toUpperCase(),
      receivedAtUtc: new Date().toISOString(),
      lines: parsed.data.lines.map((line) => ({
        purchaseOrderLineId: line.purchaseOrderLineId,
        itemId: line.itemId,
        receivedQuantity: line.receivedQuantity,
        warehouseId: parsed.data.warehouseId,
        locationId: parsed.data.locationId,
      })),
    });
  });

  return (
    <Dialog open={open} onClose={isSubmitting ? undefined : onClose} fullWidth maxWidth="sm">
      <DialogTitle>Receive purchase order</DialogTitle>
      <DialogContent dividers>
        <Stack spacing={2} sx={{ pt: 1 }}>
          {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}
          <Typography variant="body2" color="text.secondary">
            Enter the receipt number, destination warehouse and location, then received quantities for each open line.
          </Typography>
          <AppFormTextField control={control} name="receiptNumber" label="Receipt number" fullWidth />
          <Stack direction={{ xs: "column", sm: "row" }} spacing={2}>
            <AppFormTextField control={control} name="warehouseId" label="Warehouse" select fullWidth>
              {warehouses.map((w) => (
                <MenuItem key={w.id} value={w.id}>
                  {w.code} – {w.name}
                </MenuItem>
              ))}
            </AppFormTextField>
            <AppFormTextField control={control} name="locationId" label="Location" select fullWidth>
              {locations.map((l) => (
                <MenuItem key={l.id} value={l.id}>
                  {l.code} – {l.name}
                </MenuItem>
              ))}
            </AppFormTextField>
          </Stack>
          <Stack spacing={1.5}>
            {receivableLines.map((line, index) => (
              <Stack key={line.id} direction={{ xs: "column", md: "row" }} spacing={2} alignItems={{ md: "center" }}>
                <Typography variant="body2" sx={{ flex: 1 }}>
                  {line.itemSku} - {line.itemName} • Remaining {line.orderedQuantity - line.receivedQuantity}
                </Typography>
                <AppFormTextField
                  control={control}
                  name={`lines.${index}.receivedQuantity`}
                  label="Receive qty"
                  type="number"
                  sx={{ width: { xs: "100%", md: 180 } }}
                />
              </Stack>
            ))}
          </Stack>
        </Stack>
      </DialogContent>
      <DialogActions sx={{ px: 3, py: 2 }}>
        <Button onClick={onClose} color="inherit" disabled={isSubmitting}>
          Cancel
        </Button>
        <Button onClick={submit} variant="contained" disabled={isSubmitting || receivableLines.length === 0}>
          {isSubmitting ? "Posting..." : "Post receipt"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}
