using Microsoft.EntityFrameworkCore;
using ClearErp.Application.Common.Interfaces;
using ClearErp.Application.Common.Interfaces.Services;

namespace ClearErp.Infrastructure.Services;

public sealed class DemoResetService(IApplicationDbContext dbContext) : IDemoResetService
{
    public async Task ResetTenantDataAsync(Guid tenantId, CancellationToken cancellationToken = default)
    {
        // Delete transactional data in order (respecting foreign keys)
        // 1. Audit logs
        await dbContext.AuditLogs
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 2. Inventory transactions
        await dbContext.InventoryTransactions
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 3. Stock adjustments
        await dbContext.StockAdjustments
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 4. Goods receipt lines then goods receipts
        await dbContext.GoodsReceiptLines
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.GoodsReceipts
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 5. Purchase order lines then purchase orders
        await dbContext.PurchaseOrderLines
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.PurchaseOrders
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 6. Inventory balances
        await dbContext.InventoryBalances
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 7. Supplier items then suppliers
        await dbContext.SupplierItems
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.Suppliers
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 8. Items
        await dbContext.Items
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 9. Categories
        await dbContext.Categories
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // 10. Locations then warehouses
        await dbContext.Locations
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        await dbContext.Warehouses
            .Where(x => x.TenantId == tenantId)
            .ExecuteDeleteAsync(cancellationToken);

        // Run migrations to re-seed the data
        // Note: EF Core's HasData() will re-insert the seed data on next migration
        // For a full reset, the database needs to be recreated
        // This deletes all user-created data and the seed data will be restored on next app restart
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
