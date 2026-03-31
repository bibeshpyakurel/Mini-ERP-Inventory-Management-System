import {
  Alert,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Stack,
  Typography,
} from "@mui/material";
import { useEffect } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { AppFormTextField } from "../../components/AppFormTextField";
import {
  defaultLocationId,
  defaultWarehouseId,
} from "./constants";
import type { PurchaseOrder, ReceivePurchaseOrderInput } from "./types";

const receiveFormSchema = z.object({
  receiptNumber: z.string().trim().min(1, "Receipt number is required.").max(50, "Receipt number must be 50 characters or less."),
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
  receivedByUserId: string;
  isSubmitting: boolean;
  errorMessage?: string | null;
  onClose: () => void;
  onSubmit: (values: ReceivePurchaseOrderInput) => Promise<void>;
};

const getDefaultValues = (purchaseOrder: PurchaseOrder): ReceiveFormValues => ({
  receiptNumber: `GR-${purchaseOrder.poNumber.replace("PO-", "")}`,
  lines: purchaseOrder.lines
    .filter((line) => line.receivedQuantity < line.orderedQuantity)
    .map((line) => ({
      purchaseOrderLineId: line.id,
      itemId: line.itemId,
      receivedQuantity: line.orderedQuantity - line.receivedQuantity,
    })),
});

export function ReceivePurchaseOrderDialog({
  open,
  purchaseOrder,
  receivedByUserId,
  isSubmitting,
  errorMessage,
  onClose,
  onSubmit,
}: ReceivePurchaseOrderDialogProps) {
  const { control, handleSubmit, reset, setError } = useForm<ReceiveFormValues>({
    defaultValues: getDefaultValues(purchaseOrder),
  });

  const receivableLines = purchaseOrder.lines.filter(
    (line) => line.receivedQuantity < line.orderedQuantity,
  );

  useEffect(() => {
    reset(getDefaultValues(purchaseOrder));
  }, [open, purchaseOrder, reset]);

  const submit = handleSubmit(async (values) => {
    const parsed = receiveFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        if (issue.path[0] === "receiptNumber") {
          setError("receiptNumber", { message: issue.message });
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
      receivedByUserId,
      receivedAtUtc: new Date().toISOString(),
      lines: parsed.data.lines.map((line) => ({
        purchaseOrderLineId: line.purchaseOrderLineId,
        itemId: line.itemId,
        receivedQuantity: line.receivedQuantity,
        warehouseId: defaultWarehouseId,
        locationId: defaultLocationId,
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
            Enter received quantities for each open line. Warehouse and location use the seeded defaults for now.
          </Typography>
          <AppFormTextField control={control} name="receiptNumber" label="Receipt number" fullWidth />
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
