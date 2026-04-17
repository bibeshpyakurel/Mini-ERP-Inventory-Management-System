export type InventoryBalance = {
  id: string;
  itemId: string;
  itemSku: string;
  itemName: string;
  warehouseId: string;
  warehouseCode: string;
  warehouseName: string;
  locationId: string;
  locationCode: string;
  locationName: string;
  quantityOnHand: number;
  quantityReserved: number;
  quantityAvailable: number;
};

export type InventoryTransaction = {
  id: string;
  itemId: string;
  itemSku: string;
  itemName: string;
  warehouseId: string;
  warehouseCode: string;
  warehouseName: string;
  locationId: string;
  locationCode: string;
  locationName: string;
  transactionType: string;
  referenceType: string;
  referenceId: string | null;
  reason: string | null;
  quantityChange: number;
  balanceAfter: number;
  performedByUserId: string;
  performedAt: string;
};

export type LowStockItem = {
  itemId: string;
  itemSku: string;
  itemName: string;
  reorderLevel: number;
  quantityAvailable: number;
  shortfall: number;
};

export type InventoryBalanceFilters = {
  itemId?: string;
  warehouseId?: string;
};

export type InventoryTransactionFilters = {
  fromDateUtc?: string;
  toDateUtc?: string;
  itemId?: string;
  warehouseId?: string;
  transactionType?: string;
};

export type IssueStockInput = {
  itemId: string;
  warehouseId: string;
  locationId: string;
  quantity: number;
  referenceType: string;
  referenceId?: string;
  reason: string;
};

export type AdjustStockInput = {
  itemId: string;
  warehouseId: string;
  locationId: string;
  quantityDelta: number;
  referenceId?: string;
  reason: string;
};
