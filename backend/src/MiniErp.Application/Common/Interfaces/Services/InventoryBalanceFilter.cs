namespace MiniErp.Application.Common.Interfaces.Services;

public sealed record InventoryBalanceFilter(Guid? ItemId, Guid? WarehouseId);
