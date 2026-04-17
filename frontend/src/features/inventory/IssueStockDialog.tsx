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
import type { InventoryBalance, IssueStockInput } from "./types";

const issueFormSchema = z.object({
  quantity: z.coerce.number().int().min(1, "Quantity must be at least 1."),
  referenceType: z.string().trim().min(1, "Reference type is required.").max(50, "Reference type must be 50 characters or less."),
  referenceId: z.string().uuid("Reference ID must be a valid GUID.").optional().or(z.literal("")),
  reason: z.string().trim().min(1, "Reason is required.").max(500, "Reason must be 500 characters or less."),
});

type IssueFormValues = z.infer<typeof issueFormSchema>;

type IssueStockDialogProps = {
  open: boolean;
  balance: InventoryBalance | null;
  isSubmitting: boolean;
  errorMessage?: string | null;
  onClose: () => void;
  onSubmit: (values: IssueStockInput) => Promise<void>;
};

const getDefaultValues = (): IssueFormValues => ({
  quantity: 1,
  referenceType: "WorkOrder",
  referenceId: "",
  reason: "",
});

export function IssueStockDialog({
  open,
  balance,
  isSubmitting,
  errorMessage,
  onClose,
  onSubmit,
}: IssueStockDialogProps) {
  const { control, handleSubmit, reset, setError } = useForm<IssueFormValues>({
    defaultValues: getDefaultValues(),
  });

  useEffect(() => {
    reset(getDefaultValues());
  }, [open, reset, balance]);

  const submit = handleSubmit(async (values) => {
    const parsed = issueFormSchema.safeParse(values);

    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const fieldName = issue.path[0];

        if (
          fieldName === "quantity" ||
          fieldName === "referenceType" ||
          fieldName === "referenceId" ||
          fieldName === "reason"
        ) {
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
      quantity: parsed.data.quantity,
      referenceType: parsed.data.referenceType.trim(),
      referenceId: parsed.data.referenceId || undefined,
      reason: parsed.data.reason.trim(),
    });
  });

  return (
    <Dialog open={open} onClose={isSubmitting ? undefined : onClose} fullWidth maxWidth="sm">
      <DialogTitle>Issue stock</DialogTitle>
      <DialogContent dividers>
        <Stack spacing={2} sx={{ pt: 1 }}>
          {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}
          <Alert severity="info">
            {balance
              ? `${balance.itemSku} - ${balance.itemName} • Available: ${balance.quantityAvailable}`
              : "Select an inventory balance first."}
          </Alert>
          <AppFormTextField control={control} name="quantity" label="Quantity to issue" type="number" fullWidth />
          <AppFormTextField control={control} name="referenceType" label="Reference type" fullWidth />
          <AppFormTextField control={control} name="referenceId" label="Reference ID (optional)" fullWidth />
          <AppFormTextField control={control} name="reason" label="Reason" fullWidth multiline minRows={3} />
        </Stack>
      </DialogContent>
      <DialogActions sx={{ px: 3, py: 2 }}>
        <Button onClick={onClose} color="inherit" disabled={isSubmitting}>
          Cancel
        </Button>
        <Button onClick={submit} variant="contained" disabled={isSubmitting || !balance}>
          {isSubmitting ? "Issuing..." : "Issue stock"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}
