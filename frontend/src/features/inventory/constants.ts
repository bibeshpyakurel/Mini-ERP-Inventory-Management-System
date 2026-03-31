export const warehouseOptions = [
  {
    id: "50000000-0000-0000-0000-000000000001",
    name: "Main Warehouse",
    code: "MAIN",
  },
] as const;

export const inventoryItemOptions = [
  {
    id: "70000000-0000-0000-0000-000000000001",
    sku: "CHR-1001",
    name: "Task Chair",
  },
  {
    id: "70000000-0000-0000-0000-000000000002",
    sku: "CAB-2001",
    name: "Filing Cabinet",
  },
  {
    id: "70000000-0000-0000-0000-000000000003",
    sku: "KIT-3001",
    name: "Desk Leg Kit",
  },
  {
    id: "70000000-0000-0000-0000-000000000004",
    sku: "LNG-4001",
    name: "Lounge Chair",
  },
  {
    id: "70000000-0000-0000-0000-000000000005",
    sku: "PED-5001",
    name: "Mobile Pedestal",
  },
  {
    id: "70000000-0000-0000-0000-000000000006",
    sku: "BAS-6001",
    name: "Conference Table Base",
  },
] as const;

export const inventoryTransactionTypes = [
  "Receipt",
  "Issue",
  "AdjustmentIncrease",
  "AdjustmentDecrease",
] as const;
