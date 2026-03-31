using MiniErp.Domain.Enums;

namespace MiniErp.Application.Common.Interfaces.Services;

public sealed record PurchaseOrderFilter(Guid? SupplierId, PurchaseOrderStatus? Status);
