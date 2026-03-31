export type AuditLogEntry = {
  id: string;
  action: string;
  entityName: string;
  entityId?: string | null;
  performedByUserId: string;
  performedAt: string;
  details: string;
};
