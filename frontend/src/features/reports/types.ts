export type StockSummaryReport = {
  totalTrackedItems: number;
  totalQuantityOnHand: number;
  totalQuantityReserved: number;
  totalQuantityAvailable: number;
  lowStockItemCount: number;
};

export type LowStockReportItem = {
  itemId: string;
  itemSku: string;
  itemName: string;
  reorderLevel: number;
  quantityAvailable: number;
  shortfall: number;
};

export type StockValuationReportItem = {
  itemId: string;
  itemSku: string;
  itemName: string;
  quantityOnHand: number;
  standardCost: number;
  inventoryValue: number;
};

export type StockValuationReport = {
  totalInventoryValue: number;
  items: StockValuationReportItem[];
};

export type PurchaseOrderSummaryReport = {
  draftCount: number;
  approvedCount: number;
  partiallyReceivedCount: number;
  completedCount: number;
  cancelledCount: number;
  totalOpenPurchaseOrderValue: number;
};

export type RecentTransactionReportItem = {
  transactionId: string;
  itemId: string;
  itemSku: string;
  itemName: string;
  transactionType: string;
  quantityChange: number;
  balanceAfter: number;
  referenceType: string;
  reason: string | null;
  performedAt: string;
};
