import { apiClient } from "../../api/client";
import type { Supplier, SupplierFilters, UpsertSupplierInput } from "./types";

const buildQueryString = (filters: SupplierFilters) => {
  const params = new URLSearchParams();

  if (filters.search) {
    params.set("search", filters.search);
  }

  if (typeof filters.isActive === "boolean") {
    params.set("isActive", String(filters.isActive));
  }

  const queryString = params.toString();
  return queryString ? `?${queryString}` : "";
};

const normalizeInput = (input: UpsertSupplierInput) => ({
  ...input,
  name: input.name.trim(),
  contactName: input.contactName.trim(),
  email: input.email.trim().toLowerCase(),
  phone: input.phone.trim(),
  notes: input.notes?.trim() || null,
  items:
    input.items?.map((item) => ({
      itemId: item.itemId,
      supplierSku: item.supplierSku.trim().toUpperCase(),
    })) ?? [],
});

export const suppliersApi = {
  list(token: string, filters: SupplierFilters) {
    return apiClient.request<Supplier[]>(`/suppliers${buildQueryString(filters)}`, {
      token,
    });
  },
  create(token: string, input: UpsertSupplierInput) {
    return apiClient.request<Supplier>("/suppliers", {
      method: "POST",
      body: normalizeInput(input),
      token,
    });
  },
  update(token: string, supplierId: string, input: UpsertSupplierInput) {
    return apiClient.request<Supplier>(`/suppliers/${supplierId}`, {
      method: "PUT",
      body: normalizeInput(input),
      token,
    });
  },
  setStatus(token: string, supplierId: string, isActive: boolean) {
    return apiClient.request<Supplier>(`/suppliers/${supplierId}/status`, {
      method: "PATCH",
      body: { isActive },
      token,
    });
  },
};
