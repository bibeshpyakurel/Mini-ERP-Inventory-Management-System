export const purchaseOrderStatusOptions = [
  "Draft",
  "Approved",
  "PartiallyReceived",
  "Completed",
  "Cancelled",
] as const;

export const supplierOptions = [
  {
    id: "40000000-0000-0000-0000-000000000001",
    name: "Acme Industrial Supply",
  },
  {
    id: "40000000-0000-0000-0000-000000000002",
    name: "Northwood Components",
  },
  {
    id: "40000000-0000-0000-0000-000000000003",
    name: "Eastlake Office Furnishings",
  },
] as const;

export const defaultWarehouseId = "50000000-0000-0000-0000-000000000001";
export const defaultLocationId = "60000000-0000-0000-0000-000000000001";
