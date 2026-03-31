using System.ComponentModel.DataAnnotations;

namespace MiniErp.Api.Contracts.PurchaseOrders;

public sealed record UpdatePurchaseOrderRequest(
    [property: Required] Guid SupplierId,
    [property: Required] DateTime OrderDate,
    DateTime? ExpectedDate,
    [property: MinLength(1)] IReadOnlyCollection<PurchaseOrderLineRequest> Lines);
