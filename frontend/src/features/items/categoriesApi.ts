import { apiClient } from "../../api/client";

export type CategoryOption = {
  id: string;
  name: string;
};

export const categoriesApi = {
  list(token: string) {
    return apiClient.request<CategoryOption[]>("/categories", { token });
  },
};
