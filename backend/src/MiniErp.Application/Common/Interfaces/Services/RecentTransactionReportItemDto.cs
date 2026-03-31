using MiniErp.Domain.Enums;

namespace MiniErp.Application.Common.Interfaces.Services;

public sealed record RecentTransactionReportItemDto(
    Guid TransactionId,
    Guid ItemId,
    string ItemSku,
    string ItemName,
    InventoryTransactionType TransactionType,
    int QuantityChange,
    int BalanceAfter,
    string ReferenceType,
    string? Reason,
    DateTime PerformedAt);
