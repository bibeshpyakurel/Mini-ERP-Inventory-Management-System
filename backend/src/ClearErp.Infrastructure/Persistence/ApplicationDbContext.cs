using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ClearErp.Application.Common.Interfaces;
using ClearErp.Domain.Common;
using ClearErp.Domain.Entities;
using ClearErp.Infrastructure.Persistence.Seeding;

namespace ClearErp.Infrastructure.Persistence;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    ITenantContext tenantContext)
    : DbContext(options), IApplicationDbContext
{
    // Exposed as a property so Expression.Constant(this) + Expression.Property(…, nameof(TenantCtx))
    // lets EF Core's DbContextReplacingExpressionVisitor swap in the *current* DbContext
    // instance per-query, giving the correct scoped ITenantContext (and thus the correct
    // tenant ID) rather than the startup-time instance that had no HTTP context.
    private ITenantContext TenantCtx { get; } = tenantContext;

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<GoodsReceipt> GoodsReceipts => Set<GoodsReceipt>();
    public DbSet<GoodsReceiptLine> GoodsReceiptLines => Set<GoodsReceiptLine>();
    public DbSet<InventoryBalance> InventoryBalances => Set<InventoryBalance>();
    public DbSet<InventoryTransaction> InventoryTransactions => Set<InventoryTransaction>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<StockAdjustment> StockAdjustments => Set<StockAdjustment>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<SupplierItem> SupplierItems => Set<SupplierItem>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<User> Users => Set<User>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Apply tenant filter to all TenantEntity-derived types.
        // When TenantId is null (migrations, background jobs, seeding) the filter is bypassed.
        //
        // IMPORTANT: we must NOT use Expression.Constant(tenantContext) here.
        // OnModelCreating is called once at startup (during MigrateAsync) when there is
        // no HTTP context, so tenantContext.TenantId == null at that point. EF Core would
        // bake that null into the compiled query cache and the filter would always be WHERE TRUE,
        // leaking every tenant's data to every user.
        //
        // Instead we route through Expression.Constant(this) → TenantCtx → TenantId.
        // EF Core's DbContextReplacingExpressionVisitor replaces the captured DbContext
        // constant with the *current* DbContext instance at query-execution time, so
        // TenantCtx returns the scoped ITenantContext for the live HTTP request.
        var tenantCtxProperty = typeof(ApplicationDbContext).GetProperty(
            nameof(TenantCtx), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!;

        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(t => typeof(TenantEntity).IsAssignableFrom(t.ClrType)))
        {
            var parameter = Expression.Parameter(entityType.ClrType, "e");
            var tenantIdProperty = Expression.Property(parameter, nameof(TenantEntity.TenantId));
            var tenantContextTenantId = Expression.Property(
                Expression.Property(Expression.Constant(this), tenantCtxProperty),
                nameof(ITenantContext.TenantId));
            var hasNoTenant = Expression.Equal(tenantContextTenantId, Expression.Constant(null, typeof(Guid?)));
            var tenantMatches = Expression.Equal(
                Expression.Convert(tenantIdProperty, typeof(Guid?)),
                tenantContextTenantId);
            var filter = Expression.Lambda(Expression.OrElse(hasNoTenant, tenantMatches), parameter);
            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
        }

        modelBuilder.ApplySeedData();
    }
}
