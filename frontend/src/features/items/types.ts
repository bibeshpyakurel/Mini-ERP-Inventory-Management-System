export type Item = {
  id: string;
  categoryId: string;
  categoryName: string;
  sku: string;
  name: string;
  description: string | null;
  unit: string;
  reorderLevel: number;
  standardCost: number;
  isActive: boolean;
};

export type ItemFilters = {
  search?: string;
  categoryId?: string;
  isActive?: boolean;
};

export type UpsertItemInput = {
  categoryId: string;
  sku: string;
  name: string;
  description?: string;
  unit: string;
  reorderLevel: number;
  standardCost: number;
};

export type ItemStatusInput = {
  isActive: boolean;
};
