import { apiClient } from "../../api/client";
import type { Item, ItemFilters, ItemStatusInput, UpsertItemInput } from "./types";

const buildQueryString = (filters: ItemFilters) => {
  const params = new URLSearchParams();

  if (filters.search) {
    params.set("search", filters.search);
  }

  if (filters.categoryId) {
    params.set("categoryId", filters.categoryId);
  }

  if (typeof filters.isActive === "boolean") {
    params.set("isActive", String(filters.isActive));
  }

  const queryString = params.toString();
  return queryString ? `?${queryString}` : "";
};

export const itemsApi = {
  list(token: string, filters: ItemFilters) {
    return apiClient.request<Item[]>(`/items${buildQueryString(filters)}`, {
      token,
    });
  },
  create(token: string, input: UpsertItemInput) {
    return apiClient.request<Item>("/items", {
      method: "POST",
      body: {
        ...input,
        description: input.description?.trim() || null,
      },
      token,
    });
  },
  update(token: string, itemId: string, input: UpsertItemInput) {
    return apiClient.request<Item>(`/items/${itemId}`, {
      method: "PUT",
      body: {
        ...input,
        description: input.description?.trim() || null,
      },
      token,
    });
  },
  setStatus(token: string, itemId: string, input: ItemStatusInput) {
    return apiClient.request<Item>(`/items/${itemId}/status`, {
      method: "PATCH",
      body: input,
      token,
    });
  },
};
