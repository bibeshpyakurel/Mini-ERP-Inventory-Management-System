import { apiClient } from "../../api/client";
import type { AuditLogEntry } from "./types";

export const auditLogsApi = {
  list(token: string) {
    return apiClient.request<AuditLogEntry[]>("/audit-logs", { token });
  },
};
