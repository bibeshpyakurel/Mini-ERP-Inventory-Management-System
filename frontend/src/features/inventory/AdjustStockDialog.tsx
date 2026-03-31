import {
  Alert,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  Stack,
} from "@mui/material";
import { useEffect } from "react";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { AppFormTextField } from "../../components/AppFormTextField";
import type { AdjustStockInput, InventoryBalance } from "./types";

const adjustFormSchema = z.object({
  quantityDelta: z.coerce.number().int().refine((value) => value !== 0, {
    message: "Adjustment quantity cannot be zero.",
  }),
  referenceId: z.string().uuid("Reference ID must be a valid GUID.").optional().or(z.literal("")),
  reason: z.string().trim().min(1, "Reason is required.").max(500, "Reason must be 500 characters or less."),
});

type AdjustFormValues = z.infer<typeof adjustFormSchema>;

type AdjustStockDialogProps = {
  open: boolean;
  balance: InventoryBalance | null;
  performedByUserId: string;
  isSubmitting: boolean;
  errorMessage?: string | null;
  onClose: () => void;
  onSubmit: (values: AdjustStockInput) => Promise<void>;
};

const getDefaultValues = (): AdjustFormValues => ({
  quantityDelta: 1,
  referenceId: "",
  reason: "",
});

export function AdjustStockDialog({
  open,
  balance,
  performedByUserId,
  isSubmitting,
  errorMessage,
  onClose,
  onSubmit,
}: AdjustStockDialogProps) {
  const { control, handleSubmit, reset, setError } = useForm<AdjustFormValues>({
    defaultValues: getDefaultValues(),
  });

  useEffect(() => {
    reset(getDefaultValues());
  }, [open, reset, balance]);

  const submit = handleSubmit(async (values) => {
    const parsed = adjustFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const fieldName = issue.path[0];

        if (fieldName === "quantityDelta" || fieldName === "referenceId" || fieldName === "reason") {
          setError(fieldName, { message: issue.message });
        }
      });
      return;
    }

    if (!balance) {
      return;
    }

    await onSubmit({
      itemId: balance.itemId,
      warehouseId: balance.warehouseId,
      locationId: balance.locationId,
      performedByUserId,
      quantityDelta: parsed.data.quantityDelta,
      referenceId: parsed.data.referenceId || undefined,
      reason: parsed.data.reason.trim(),
    });
  });

  return (
    <Dialog open={open} onClose={isSubmitting ? undefined : onClose} fullWidth maxWidth="sm">
      <DialogTitle>Adjust stock</DialogTitle>
      <DialogContent dividers>
        <Stack spacing={2} sx={{ pt: 1 }}>
          {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}
          <Alert severity="info">
            {balance
              ? `${balance.itemSku} - ${balance.itemName} • On hand: ${balance.quantityOnHand}`
              : "Select an inventory balance first."}
          </Alert>
          <AppFormTextField
            control={control}
            name="quantityDelta"
            label="Quantity delta"
            type="number"
            helperText="Use a positive number to add stock or a negative number to reduce stock."
            fullWidth
          />
          <AppFormTextField control={control} name="referenceId" label="Reference ID (optional)" fullWidth />
          <AppFormTextField control={control} name="reason" label="Reason" fullWidth multiline minRows={3} />
        </Stack>
      </DialogContent>
      <DialogActions sx={{ px: 3, py: 2 }}>
        <Button onClick={onClose} color="inherit" disabled={isSubmitting}>
          Cancel
        </Button>
        <Button onClick={submit} variant="contained" disabled={isSubmitting || !balance}>
          {isSubmitting ? "Applying..." : "Apply adjustment"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}
