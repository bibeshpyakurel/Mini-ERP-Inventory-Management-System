import { apiClient } from "../../api/client";
import type {
  LowStockReportItem,
  PurchaseOrderSummaryReport,
  RecentTransactionReportItem,
  StockSummaryReport,
  StockValuationReport,
} from "./types";

export const reportsApi = {
  getStockSummary(token: string) {
    return apiClient.request<StockSummaryReport>("/reports/stock-summary", {
      token,
    });
  },
  getLowStock(token: string) {
    return apiClient.request<LowStockReportItem[]>("/reports/low-stock", {
      token,
    });
  },
  getStockValuation(token: string) {
    return apiClient.request<StockValuationReport>("/reports/stock-valuation", {
      token,
    });
  },
  getPurchaseOrderSummary(token: string) {
    return apiClient.request<PurchaseOrderSummaryReport>(
      "/reports/purchase-order-summary",
      { token },
    );
  },
  getRecentTransactions(token: string, take = 5) {
    return apiClient.request<RecentTransactionReportItem[]>(
      `/reports/recent-transactions?take=${take}`,
      { token },
    );
  },
};
