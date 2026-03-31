using MiniErp.Domain.Enums;

namespace MiniErp.Application.Common.Interfaces.Services;

public sealed record InventoryTransactionFilter(
    DateTime? FromDateUtc,
    DateTime? ToDateUtc,
    Guid? ItemId,
    Guid? WarehouseId,
    InventoryTransactionType? TransactionType);
