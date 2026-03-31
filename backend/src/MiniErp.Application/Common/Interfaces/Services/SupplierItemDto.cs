namespace MiniErp.Application.Common.Interfaces.Services;

public sealed record SupplierItemDto(
    Guid ItemId,
    string ItemName,
    string ItemSku,
    string SupplierSku);
