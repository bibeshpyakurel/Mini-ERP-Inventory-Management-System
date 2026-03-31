export type PurchaseOrderLine = {
  id: string;
  itemId: string;
  itemSku: string;
  itemName: string;
  orderedQuantity: number;
  receivedQuantity: number;
  unitCost: number;
  lineTotal: number;
};

export type PurchaseOrder = {
  id: string;
  poNumber: string;
  supplierId: string;
  supplierName: string;
  status: string;
  orderDate: string;
  expectedDate: string | null;
  createdByUserId: string;
  totalAmount: number;
  lines: PurchaseOrderLine[];
};

export type PurchaseOrderFilters = {
  supplierId?: string;
  status?: string;
};

export type PurchaseOrderLineInput = {
  itemId: string;
  orderedQuantity: number;
  unitCost: number;
};

export type CreatePurchaseOrderInput = {
  poNumber: string;
  supplierId: string;
  createdByUserId: string;
  orderDate: string;
  expectedDate?: string;
  lines: PurchaseOrderLineInput[];
};

export type ReceivePurchaseOrderInput = {
  purchaseOrderId: string;
  receiptNumber: string;
  receivedByUserId: string;
  receivedAtUtc?: string;
  lines: {
    purchaseOrderLineId: string;
    itemId: string;
    receivedQuantity: number;
    warehouseId: string;
    locationId: string;
  }[];
};
