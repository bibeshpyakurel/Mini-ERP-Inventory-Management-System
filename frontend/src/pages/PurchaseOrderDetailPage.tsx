import ArrowBackRoundedIcon from "@mui/icons-material/ArrowBackRounded";
import CheckCircleRoundedIcon from "@mui/icons-material/CheckCircleRounded";
import InventoryRoundedIcon from "@mui/icons-material/InventoryRounded";
import {
  Alert,
  Button,
  Chip,
  CircularProgress,
  Stack,
  Typography,
} from "@mui/material";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { Link as RouterLink, useParams } from "react-router-dom";
import { ApiClientError } from "../api/client";
import { AppDataTable, type TableColumn } from "../components/AppDataTable";
import { PageSection } from "../components/PageSection";
import { useAuth } from "../features/auth/AuthContext";
import { purchaseOrdersApi } from "../features/purchaseOrders/api";
import { ReceivePurchaseOrderDialog } from "../features/purchaseOrders/ReceivePurchaseOrderDialog";
import type { PurchaseOrder, ReceivePurchaseOrderInput } from "../features/purchaseOrders/types";
import { useState } from "react";

export function PurchaseOrderDetailPage() {
  const { purchaseOrderId = "" } = useParams();
  const queryClient = useQueryClient();
  const { accessToken, primaryRole } = useAuth();
  const [receiveOpen, setReceiveOpen] = useState(false);
  const [receiveError, setReceiveError] = useState<string | null>(null);
  const [successMessage, setSuccessMessage] = useState<string | null>(null);

  const purchaseOrderQuery = useQuery({
    queryKey: ["purchase-order", purchaseOrderId],
    queryFn: async () => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return purchaseOrdersApi.getById(accessToken, purchaseOrderId);
    },
    enabled: Boolean(accessToken && purchaseOrderId),
  });

  const approveMutation = useMutation({
    mutationFn: async () => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return purchaseOrdersApi.approve(accessToken, purchaseOrderId);
    },
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ["purchase-order", purchaseOrderId] });
      await queryClient.invalidateQueries({ queryKey: ["purchase-orders"] });
    },
  });

  const receiveMutation = useMutation({
    mutationFn: async (input: ReceivePurchaseOrderInput) => {
      if (!accessToken) {
        throw new Error("Missing access token.");
      }

      return purchaseOrdersApi.receive(accessToken, input);
    },
    onSuccess: async () => {
      setReceiveOpen(false);
      setReceiveError(null);
      setSuccessMessage("Goods receipt posted successfully.");
      await queryClient.invalidateQueries({ queryKey: ["purchase-order", purchaseOrderId] });
      await queryClient.invalidateQueries({ queryKey: ["purchase-orders"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-balances"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-transactions"] });
      await queryClient.invalidateQueries({ queryKey: ["inventory-low-stock"] });
    },
  });

  const canApprove =
    primaryRole === "Admin" || primaryRole === "InventoryManager";
  const canReceive =
    primaryRole === "Admin" ||
    primaryRole === "InventoryManager" ||
    primaryRole === "WarehouseStaff";

  const handleReceive = async (input: ReceivePurchaseOrderInput) => {
    setReceiveError(null);
    setSuccessMessage(null);

    try {
      await receiveMutation.mutateAsync(input);
    } catch (error) {
      if (error instanceof ApiClientError) {
        setReceiveError(error.message);
        return;
      }

      setReceiveError("Unable to post the receipt right now.");
    }
  };

  const lineColumns: TableColumn<PurchaseOrder["lines"][number]>[] = [
    {
      key: "item",
      header: "Item",
      render: (row) => `${row.itemSku} - ${row.itemName}`,
    },
    {
      key: "orderedQuantity",
      header: "Ordered",
      align: "right",
      render: (row) => row.orderedQuantity,
    },
    {
      key: "receivedQuantity",
      header: "Received",
      align: "right",
      render: (row) => row.receivedQuantity,
    },
    {
      key: "unitCost",
      header: "Unit Cost",
      align: "right",
      render: (row) => `$${row.unitCost.toFixed(2)}`,
    },
    {
      key: "lineTotal",
      header: "Line Total",
      align: "right",
      render: (row) => `$${row.lineTotal.toFixed(2)}`,
    },
  ];

  return (
    <Stack spacing={3}>
      <Button
        component={RouterLink}
        to="/purchase-orders"
        color="inherit"
        startIcon={<ArrowBackRoundedIcon />}
        sx={{ alignSelf: "flex-start" }}
      >
        Back to purchase orders
      </Button>

      {purchaseOrderQuery.isLoading ? (
        <Stack spacing={1.5} alignItems="center" sx={{ py: 8 }}>
          <CircularProgress />
          <Typography color="text.secondary">Loading purchase order...</Typography>
        </Stack>
      ) : purchaseOrderQuery.isError ? (
        <Alert severity="error">
          {purchaseOrderQuery.error instanceof ApiClientError
            ? purchaseOrderQuery.error.message
            : "Unable to load the purchase order right now."}
        </Alert>
      ) : purchaseOrderQuery.data ? (
        <>
          {successMessage ? <Alert severity="success">{successMessage}</Alert> : null}
          {approveMutation.isError ? (
            <Alert severity="error">
              {approveMutation.error instanceof ApiClientError
                ? approveMutation.error.message
                : "Unable to approve the purchase order right now."}
            </Alert>
          ) : null}
          <PageSection
            eyebrow="Purchasing"
            title={purchaseOrderQuery.data.poNumber}
            description={`${purchaseOrderQuery.data.supplierName} • Ordered ${new Date(
              purchaseOrderQuery.data.orderDate,
            ).toLocaleDateString()}`}
            actions={
              <Stack direction={{ xs: "column", sm: "row" }} spacing={1}>
                <Chip label={purchaseOrderQuery.data.status} color="primary" variant="outlined" />
                {canApprove && purchaseOrderQuery.data.status === "Draft" ? (
                  <Button
                    variant="contained"
                    startIcon={<CheckCircleRoundedIcon />}
                    onClick={() => {
                      setSuccessMessage(null);
                      approveMutation.mutate(undefined, {
                        onSuccess: () => {
                          setSuccessMessage("Purchase order approved successfully.");
                        },
                      });
                    }}
                    disabled={approveMutation.isPending}
                  >
                    {approveMutation.isPending ? "Approving..." : "Approve"}
                  </Button>
                ) : null}
                {canReceive &&
                (purchaseOrderQuery.data.status === "Approved" ||
                  purchaseOrderQuery.data.status === "PartiallyReceived") ? (
                  <Button
                    variant="outlined"
                    startIcon={<InventoryRoundedIcon />}
                    onClick={() => setReceiveOpen(true)}
                  >
                    Receive
                  </Button>
                ) : null}
              </Stack>
            }
          >
            <Stack direction={{ xs: "column", md: "row" }} spacing={3}>
              <Typography variant="body2" color="text.secondary">
                Expected date:{" "}
                {purchaseOrderQuery.data.expectedDate
                  ? new Date(purchaseOrderQuery.data.expectedDate).toLocaleDateString()
                  : "Not set"}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Total amount: ${purchaseOrderQuery.data.totalAmount.toFixed(2)}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Created by user: {purchaseOrderQuery.data.createdByUserId}
              </Typography>
            </Stack>
          </PageSection>

          <PageSection
            eyebrow="Line Items"
            title="Purchase order lines"
            description="Ordered, received, and remaining quantities for each item on the order."
          >
            <AppDataTable columns={lineColumns} rows={purchaseOrderQuery.data.lines} />
          </PageSection>

          <ReceivePurchaseOrderDialog
            open={receiveOpen}
            purchaseOrder={purchaseOrderQuery.data}
            isSubmitting={receiveMutation.isPending}
            errorMessage={receiveError}
            onClose={() => {
              setReceiveOpen(false);
              setReceiveError(null);
            }}
            onSubmit={handleReceive}
          />
        </>
      ) : null}
    </Stack>
  );
}
