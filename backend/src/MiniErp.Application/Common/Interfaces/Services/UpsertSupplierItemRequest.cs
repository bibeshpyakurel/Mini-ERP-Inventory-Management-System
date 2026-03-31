namespace MiniErp.Application.Common.Interfaces.Services;

public sealed record UpsertSupplierItemRequest(Guid ItemId, string SupplierSku);
