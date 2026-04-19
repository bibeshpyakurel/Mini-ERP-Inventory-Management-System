import { apiClient } from "../../api/client";

export type LocationOption = {
  id: string;
  name: string;
  code: string;
};

export type WarehouseOption = {
  id: string;
  name: string;
  code: string;
  locations: LocationOption[];
};

export const warehousesApi = {
  list(token: string) {
    return apiClient.request<WarehouseOption[]>("/warehouses", { token });
  },
};
