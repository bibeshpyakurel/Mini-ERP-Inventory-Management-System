import { apiClient } from "../../api/client";
import type {
  CreatePurchaseOrderInput,
  PurchaseOrder,
  PurchaseOrderFilters,
  ReceivePurchaseOrderInput,
} from "./types";

const buildQueryString = (filters: PurchaseOrderFilters) => {
  const params = new URLSearchParams();

  if (filters.supplierId) {
    params.set("supplierId", filters.supplierId);
  }

  if (filters.status) {
    params.set("status", filters.status);
  }

  const queryString = params.toString();
  return queryString ? `?${queryString}` : "";
};

export const purchaseOrdersApi = {
  list(token: string, filters: PurchaseOrderFilters) {
    return apiClient.request<PurchaseOrder[]>(
      `/purchase-orders${buildQueryString(filters)}`,
      { token },
    );
  },
  getById(token: string, purchaseOrderId: string) {
    return apiClient.request<PurchaseOrder>(`/purchase-orders/${purchaseOrderId}`, {
      token,
    });
  },
  create(token: string, input: CreatePurchaseOrderInput) {
    return apiClient.request<PurchaseOrder>("/purchase-orders", {
      method: "POST",
      body: input,
      token,
    });
  },
  approve(token: string, purchaseOrderId: string) {
    return apiClient.request<PurchaseOrder>(`/purchase-orders/${purchaseOrderId}/status`, {
      method: "PATCH",
      body: { status: "Approved" },
      token,
    });
  },
  receive(token: string, input: ReceivePurchaseOrderInput) {
    return apiClient.request("/goods-receipts", {
      method: "POST",
      body: input,
      token,
    });
  },
};
