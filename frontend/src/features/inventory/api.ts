import { apiClient } from "../../api/client";
import type {
  AdjustStockInput,
  InventoryBalance,
  InventoryBalanceFilters,
  InventoryTransaction,
  InventoryTransactionFilters,
  IssueStockInput,
  LowStockItem,
} from "./types";

const buildQueryString = (filters: Record<string, string | undefined>) => {
  const params = new URLSearchParams();

  Object.entries(filters).forEach(([key, value]) => {
    if (value) {
      params.set(key, value);
    }
  });

  const queryString = params.toString();
  return queryString ? `?${queryString}` : "";
};

export const inventoryApi = {
  getBalances(token: string, filters: InventoryBalanceFilters) {
    return apiClient.request<InventoryBalance[]>(
      `/inventory/balances${buildQueryString({
        itemId: filters.itemId,
        warehouseId: filters.warehouseId,
      })}`,
      { token },
    );
  },
  getTransactions(token: string, filters: InventoryTransactionFilters) {
    return apiClient.request<InventoryTransaction[]>(
      `/inventory/transactions${buildQueryString({
        fromDateUtc: filters.fromDateUtc,
        toDateUtc: filters.toDateUtc,
        itemId: filters.itemId,
        warehouseId: filters.warehouseId,
        transactionType: filters.transactionType,
      })}`,
      { token },
    );
  },
  getLowStock(token: string) {
    return apiClient.request<LowStockItem[]>("/reports/low-stock", { token });
  },
  issueStock(token: string, input: IssueStockInput) {
    return apiClient.request("/inventory/issues", {
      method: "POST",
      body: input,
      token,
    });
  },
  adjustStock(token: string, input: AdjustStockInput) {
    return apiClient.request("/inventory/adjustments", {
      method: "POST",
      body: input,
      token,
    });
  },
};
