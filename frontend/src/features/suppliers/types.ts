export type SupplierItemMapping = {
  itemId: string;
  itemName: string;
  itemSku: string;
  supplierSku: string;
};

export type Supplier = {
  id: string;
  name: string;
  contactName: string;
  email: string;
  phone: string;
  notes: string | null;
  isActive: boolean;
  items: SupplierItemMapping[];
};

export type SupplierFilters = {
  search?: string;
  isActive?: boolean;
};

export type UpsertSupplierItemInput = {
  itemId: string;
  supplierSku: string;
};

export type UpsertSupplierInput = {
  name: string;
  contactName: string;
  email: string;
  phone: string;
  notes?: string;
  items?: UpsertSupplierItemInput[];
};
