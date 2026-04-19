using Microsoft.EntityFrameworkCore;
using ClearErp.Domain.Entities;
using ClearErp.Domain.Enums;

namespace ClearErp.Infrastructure.Persistence.Seeding;

public static class ModelBuilderExtensions
{
    public static void ApplySeedData(this ModelBuilder modelBuilder)
    {
        var seedCreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // ── Tenants ─────────────────────────────────────────────────────────
        modelBuilder.Entity<Tenant>().HasData(
            new Tenant
            {
                Id = SeedConstants.FurnitureTenantId,
                Name = "ClearFurniture Corp",
                Slug = "furniture",
                Industry = "Furniture",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new Tenant
            {
                Id = SeedConstants.ElectronicsTenantId,
                Name = "TechFlow Electronics",
                Slug = "electronics",
                Industry = "Electronics",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new Tenant
            {
                Id = SeedConstants.FoodBeverageTenantId,
                Name = "FreshFoods Co",
                Slug = "food-beverage",
                Industry = "Food & Beverage",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new Tenant
            {
                Id = SeedConstants.SaasTenantId,
                Name = "CloudPeak SaaS",
                Slug = "saas",
                Industry = "SaaS / Cloud",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new Tenant
            {
                Id = SeedConstants.ItServicesTenantId,
                Name = "NetBridge IT Services",
                Slug = "it-services",
                Industry = "IT Services",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new Tenant
            {
                Id = SeedConstants.CyberTenantId,
                Name = "ShieldCore Cybersecurity",
                Slug = "cybersecurity",
                Industry = "Cybersecurity",
                IsActive = true,
                CreatedAt = seedCreatedAt
            });

        // ── Roles (global) ───────────────────────────────────────────────────
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = SeedConstants.AdminRoleId, Name = RoleName.Admin.ToString(), CreatedAt = seedCreatedAt },
            new Role { Id = SeedConstants.InventoryManagerRoleId, Name = RoleName.InventoryManager.ToString(), CreatedAt = seedCreatedAt },
            new Role { Id = SeedConstants.WarehouseStaffRoleId, Name = RoleName.WarehouseStaff.ToString(), CreatedAt = seedCreatedAt },
            new Role { Id = SeedConstants.ViewerRoleId, Name = RoleName.Viewer.ToString(), CreatedAt = seedCreatedAt });

        // ════════════════════════════════════════════════════════════════════
        // FURNITURE TENANT
        // ════════════════════════════════════════════════════════════════════

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = SeedConstants.AdminUserId,
                TenantId = SeedConstants.FurnitureTenantId,
                Email = "admin@clearfurniture.local",
                PasswordHash = "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=",
                FullName = "System Administrator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new User
            {
                Id = SeedConstants.WarehouseUserId,
                TenantId = SeedConstants.FurnitureTenantId,
                Email = "warehouse@clearfurniture.local",
                PasswordHash = "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=",
                FullName = "Warehouse Operator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },

        // ── Electronics tenant users ────────────────────────────────────────
            new User
            {
                Id = SeedConstants.ElecAdminUserId,
                TenantId = SeedConstants.ElectronicsTenantId,
                Email = "admin@techflow-electronics.local",
                PasswordHash = "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=",
                FullName = "Electronics Administrator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new User
            {
                Id = SeedConstants.ElecWarehouseUserId,
                TenantId = SeedConstants.ElectronicsTenantId,
                Email = "warehouse@techflow-electronics.local",
                PasswordHash = "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=",
                FullName = "Electronics Warehouse Staff",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },

        // ── Food & Beverage tenant users ────────────────────────────────────
            new User
            {
                Id = SeedConstants.FoodAdminUserId,
                TenantId = SeedConstants.FoodBeverageTenantId,
                Email = "admin@freshfoods.local",
                PasswordHash = "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=",
                FullName = "Food & Beverage Administrator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new User
            {
                Id = SeedConstants.FoodWarehouseUserId,
                TenantId = SeedConstants.FoodBeverageTenantId,
                Email = "warehouse@freshfoods.local",
                PasswordHash = "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=",
                FullName = "Food & Beverage Warehouse Staff",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },

        // ── SaaS tenant users ───────────────────────────────────────────────
            new User
            {
                Id = SeedConstants.SaasAdminUserId,
                TenantId = SeedConstants.SaasTenantId,
                Email = "admin@cloudpeak.local",
                PasswordHash = "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=",
                FullName = "CloudPeak Administrator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new User
            {
                Id = SeedConstants.SaasWarehouseUserId,
                TenantId = SeedConstants.SaasTenantId,
                Email = "warehouse@cloudpeak.local",
                PasswordHash = "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=",
                FullName = "CloudPeak Warehouse Staff",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },

        // ── IT Services tenant users ─────────────────────────────────────────
            new User
            {
                Id = SeedConstants.ItAdminUserId,
                TenantId = SeedConstants.ItServicesTenantId,
                Email = "admin@netbridge.local",
                PasswordHash = "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=",
                FullName = "NetBridge Administrator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new User
            {
                Id = SeedConstants.ItWarehouseUserId,
                TenantId = SeedConstants.ItServicesTenantId,
                Email = "warehouse@netbridge.local",
                PasswordHash = "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=",
                FullName = "NetBridge Warehouse Staff",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },

        // ── Cybersecurity tenant users ───────────────────────────────────────
            new User
            {
                Id = SeedConstants.CyberAdminUserId,
                TenantId = SeedConstants.CyberTenantId,
                Email = "admin@shieldcore.local",
                PasswordHash = "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=",
                FullName = "ShieldCore Administrator",
                IsActive = true,
                CreatedAt = seedCreatedAt
            },
            new User
            {
                Id = SeedConstants.CyberWarehouseUserId,
                TenantId = SeedConstants.CyberTenantId,
                Email = "warehouse@shieldcore.local",
                PasswordHash = "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=",
                FullName = "ShieldCore Warehouse Staff",
                IsActive = true,
                CreatedAt = seedCreatedAt
            });

        modelBuilder.Entity<UserRole>().HasData(
            new UserRole { UserId = SeedConstants.AdminUserId,         RoleId = SeedConstants.AdminRoleId },
            new UserRole { UserId = SeedConstants.WarehouseUserId,     RoleId = SeedConstants.WarehouseStaffRoleId },
            new UserRole { UserId = SeedConstants.ElecAdminUserId,     RoleId = SeedConstants.AdminRoleId },
            new UserRole { UserId = SeedConstants.ElecWarehouseUserId, RoleId = SeedConstants.WarehouseStaffRoleId },
            new UserRole { UserId = SeedConstants.FoodAdminUserId,     RoleId = SeedConstants.AdminRoleId },
            new UserRole { UserId = SeedConstants.FoodWarehouseUserId, RoleId = SeedConstants.WarehouseStaffRoleId },
            new UserRole { UserId = SeedConstants.SaasAdminUserId,     RoleId = SeedConstants.AdminRoleId },
            new UserRole { UserId = SeedConstants.SaasWarehouseUserId, RoleId = SeedConstants.WarehouseStaffRoleId },
            new UserRole { UserId = SeedConstants.ItAdminUserId,       RoleId = SeedConstants.AdminRoleId },
            new UserRole { UserId = SeedConstants.ItWarehouseUserId,   RoleId = SeedConstants.WarehouseStaffRoleId },
            new UserRole { UserId = SeedConstants.CyberAdminUserId,    RoleId = SeedConstants.AdminRoleId },
            new UserRole { UserId = SeedConstants.CyberWarehouseUserId, RoleId = SeedConstants.WarehouseStaffRoleId });

        // ── Categories ───────────────────────────────────────────────────────
        modelBuilder.Entity<Category>().HasData(
            // Furniture
            new Category { Id = SeedConstants.SeatingCategoryId,    TenantId = SeedConstants.FurnitureTenantId,    Name = "Seating",    CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.StorageCategoryId,    TenantId = SeedConstants.FurnitureTenantId,    Name = "Storage",    CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.ComponentsCategoryId, TenantId = SeedConstants.FurnitureTenantId,    Name = "Components", CreatedAt = seedCreatedAt },
            // Electronics
            new Category { Id = SeedConstants.ElecDisplaysCategoryId,   TenantId = SeedConstants.ElectronicsTenantId, Name = "Displays",    CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.ElecNetworkingCategoryId, TenantId = SeedConstants.ElectronicsTenantId, Name = "Networking",   CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.ElecComputeCategoryId,    TenantId = SeedConstants.ElectronicsTenantId, Name = "Compute",      CreatedAt = seedCreatedAt },
            // Food & Beverage
            new Category { Id = SeedConstants.FoodDryGoodsCategoryId,    TenantId = SeedConstants.FoodBeverageTenantId, Name = "Dry Goods",          CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.FoodRefrigeratedCategoryId, TenantId = SeedConstants.FoodBeverageTenantId, Name = "Refrigerated",       CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.FoodPackagingCategoryId,   TenantId = SeedConstants.FoodBeverageTenantId, Name = "Packaging",          CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new Category { Id = SeedConstants.SaasLicensesCategoryId,    TenantId = SeedConstants.SaasTenantId,         Name = "Software Licenses",  CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.SaasDevHardwareCategoryId, TenantId = SeedConstants.SaasTenantId,         Name = "Dev Hardware",        CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.SaasCloudInfraCategoryId,  TenantId = SeedConstants.SaasTenantId,         Name = "Cloud Infra",         CreatedAt = seedCreatedAt },
            // IT Services
            new Category { Id = SeedConstants.ItNetworkingCategoryId,    TenantId = SeedConstants.ItServicesTenantId,   Name = "Networking",          CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.ItEndUserDevCategoryId,    TenantId = SeedConstants.ItServicesTenantId,   Name = "End-User Devices",    CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.ItPeripheralsCategoryId,   TenantId = SeedConstants.ItServicesTenantId,   Name = "Peripherals",         CreatedAt = seedCreatedAt },
            // Cybersecurity
            new Category { Id = SeedConstants.CyberAppliancesCategoryId,  TenantId = SeedConstants.CyberTenantId,       Name = "Security Appliances", CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.CyberIdentityCategoryId,    TenantId = SeedConstants.CyberTenantId,       Name = "Identity & Access",   CreatedAt = seedCreatedAt },
            new Category { Id = SeedConstants.CyberThreatIntelCategoryId, TenantId = SeedConstants.CyberTenantId,       Name = "Threat Intel",        CreatedAt = seedCreatedAt });

        // ── Suppliers ────────────────────────────────────────────────────────
        modelBuilder.Entity<Supplier>().HasData(
            // Furniture
            new Supplier { Id = SeedConstants.AcmeSupplierId,      TenantId = SeedConstants.FurnitureTenantId, Name = "Acme Industrial Supply",      ContactName = "Jordan Lee",    Email = "orders@acme-industrial.example",    Phone = "555-0100", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.NorthwoodSupplierId,  TenantId = SeedConstants.FurnitureTenantId, Name = "Northwood Components",         ContactName = "Taylor Smith",  Email = "sales@northwood.example",          Phone = "555-0110", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.EastlakeSupplierId,   TenantId = SeedConstants.FurnitureTenantId, Name = "Eastlake Office Furnishings",  ContactName = "Morgan Patel",  Email = "account-team@eastlake.example",    Phone = "555-0120", IsActive = true, CreatedAt = seedCreatedAt },
            // Electronics
            new Supplier { Id = SeedConstants.TechSourceSupplierId, TenantId = SeedConstants.ElectronicsTenantId, Name = "TechSource Global",           ContactName = "Alex Kim",      Email = "supply@techsource.example",        Phone = "555-0200", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.DigiPartsSupplierId,   TenantId = SeedConstants.ElectronicsTenantId, Name = "DigiParts Distribution",      ContactName = "Sam Rivera",    Email = "orders@digiparts.example",         Phone = "555-0210", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.NovaTechSupplierId,    TenantId = SeedConstants.ElectronicsTenantId, Name = "NovaTech Components",         ContactName = "Jamie Chen",    Email = "sales@novatech.example",           Phone = "555-0220", IsActive = true, CreatedAt = seedCreatedAt },
            // Food & Beverage
            new Supplier { Id = SeedConstants.FarmFreshSupplierId,  TenantId = SeedConstants.FoodBeverageTenantId, Name = "FarmFresh Direct",            ContactName = "Casey Brown",   Email = "orders@farmfresh.example",      Phone = "555-0300", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.PackWorldSupplierId,   TenantId = SeedConstants.FoodBeverageTenantId, Name = "PackWorld Supplies",          ContactName = "Drew Wilson",   Email = "supply@packworld.example",      Phone = "555-0310", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.BeverageCoSupplierId,  TenantId = SeedConstants.FoodBeverageTenantId, Name = "BeverageCo International",   ContactName = "Riley Garcia",  Email = "trade@beverageco.example",      Phone = "555-0320", IsActive = true, CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new Supplier { Id = SeedConstants.LicenseHubSupplierId,  TenantId = SeedConstants.SaasTenantId,         Name = "LicenseHub Global",           ContactName = "Avery Zhang",   Email = "orders@licensehub.example",     Phone = "555-0400", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.DevGearProSupplierId,   TenantId = SeedConstants.SaasTenantId,         Name = "DevGear Pro",                 ContactName = "Jordan Miles",  Email = "sales@devgearpro.example",      Phone = "555-0410", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.CloudStackSupplierId,   TenantId = SeedConstants.SaasTenantId,         Name = "CloudStack Hardware",         ContactName = "Morgan Tran",   Email = "trade@cloudstack.example",      Phone = "555-0420", IsActive = true, CreatedAt = seedCreatedAt },
            // IT Services
            new Supplier { Id = SeedConstants.NetCoreSupplierId,     TenantId = SeedConstants.ItServicesTenantId,   Name = "NetCore Distribution",        ContactName = "Taylor Reyes",  Email = "orders@netcore.example",        Phone = "555-0500", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.DeviceMaxSupplierId,    TenantId = SeedConstants.ItServicesTenantId,   Name = "DeviceMax Wholesale",         ContactName = "Alex Park",     Email = "supply@devicemax.example",      Phone = "555-0510", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.AccePartsSupplierId,    TenantId = SeedConstants.ItServicesTenantId,   Name = "AcceParts Direct",            ContactName = "Sam Ortega",    Email = "sales@acceparts.example",       Phone = "555-0520", IsActive = true, CreatedAt = seedCreatedAt },
            // Cybersecurity
            new Supplier { Id = SeedConstants.FortiTechSupplierId,   TenantId = SeedConstants.CyberTenantId,        Name = "FortiTech Systems",           ContactName = "Jamie Nguyen",  Email = "orders@fortitech.example",      Phone = "555-0600", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.ZeroTrustSupplierId,    TenantId = SeedConstants.CyberTenantId,        Name = "ZeroTrust Solutions",         ContactName = "Riley Hassan",  Email = "supply@zerotrust.example",      Phone = "555-0610", IsActive = true, CreatedAt = seedCreatedAt },
            new Supplier { Id = SeedConstants.SecureKeySupplierId,    TenantId = SeedConstants.CyberTenantId,        Name = "SecureKey Technologies",      ContactName = "Drew Okafor",   Email = "sales@securekey.example",       Phone = "555-0620", IsActive = true, CreatedAt = seedCreatedAt });

        // ── Warehouses ───────────────────────────────────────────────────────
        modelBuilder.Entity<Warehouse>().HasData(
            new Warehouse { Id = SeedConstants.MainWarehouseId, TenantId = SeedConstants.FurnitureTenantId,    Name = "Main Warehouse",            Code = "MAIN",  CreatedAt = seedCreatedAt },
            new Warehouse { Id = SeedConstants.ElecWarehouseId, TenantId = SeedConstants.ElectronicsTenantId, Name = "Electronics Warehouse",     Code = "ELEC",  CreatedAt = seedCreatedAt },
            new Warehouse { Id = SeedConstants.FoodWarehouseId, TenantId = SeedConstants.FoodBeverageTenantId, Name = "Cold Storage Warehouse",   Code = "COLD",  CreatedAt = seedCreatedAt },
            new Warehouse { Id = SeedConstants.SaasWarehouseId, TenantId = SeedConstants.SaasTenantId,         Name = "CloudPeak HQ Stockroom",   Code = "SAAS",  CreatedAt = seedCreatedAt },
            new Warehouse { Id = SeedConstants.ItWarehouseId,   TenantId = SeedConstants.ItServicesTenantId,   Name = "NetBridge IT Store",       Code = "ITST",  CreatedAt = seedCreatedAt },
            new Warehouse { Id = SeedConstants.CyberWarehouseId, TenantId = SeedConstants.CyberTenantId,       Name = "ShieldCore Secure Store",  Code = "SCSS",  CreatedAt = seedCreatedAt });

        // ── Locations ────────────────────────────────────────────────────────
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = SeedConstants.MainAisleLocationId, TenantId = SeedConstants.FurnitureTenantId,    WarehouseId = SeedConstants.MainWarehouseId,  Name = "Aisle A1",    Code = "A1",  CreatedAt = seedCreatedAt },
            new Location { Id = SeedConstants.ElecLocationId,      TenantId = SeedConstants.ElectronicsTenantId, WarehouseId = SeedConstants.ElecWarehouseId,  Name = "Rack B1",     Code = "B1",  CreatedAt = seedCreatedAt },
            new Location { Id = SeedConstants.FoodLocationId,      TenantId = SeedConstants.FoodBeverageTenantId, WarehouseId = SeedConstants.FoodWarehouseId, Name = "Bay C1",      Code = "C1",  CreatedAt = seedCreatedAt },
            new Location { Id = SeedConstants.SaasLocationId,      TenantId = SeedConstants.SaasTenantId,         WarehouseId = SeedConstants.SaasWarehouseId,  Name = "Rack S1",     Code = "S1",  CreatedAt = seedCreatedAt },
            new Location { Id = SeedConstants.ItLocationId,        TenantId = SeedConstants.ItServicesTenantId,   WarehouseId = SeedConstants.ItWarehouseId,    Name = "Rack N1",     Code = "N1",  CreatedAt = seedCreatedAt },
            new Location { Id = SeedConstants.CyberLocationId,     TenantId = SeedConstants.CyberTenantId,        WarehouseId = SeedConstants.CyberWarehouseId, Name = "Vault V1",    Code = "V1",  CreatedAt = seedCreatedAt });

        // ── Items ────────────────────────────────────────────────────────────
        modelBuilder.Entity<Item>().HasData(
            // Furniture
            new Item { Id = SeedConstants.TaskChairItemId,           TenantId = SeedConstants.FurnitureTenantId, CategoryId = SeedConstants.SeatingCategoryId,    Sku = "CHR-1001", Name = "Task Chair",           Description = "Adjustable office task chair",                   Unit = "EA",  ReorderLevel = 10, StandardCost = 129.99m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.FilingCabinetItemId,       TenantId = SeedConstants.FurnitureTenantId, CategoryId = SeedConstants.StorageCategoryId,    Sku = "CAB-2001", Name = "Filing Cabinet",       Description = "Three-drawer steel filing cabinet",              Unit = "EA",  ReorderLevel = 5,  StandardCost = 249.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.DeskLegKitItemId,          TenantId = SeedConstants.FurnitureTenantId, CategoryId = SeedConstants.ComponentsCategoryId, Sku = "KIT-3001", Name = "Desk Leg Kit",         Description = "Set of four metal desk legs",                    Unit = "SET", ReorderLevel = 20, StandardCost = 58.50m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.LoungeChairItemId,         TenantId = SeedConstants.FurnitureTenantId, CategoryId = SeedConstants.SeatingCategoryId,    Sku = "LNG-4001", Name = "Lounge Chair",         Description = "Soft seating lounge chair for waiting areas",    Unit = "EA",  ReorderLevel = 6,  StandardCost = 219.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.MobilePedestalItemId,      TenantId = SeedConstants.FurnitureTenantId, CategoryId = SeedConstants.StorageCategoryId,    Sku = "PED-5001", Name = "Mobile Pedestal",      Description = "Lockable under-desk storage pedestal",           Unit = "EA",  ReorderLevel = 8,  StandardCost = 179.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.ConferenceTableBaseItemId, TenantId = SeedConstants.FurnitureTenantId, CategoryId = SeedConstants.ComponentsCategoryId, Sku = "BAS-6001", Name = "Conference Table Base", Description = "Powder-coated steel base for conference tables",  Unit = "EA",  ReorderLevel = 4,  StandardCost = 84.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            // Electronics
            new Item { Id = SeedConstants.MonitorItemId, TenantId = SeedConstants.ElectronicsTenantId, CategoryId = SeedConstants.ElecDisplaysCategoryId,   Sku = "MON-2001", Name = "27\" Monitor",         Description = "27-inch 4K IPS display",                         Unit = "EA",  ReorderLevel = 8,  StandardCost = 349.99m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.SwitchItemId,  TenantId = SeedConstants.ElectronicsTenantId, CategoryId = SeedConstants.ElecNetworkingCategoryId, Sku = "SWT-2002", Name = "24-Port Switch",       Description = "Managed 24-port gigabit network switch",         Unit = "EA",  ReorderLevel = 5,  StandardCost = 499.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.ServerItemId,  TenantId = SeedConstants.ElectronicsTenantId, CategoryId = SeedConstants.ElecComputeCategoryId,    Sku = "SRV-2003", Name = "Rack Server 1U",       Description = "1U rack-mount server, 16-core, 64 GB RAM",       Unit = "EA",  ReorderLevel = 3,  StandardCost = 2499.00m,IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.UsbHubItemId,  TenantId = SeedConstants.ElectronicsTenantId, CategoryId = SeedConstants.ElecNetworkingCategoryId, Sku = "HUB-2004", Name = "USB-C Hub 7-Port",     Description = "7-port USB-C docking hub",                       Unit = "EA",  ReorderLevel = 15, StandardCost = 69.99m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.LaptopItemId,  TenantId = SeedConstants.ElectronicsTenantId, CategoryId = SeedConstants.ElecComputeCategoryId,    Sku = "LPT-2005", Name = "Business Laptop",      Description = "14-inch business laptop, i7, 16 GB RAM",         Unit = "EA",  ReorderLevel = 5,  StandardCost = 1199.00m,IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.WebcamItemId,  TenantId = SeedConstants.ElectronicsTenantId, CategoryId = SeedConstants.ElecDisplaysCategoryId,   Sku = "CAM-2006", Name = "HD Webcam",            Description = "1080p USB webcam with built-in mic",             Unit = "EA",  ReorderLevel = 12, StandardCost = 89.99m,  IsActive = true, CreatedAt = seedCreatedAt },
            // Food & Beverage
            new Item { Id = SeedConstants.FlourItemId,       TenantId = SeedConstants.FoodBeverageTenantId, CategoryId = SeedConstants.FoodDryGoodsCategoryId,     Sku = "FLR-4001", Name = "Wheat Flour",          Description = "All-purpose wheat flour, 25 kg sack",            Unit = "KG",  ReorderLevel = 500, StandardCost = 0.85m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.OliveOilItemId,    TenantId = SeedConstants.FoodBeverageTenantId, CategoryId = SeedConstants.FoodRefrigeratedCategoryId,  Sku = "OIL-4002", Name = "Extra Virgin Olive Oil", Description = "Cold-pressed EVOO, 5-litre tin",                Unit = "LTR", ReorderLevel = 100, StandardCost = 8.50m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.KraftBoxItemId,    TenantId = SeedConstants.FoodBeverageTenantId, CategoryId = SeedConstants.FoodPackagingCategoryId,    Sku = "BOX-4003", Name = "Kraft Shipping Box",   Description = "Double-wall kraft box 30x20x15 cm",              Unit = "EA",  ReorderLevel = 1000, StandardCost = 0.45m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.WaterBottleItemId, TenantId = SeedConstants.FoodBeverageTenantId, CategoryId = SeedConstants.FoodPackagingCategoryId,    Sku = "BTL-4004", Name = "500ml PET Bottle",     Description = "BPA-free PET water bottle, carton of 24",        Unit = "CTN", ReorderLevel = 200, StandardCost = 4.20m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.SugarItemId,       TenantId = SeedConstants.FoodBeverageTenantId, CategoryId = SeedConstants.FoodDryGoodsCategoryId,     Sku = "SGR-4005", Name = "Cane Sugar",           Description = "Refined white cane sugar, 50 kg bag",            Unit = "KG",  ReorderLevel = 300, StandardCost = 0.72m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.RiceItemId,        TenantId = SeedConstants.FoodBeverageTenantId, CategoryId = SeedConstants.FoodDryGoodsCategoryId,     Sku = "RCE-4006", Name = "Long Grain Rice",        Description = "Premium long-grain white rice, 25 kg sack",       Unit = "KG",  ReorderLevel = 400, StandardCost = 1.10m,    IsActive = true, CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new Item { Id = SeedConstants.VsLicenseItemId,    TenantId = SeedConstants.SaasTenantId, CategoryId = SeedConstants.SaasLicensesCategoryId,    Sku = "LIC-6001", Name = "Visual Studio License",  Description = "VS Enterprise annual subscription seat",          Unit = "EA",  ReorderLevel = 5,   StandardCost = 549.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.JbPackItemId,       TenantId = SeedConstants.SaasTenantId, CategoryId = SeedConstants.SaasLicensesCategoryId,    Sku = "LIC-6002", Name = "JetBrains All Pack",     Description = "JetBrains All Products Pack annual license",       Unit = "EA",  ReorderLevel = 5,   StandardCost = 779.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.MacBookProItemId,   TenantId = SeedConstants.SaasTenantId, CategoryId = SeedConstants.SaasDevHardwareCategoryId, Sku = "HW-6003",  Name = "MacBook Pro 14\"",       Description = "Apple M3 Pro MacBook Pro 14-inch, 18 GB RAM",      Unit = "EA",  ReorderLevel = 3,   StandardCost = 1999.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.MechKeyboardItemId, TenantId = SeedConstants.SaasTenantId, CategoryId = SeedConstants.SaasDevHardwareCategoryId, Sku = "HW-6004",  Name = "Mech Keyboard",          Description = "Mechanical keyboard, TKL layout, brown switches",  Unit = "EA",  ReorderLevel = 10,  StandardCost = 119.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.AwsInstanceItemId,  TenantId = SeedConstants.SaasTenantId, CategoryId = SeedConstants.SaasCloudInfraCategoryId,  Sku = "INF-6005", Name = "AWS Reserved Instance",  Description = "1-yr t3.large EC2 reserved instance (prepaid)",    Unit = "EA",  ReorderLevel = 2,   StandardCost = 840.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.NasStorageItemId,   TenantId = SeedConstants.SaasTenantId, CategoryId = SeedConstants.SaasCloudInfraCategoryId,  Sku = "INF-6006", Name = "NAS Storage Unit",       Description = "8-bay NAS enclosure with 4 TB drives",             Unit = "EA",  ReorderLevel = 2,   StandardCost = 1499.00m, IsActive = true, CreatedAt = seedCreatedAt },
            // IT Services
            new Item { Id = SeedConstants.CiscoRouterItemId,   TenantId = SeedConstants.ItServicesTenantId, CategoryId = SeedConstants.ItNetworkingCategoryId,    Sku = "NET-7001", Name = "Cisco ISR Router",       Description = "Cisco ISR 4321 integrated services router",        Unit = "EA",  ReorderLevel = 3,  StandardCost = 1899.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.PoeSwitchItemId,     TenantId = SeedConstants.ItServicesTenantId, CategoryId = SeedConstants.ItNetworkingCategoryId,    Sku = "NET-7002", Name = "PoE Switch 24-Port",     Description = "24-port PoE+ managed gigabit switch",              Unit = "EA",  ReorderLevel = 4,  StandardCost = 699.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.DellDesktopItemId,   TenantId = SeedConstants.ItServicesTenantId, CategoryId = SeedConstants.ItEndUserDevCategoryId,    Sku = "DEV-7003", Name = "Dell OptiPlex Desktop",  Description = "Dell OptiPlex 7010 SFF, i5, 16 GB RAM",            Unit = "EA",  ReorderLevel = 5,  StandardCost = 849.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.LaserJetItemId,      TenantId = SeedConstants.ItServicesTenantId, CategoryId = SeedConstants.ItEndUserDevCategoryId,    Sku = "DEV-7004", Name = "HP LaserJet Pro",         Description = "HP LaserJet Pro MFP M428fdn mono printer",         Unit = "EA",  ReorderLevel = 3,  StandardCost = 429.00m,  IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.MonitorStandItemId,  TenantId = SeedConstants.ItServicesTenantId, CategoryId = SeedConstants.ItPeripheralsCategoryId,   Sku = "PER-7005", Name = "Dual Monitor Stand",     Description = "Full-motion dual monitor arm desk mount",          Unit = "EA",  ReorderLevel = 8,  StandardCost = 89.00m,   IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.PatchCableItemId,    TenantId = SeedConstants.ItServicesTenantId, CategoryId = SeedConstants.ItPeripheralsCategoryId,   Sku = "PER-7006", Name = "Cat6 Patch Cable 1m",    Description = "Cat6 UTP patch cable 1 m, blue",                   Unit = "EA",  ReorderLevel = 100, StandardCost = 3.50m,   IsActive = true, CreatedAt = seedCreatedAt },
            // Cybersecurity
            new Item { Id = SeedConstants.NgFirewallItemId,      TenantId = SeedConstants.CyberTenantId, CategoryId = SeedConstants.CyberAppliancesCategoryId,  Sku = "SEC-8001", Name = "NG Firewall Appliance",  Description = "Next-gen firewall, 1 Gbps throughput",             Unit = "EA",  ReorderLevel = 2,  StandardCost = 3499.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.HwSecKeyItemId,        TenantId = SeedConstants.CyberTenantId, CategoryId = SeedConstants.CyberIdentityCategoryId,    Sku = "SEC-8002", Name = "HW Security Key",         Description = "FIDO2 hardware security key USB-A/NFC",            Unit = "EA",  ReorderLevel = 20, StandardCost = 49.00m,   IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.SiemApplianceItemId,   TenantId = SeedConstants.CyberTenantId, CategoryId = SeedConstants.CyberAppliancesCategoryId,  Sku = "SEC-8003", Name = "SIEM Appliance",          Description = "On-prem SIEM log correlation appliance",           Unit = "EA",  ReorderLevel = 1,  StandardCost = 8999.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.VpnConcentratorItemId, TenantId = SeedConstants.CyberTenantId, CategoryId = SeedConstants.CyberAppliancesCategoryId,  Sku = "SEC-8004", Name = "VPN Concentrator",        Description = "SSL VPN concentrator, 500 concurrent tunnels",     Unit = "EA",  ReorderLevel = 2,  StandardCost = 2199.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.ThreatIntelLicItemId,  TenantId = SeedConstants.CyberTenantId, CategoryId = SeedConstants.CyberThreatIntelCategoryId, Sku = "SEC-8005", Name = "Threat Intel License",    Description = "Annual threat intelligence feed subscription",     Unit = "EA",  ReorderLevel = 1,  StandardCost = 1200.00m, IsActive = true, CreatedAt = seedCreatedAt },
            new Item { Id = SeedConstants.SmartCardReaderItemId, TenantId = SeedConstants.CyberTenantId, CategoryId = SeedConstants.CyberIdentityCategoryId,    Sku = "SEC-8006", Name = "Smart Card Reader",       Description = "USB CAC/PIV smart card reader",                    Unit = "EA",  ReorderLevel = 10, StandardCost = 29.00m,   IsActive = true, CreatedAt = seedCreatedAt });

        // ── Supplier Items ───────────────────────────────────────────────────
        modelBuilder.Entity<SupplierItem>().HasData(
            // Furniture
            new SupplierItem { Id = SeedConstants.AcmeTaskChairSupplierItemId,           TenantId = SeedConstants.FurnitureTenantId,    SupplierId = SeedConstants.AcmeSupplierId,      ItemId = SeedConstants.TaskChairItemId,           SupplierSku = "ACME-CHR-1001", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.AcmeCabinetSupplierItemId,             TenantId = SeedConstants.FurnitureTenantId,    SupplierId = SeedConstants.AcmeSupplierId,      ItemId = SeedConstants.FilingCabinetItemId,       SupplierSku = "ACME-CAB-2001", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.NorthwoodDeskLegSupplierItemId,        TenantId = SeedConstants.FurnitureTenantId,    SupplierId = SeedConstants.NorthwoodSupplierId, ItemId = SeedConstants.DeskLegKitItemId,          SupplierSku = "NW-KIT-3001",   CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.EastlakeLoungeChairSupplierItemId,     TenantId = SeedConstants.FurnitureTenantId,    SupplierId = SeedConstants.EastlakeSupplierId,  ItemId = SeedConstants.LoungeChairItemId,         SupplierSku = "EL-LNG-4001",   CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.EastlakePedestalSupplierItemId,        TenantId = SeedConstants.FurnitureTenantId,    SupplierId = SeedConstants.EastlakeSupplierId,  ItemId = SeedConstants.MobilePedestalItemId,      SupplierSku = "EL-PED-5001",   CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.NorthwoodConferenceBaseSupplierItemId, TenantId = SeedConstants.FurnitureTenantId,    SupplierId = SeedConstants.NorthwoodSupplierId, ItemId = SeedConstants.ConferenceTableBaseItemId, SupplierSku = "NW-BAS-6001",   CreatedAt = seedCreatedAt },
            // Electronics
            new SupplierItem { Id = SeedConstants.ElecSupplierItemId1, TenantId = SeedConstants.ElectronicsTenantId, SupplierId = SeedConstants.TechSourceSupplierId, ItemId = SeedConstants.MonitorItemId, SupplierSku = "TS-MON-2001", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ElecSupplierItemId2, TenantId = SeedConstants.ElectronicsTenantId, SupplierId = SeedConstants.TechSourceSupplierId, ItemId = SeedConstants.ServerItemId,  SupplierSku = "TS-SRV-2003", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ElecSupplierItemId3, TenantId = SeedConstants.ElectronicsTenantId, SupplierId = SeedConstants.DigiPartsSupplierId,  ItemId = SeedConstants.SwitchItemId,  SupplierSku = "DP-SWT-2002", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ElecSupplierItemId4, TenantId = SeedConstants.ElectronicsTenantId, SupplierId = SeedConstants.DigiPartsSupplierId,  ItemId = SeedConstants.UsbHubItemId,  SupplierSku = "DP-HUB-2004", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ElecSupplierItemId5, TenantId = SeedConstants.ElectronicsTenantId, SupplierId = SeedConstants.NovaTechSupplierId,   ItemId = SeedConstants.LaptopItemId,  SupplierSku = "NT-LPT-2005", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ElecSupplierItemId6, TenantId = SeedConstants.ElectronicsTenantId, SupplierId = SeedConstants.NovaTechSupplierId,   ItemId = SeedConstants.WebcamItemId,  SupplierSku = "NT-CAM-2006", CreatedAt = seedCreatedAt },
            // Food & Beverage
            new SupplierItem { Id = SeedConstants.FoodSupplierItemId1, TenantId = SeedConstants.FoodBeverageTenantId, SupplierId = SeedConstants.FarmFreshSupplierId,  ItemId = SeedConstants.FlourItemId,       SupplierSku = "FF-FLR-4001", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.FoodSupplierItemId2, TenantId = SeedConstants.FoodBeverageTenantId, SupplierId = SeedConstants.FarmFreshSupplierId,  ItemId = SeedConstants.SugarItemId,       SupplierSku = "FF-SGR-4005", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.FoodSupplierItemId3, TenantId = SeedConstants.FoodBeverageTenantId, SupplierId = SeedConstants.BeverageCoSupplierId, ItemId = SeedConstants.OliveOilItemId,    SupplierSku = "BC-OIL-4002", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.FoodSupplierItemId4, TenantId = SeedConstants.FoodBeverageTenantId, SupplierId = SeedConstants.BeverageCoSupplierId, ItemId = SeedConstants.WaterBottleItemId, SupplierSku = "BC-BTL-4004", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.FoodSupplierItemId5, TenantId = SeedConstants.FoodBeverageTenantId, SupplierId = SeedConstants.PackWorldSupplierId,  ItemId = SeedConstants.KraftBoxItemId,    SupplierSku = "PW-BOX-4003", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.FoodSupplierItemId6, TenantId = SeedConstants.FoodBeverageTenantId, SupplierId = SeedConstants.PackWorldSupplierId,  ItemId = SeedConstants.RiceItemId,        SupplierSku = "PW-RCE-4006", CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new SupplierItem { Id = SeedConstants.SaasSupplierItemId1, TenantId = SeedConstants.SaasTenantId, SupplierId = SeedConstants.LicenseHubSupplierId, ItemId = SeedConstants.VsLicenseItemId,    SupplierSku = "LH-VS-6001",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.SaasSupplierItemId2, TenantId = SeedConstants.SaasTenantId, SupplierId = SeedConstants.LicenseHubSupplierId, ItemId = SeedConstants.JbPackItemId,       SupplierSku = "LH-JB-6002",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.SaasSupplierItemId3, TenantId = SeedConstants.SaasTenantId, SupplierId = SeedConstants.DevGearProSupplierId, ItemId = SeedConstants.MacBookProItemId,   SupplierSku = "DG-MBP-6003", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.SaasSupplierItemId4, TenantId = SeedConstants.SaasTenantId, SupplierId = SeedConstants.DevGearProSupplierId, ItemId = SeedConstants.MechKeyboardItemId, SupplierSku = "DG-KB-6004",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.SaasSupplierItemId5, TenantId = SeedConstants.SaasTenantId, SupplierId = SeedConstants.CloudStackSupplierId, ItemId = SeedConstants.AwsInstanceItemId,  SupplierSku = "CS-AWS-6005", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.SaasSupplierItemId6, TenantId = SeedConstants.SaasTenantId, SupplierId = SeedConstants.CloudStackSupplierId, ItemId = SeedConstants.NasStorageItemId,   SupplierSku = "CS-NAS-6006", CreatedAt = seedCreatedAt },
            // IT Services
            new SupplierItem { Id = SeedConstants.ItSupplierItemId1, TenantId = SeedConstants.ItServicesTenantId, SupplierId = SeedConstants.NetCoreSupplierId,  ItemId = SeedConstants.CiscoRouterItemId,  SupplierSku = "NC-CIS-7001", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ItSupplierItemId2, TenantId = SeedConstants.ItServicesTenantId, SupplierId = SeedConstants.NetCoreSupplierId,  ItemId = SeedConstants.PoeSwitchItemId,    SupplierSku = "NC-POE-7002", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ItSupplierItemId3, TenantId = SeedConstants.ItServicesTenantId, SupplierId = SeedConstants.DeviceMaxSupplierId, ItemId = SeedConstants.DellDesktopItemId,  SupplierSku = "DM-DEL-7003", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ItSupplierItemId4, TenantId = SeedConstants.ItServicesTenantId, SupplierId = SeedConstants.DeviceMaxSupplierId, ItemId = SeedConstants.LaserJetItemId,     SupplierSku = "DM-LJ-7004",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ItSupplierItemId5, TenantId = SeedConstants.ItServicesTenantId, SupplierId = SeedConstants.AccePartsSupplierId, ItemId = SeedConstants.MonitorStandItemId, SupplierSku = "AP-MS-7005",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.ItSupplierItemId6, TenantId = SeedConstants.ItServicesTenantId, SupplierId = SeedConstants.AccePartsSupplierId, ItemId = SeedConstants.PatchCableItemId,   SupplierSku = "AP-PC-7006",  CreatedAt = seedCreatedAt },
            // Cybersecurity
            new SupplierItem { Id = SeedConstants.CyberSupplierItemId1, TenantId = SeedConstants.CyberTenantId, SupplierId = SeedConstants.FortiTechSupplierId,  ItemId = SeedConstants.NgFirewallItemId,      SupplierSku = "FT-FW-8001",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.CyberSupplierItemId2, TenantId = SeedConstants.CyberTenantId, SupplierId = SeedConstants.FortiTechSupplierId,  ItemId = SeedConstants.SiemApplianceItemId,   SupplierSku = "FT-SIEM-8003",CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.CyberSupplierItemId3, TenantId = SeedConstants.CyberTenantId, SupplierId = SeedConstants.ZeroTrustSupplierId,  ItemId = SeedConstants.VpnConcentratorItemId, SupplierSku = "ZT-VPN-8004", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.CyberSupplierItemId4, TenantId = SeedConstants.CyberTenantId, SupplierId = SeedConstants.ZeroTrustSupplierId,  ItemId = SeedConstants.ThreatIntelLicItemId,  SupplierSku = "ZT-TI-8005",  CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.CyberSupplierItemId5, TenantId = SeedConstants.CyberTenantId, SupplierId = SeedConstants.SecureKeySupplierId,  ItemId = SeedConstants.HwSecKeyItemId,        SupplierSku = "SK-HSK-8002", CreatedAt = seedCreatedAt },
            new SupplierItem { Id = SeedConstants.CyberSupplierItemId6, TenantId = SeedConstants.CyberTenantId, SupplierId = SeedConstants.SecureKeySupplierId,  ItemId = SeedConstants.SmartCardReaderItemId, SupplierSku = "SK-SCR-8006", CreatedAt = seedCreatedAt });

        // ── Inventory Balances ───────────────────────────────────────────────
        modelBuilder.Entity<InventoryBalance>().HasData(
            // Furniture
            new InventoryBalance { Id = Guid.Parse("80000000-0000-0000-0000-000000000001"), TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.TaskChairItemId,           WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, QuantityOnHand = 18, QuantityReserved = 2, QuantityAvailable = 16, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("80000000-0000-0000-0000-000000000002"), TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.FilingCabinetItemId,       WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, QuantityOnHand = 4,  QuantityReserved = 1, QuantityAvailable = 3,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("80000000-0000-0000-0000-000000000003"), TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.DeskLegKitItemId,          WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, QuantityOnHand = 32, QuantityReserved = 4, QuantityAvailable = 28, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("80000000-0000-0000-0000-000000000004"), TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.LoungeChairItemId,         WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, QuantityOnHand = 5,  QuantityReserved = 3, QuantityAvailable = 2,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("80000000-0000-0000-0000-000000000005"), TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.MobilePedestalItemId,      WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, QuantityOnHand = 14, QuantityReserved = 2, QuantityAvailable = 12, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("80000000-0000-0000-0000-000000000006"), TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.ConferenceTableBaseItemId, WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, QuantityOnHand = 11, QuantityReserved = 1, QuantityAvailable = 10, CreatedAt = seedCreatedAt },
            // Electronics
            new InventoryBalance { Id = Guid.Parse("82000000-0000-0000-0000-000000000001"), TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.MonitorItemId, WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, QuantityOnHand = 25, QuantityReserved = 3, QuantityAvailable = 22, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("82000000-0000-0000-0000-000000000002"), TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.SwitchItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, QuantityOnHand = 15, QuantityReserved = 2, QuantityAvailable = 13, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("82000000-0000-0000-0000-000000000003"), TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.ServerItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, QuantityOnHand = 8,  QuantityReserved = 1, QuantityAvailable = 7,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("82000000-0000-0000-0000-000000000004"), TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.UsbHubItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, QuantityOnHand = 40, QuantityReserved = 5, QuantityAvailable = 35, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("82000000-0000-0000-0000-000000000005"), TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.LaptopItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, QuantityOnHand = 12, QuantityReserved = 2, QuantityAvailable = 10, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("82000000-0000-0000-0000-000000000006"), TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.WebcamItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, QuantityOnHand = 30, QuantityReserved = 4, QuantityAvailable = 26, CreatedAt = seedCreatedAt },
            // Food & Beverage
            new InventoryBalance { Id = Guid.Parse("84000000-0000-0000-0000-000000000001"), TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.FlourItemId,       WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, QuantityOnHand = 500,  QuantityReserved = 50,  QuantityAvailable = 450,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("84000000-0000-0000-0000-000000000002"), TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.OliveOilItemId,    WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, QuantityOnHand = 200,  QuantityReserved = 20,  QuantityAvailable = 180,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("84000000-0000-0000-0000-000000000003"), TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.KraftBoxItemId,    WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, QuantityOnHand = 1000, QuantityReserved = 100, QuantityAvailable = 900,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("84000000-0000-0000-0000-000000000004"), TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.WaterBottleItemId, WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, QuantityOnHand = 2400, QuantityReserved = 240, QuantityAvailable = 2160, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("84000000-0000-0000-0000-000000000005"), TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.SugarItemId,       WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, QuantityOnHand = 350,  QuantityReserved = 35,  QuantityAvailable = 315,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("84000000-0000-0000-0000-000000000006"), TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.RiceItemId,        WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, QuantityOnHand = 800,  QuantityReserved = 80,  QuantityAvailable = 720,  CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new InventoryBalance { Id = Guid.Parse("86000000-0000-0000-0000-000000000001"), TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.VsLicenseItemId,    WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, QuantityOnHand = 20,  QuantityReserved = 2, QuantityAvailable = 18, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("86000000-0000-0000-0000-000000000002"), TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.JbPackItemId,       WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, QuantityOnHand = 15,  QuantityReserved = 1, QuantityAvailable = 14, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("86000000-0000-0000-0000-000000000003"), TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.MacBookProItemId,   WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, QuantityOnHand = 8,   QuantityReserved = 1, QuantityAvailable = 7,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("86000000-0000-0000-0000-000000000004"), TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.MechKeyboardItemId, WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, QuantityOnHand = 25,  QuantityReserved = 3, QuantityAvailable = 22, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("86000000-0000-0000-0000-000000000005"), TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.AwsInstanceItemId,  WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, QuantityOnHand = 5,   QuantityReserved = 0, QuantityAvailable = 5,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("86000000-0000-0000-0000-000000000006"), TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.NasStorageItemId,   WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, QuantityOnHand = 4,   QuantityReserved = 0, QuantityAvailable = 4,  CreatedAt = seedCreatedAt },
            // IT Services
            new InventoryBalance { Id = Guid.Parse("87000000-0000-0000-0000-000000000001"), TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.CiscoRouterItemId,  WarehouseId = SeedConstants.ItWarehouseId, LocationId = SeedConstants.ItLocationId, QuantityOnHand = 6,   QuantityReserved = 1, QuantityAvailable = 5,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("87000000-0000-0000-0000-000000000002"), TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.PoeSwitchItemId,    WarehouseId = SeedConstants.ItWarehouseId, LocationId = SeedConstants.ItLocationId, QuantityOnHand = 10,  QuantityReserved = 2, QuantityAvailable = 8,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("87000000-0000-0000-0000-000000000003"), TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.DellDesktopItemId,  WarehouseId = SeedConstants.ItWarehouseId, LocationId = SeedConstants.ItLocationId, QuantityOnHand = 15,  QuantityReserved = 3, QuantityAvailable = 12, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("87000000-0000-0000-0000-000000000004"), TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.LaserJetItemId,     WarehouseId = SeedConstants.ItWarehouseId, LocationId = SeedConstants.ItLocationId, QuantityOnHand = 7,   QuantityReserved = 1, QuantityAvailable = 6,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("87000000-0000-0000-0000-000000000005"), TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.MonitorStandItemId, WarehouseId = SeedConstants.ItWarehouseId, LocationId = SeedConstants.ItLocationId, QuantityOnHand = 20,  QuantityReserved = 2, QuantityAvailable = 18, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("87000000-0000-0000-0000-000000000006"), TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.PatchCableItemId,   WarehouseId = SeedConstants.ItWarehouseId, LocationId = SeedConstants.ItLocationId, QuantityOnHand = 200, QuantityReserved = 0, QuantityAvailable = 200,CreatedAt = seedCreatedAt },
            // Cybersecurity
            new InventoryBalance { Id = Guid.Parse("88000000-0000-0000-0000-000000000001"), TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.NgFirewallItemId,      WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, QuantityOnHand = 4,  QuantityReserved = 1, QuantityAvailable = 3,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("88000000-0000-0000-0000-000000000002"), TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.HwSecKeyItemId,        WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, QuantityOnHand = 50, QuantityReserved = 5, QuantityAvailable = 45, CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("88000000-0000-0000-0000-000000000003"), TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.SiemApplianceItemId,   WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, QuantityOnHand = 2,  QuantityReserved = 0, QuantityAvailable = 2,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("88000000-0000-0000-0000-000000000004"), TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.VpnConcentratorItemId, WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, QuantityOnHand = 5,  QuantityReserved = 1, QuantityAvailable = 4,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("88000000-0000-0000-0000-000000000005"), TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.ThreatIntelLicItemId,  WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, QuantityOnHand = 3,  QuantityReserved = 0, QuantityAvailable = 3,  CreatedAt = seedCreatedAt },
            new InventoryBalance { Id = Guid.Parse("88000000-0000-0000-0000-000000000006"), TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.SmartCardReaderItemId, WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, QuantityOnHand = 30, QuantityReserved = 2, QuantityAvailable = 28, CreatedAt = seedCreatedAt });

        // ── Purchase Orders ──────────────────────────────────────────────────
        modelBuilder.Entity<PurchaseOrder>().HasData(
            // Furniture
            new PurchaseOrder { Id = SeedConstants.DraftPurchaseOrderId,             TenantId = SeedConstants.FurnitureTenantId, PoNumber = "PO-2026-001", SupplierId = SeedConstants.AcmeSupplierId,      Status = PurchaseOrderStatus.Draft,             OrderDate = new DateTime(2026, 3, 20, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.AdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.ApprovedPurchaseOrderId,          TenantId = SeedConstants.FurnitureTenantId, PoNumber = "PO-2026-002", SupplierId = SeedConstants.NorthwoodSupplierId, Status = PurchaseOrderStatus.Approved,          OrderDate = new DateTime(2026, 3, 22, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 8, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.AdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.PartialPurchaseOrderId,           TenantId = SeedConstants.FurnitureTenantId, PoNumber = "PO-2026-003", SupplierId = SeedConstants.AcmeSupplierId,      Status = PurchaseOrderStatus.PartiallyReceived, OrderDate = new DateTime(2026, 3, 18, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 3, 28, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.AdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.CompletedPurchaseOrderId,         TenantId = SeedConstants.FurnitureTenantId, PoNumber = "PO-2026-004", SupplierId = SeedConstants.NorthwoodSupplierId, Status = PurchaseOrderStatus.Completed,         OrderDate = new DateTime(2026, 3, 10, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 3, 18, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.AdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.CancelledPurchaseOrderId,         TenantId = SeedConstants.FurnitureTenantId, PoNumber = "PO-2026-005", SupplierId = SeedConstants.AcmeSupplierId,      Status = PurchaseOrderStatus.Cancelled,         OrderDate = new DateTime(2026, 3, 12, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 3, 21, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.AdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.EastlakeApprovedPurchaseOrderId,  TenantId = SeedConstants.FurnitureTenantId, PoNumber = "PO-2026-006", SupplierId = SeedConstants.EastlakeSupplierId,  Status = PurchaseOrderStatus.Approved,          OrderDate = new DateTime(2026, 3, 27, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 10, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.AdminUserId, CreatedAt = seedCreatedAt },
            // Electronics
            new PurchaseOrder { Id = SeedConstants.ElecPODraftId,     TenantId = SeedConstants.ElectronicsTenantId, PoNumber = "ELEC-2026-001", SupplierId = SeedConstants.TechSourceSupplierId, Status = PurchaseOrderStatus.Draft,     OrderDate = new DateTime(2026, 3, 25, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 10, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.ElecAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.ElecPOApprovedId,   TenantId = SeedConstants.ElectronicsTenantId, PoNumber = "ELEC-2026-002", SupplierId = SeedConstants.DigiPartsSupplierId,  Status = PurchaseOrderStatus.Approved,  OrderDate = new DateTime(2026, 3, 20, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.ElecAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.ElecPOCompletedId,  TenantId = SeedConstants.ElectronicsTenantId, PoNumber = "ELEC-2026-003", SupplierId = SeedConstants.NovaTechSupplierId,   Status = PurchaseOrderStatus.Completed, OrderDate = new DateTime(2026, 3, 5, 0, 0, 0, DateTimeKind.Utc),  ExpectedDate = new DateTime(2026, 3, 15, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.ElecAdminUserId, CreatedAt = seedCreatedAt },
            // Food & Beverage
            new PurchaseOrder { Id = SeedConstants.FoodPODraftId,     TenantId = SeedConstants.FoodBeverageTenantId, PoNumber = "FOOD-2026-001", SupplierId = SeedConstants.FarmFreshSupplierId,  Status = PurchaseOrderStatus.Draft,     OrderDate = new DateTime(2026, 3, 28, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 12, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.FoodAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.FoodPOApprovedId,   TenantId = SeedConstants.FoodBeverageTenantId, PoNumber = "FOOD-2026-002", SupplierId = SeedConstants.BeverageCoSupplierId, Status = PurchaseOrderStatus.Approved,  OrderDate = new DateTime(2026, 3, 22, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 8, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.FoodAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.FoodPOCompletedId,  TenantId = SeedConstants.FoodBeverageTenantId, PoNumber = "FOOD-2026-003", SupplierId = SeedConstants.PackWorldSupplierId,  Status = PurchaseOrderStatus.Completed, OrderDate = new DateTime(2026, 3, 8, 0, 0, 0, DateTimeKind.Utc),  ExpectedDate = new DateTime(2026, 3, 18, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.FoodAdminUserId, CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new PurchaseOrder { Id = SeedConstants.SaasPODraftId,     TenantId = SeedConstants.SaasTenantId,         PoNumber = "SAAS-2026-001", SupplierId = SeedConstants.LicenseHubSupplierId, Status = PurchaseOrderStatus.Draft,     OrderDate = new DateTime(2026, 3, 26, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 10, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.SaasAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.SaasPOApprovedId,  TenantId = SeedConstants.SaasTenantId,         PoNumber = "SAAS-2026-002", SupplierId = SeedConstants.DevGearProSupplierId, Status = PurchaseOrderStatus.Approved,  OrderDate = new DateTime(2026, 3, 20, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 5, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.SaasAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.SaasPOCompletedId, TenantId = SeedConstants.SaasTenantId,         PoNumber = "SAAS-2026-003", SupplierId = SeedConstants.CloudStackSupplierId, Status = PurchaseOrderStatus.Completed, OrderDate = new DateTime(2026, 3, 6, 0, 0, 0, DateTimeKind.Utc),  ExpectedDate = new DateTime(2026, 3, 16, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.SaasAdminUserId, CreatedAt = seedCreatedAt },
            // IT Services
            new PurchaseOrder { Id = SeedConstants.ItPODraftId,      TenantId = SeedConstants.ItServicesTenantId,   PoNumber = "ITST-2026-001", SupplierId = SeedConstants.NetCoreSupplierId,    Status = PurchaseOrderStatus.Draft,     OrderDate = new DateTime(2026, 3, 27, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 11, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.ItAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.ItPOApprovedId,   TenantId = SeedConstants.ItServicesTenantId,   PoNumber = "ITST-2026-002", SupplierId = SeedConstants.DeviceMaxSupplierId,  Status = PurchaseOrderStatus.Approved,  OrderDate = new DateTime(2026, 3, 21, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 6, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.ItAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.ItPOCompletedId,  TenantId = SeedConstants.ItServicesTenantId,   PoNumber = "ITST-2026-003", SupplierId = SeedConstants.AccePartsSupplierId,  Status = PurchaseOrderStatus.Completed, OrderDate = new DateTime(2026, 3, 7, 0, 0, 0, DateTimeKind.Utc),  ExpectedDate = new DateTime(2026, 3, 17, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.ItAdminUserId, CreatedAt = seedCreatedAt },
            // Cybersecurity
            new PurchaseOrder { Id = SeedConstants.CyberPODraftId,     TenantId = SeedConstants.CyberTenantId,       PoNumber = "SHLD-2026-001", SupplierId = SeedConstants.FortiTechSupplierId,  Status = PurchaseOrderStatus.Draft,     OrderDate = new DateTime(2026, 3, 28, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 12, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.CyberAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.CyberPOApprovedId,  TenantId = SeedConstants.CyberTenantId,       PoNumber = "SHLD-2026-002", SupplierId = SeedConstants.ZeroTrustSupplierId,  Status = PurchaseOrderStatus.Approved,  OrderDate = new DateTime(2026, 3, 22, 0, 0, 0, DateTimeKind.Utc), ExpectedDate = new DateTime(2026, 4, 7, 0, 0, 0, DateTimeKind.Utc),  CreatedByUserId = SeedConstants.CyberAdminUserId, CreatedAt = seedCreatedAt },
            new PurchaseOrder { Id = SeedConstants.CyberPOCompletedId, TenantId = SeedConstants.CyberTenantId,       PoNumber = "SHLD-2026-003", SupplierId = SeedConstants.SecureKeySupplierId,  Status = PurchaseOrderStatus.Completed, OrderDate = new DateTime(2026, 3, 9, 0, 0, 0, DateTimeKind.Utc),  ExpectedDate = new DateTime(2026, 3, 19, 0, 0, 0, DateTimeKind.Utc), CreatedByUserId = SeedConstants.CyberAdminUserId, CreatedAt = seedCreatedAt });

        // ── Purchase Order Lines ─────────────────────────────────────────────
        modelBuilder.Entity<PurchaseOrderLine>().HasData(
            // Furniture
            new PurchaseOrderLine { Id = SeedConstants.DraftPurchaseOrderLineId,              TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.DraftPurchaseOrderId,            ItemId = SeedConstants.FilingCabinetItemId,       OrderedQuantity = 6,  ReceivedQuantity = 0, UnitCost = 235.00m,  CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.DraftPurchaseOrderSecondLineId,        TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.DraftPurchaseOrderId,            ItemId = SeedConstants.LoungeChairItemId,         OrderedQuantity = 4,  ReceivedQuantity = 0, UnitCost = 210.00m,  CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.ApprovedPurchaseOrderLineId,           TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.ApprovedPurchaseOrderId,         ItemId = SeedConstants.DeskLegKitItemId,          OrderedQuantity = 12, ReceivedQuantity = 0, UnitCost = 54.75m,   CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.ApprovedPurchaseOrderSecondLineId,     TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.ApprovedPurchaseOrderId,         ItemId = SeedConstants.ConferenceTableBaseItemId, OrderedQuantity = 6,  ReceivedQuantity = 0, UnitCost = 84.00m,   CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.PartialPurchaseOrderLineId,            TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.PartialPurchaseOrderId,          ItemId = SeedConstants.TaskChairItemId,           OrderedQuantity = 10, ReceivedQuantity = 4, UnitCost = 121.50m,  CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.CompletedPurchaseOrderLineId,          TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.CompletedPurchaseOrderId,        ItemId = SeedConstants.DeskLegKitItemId,          OrderedQuantity = 8,  ReceivedQuantity = 8, UnitCost = 52.00m,   CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.CancelledPurchaseOrderLineId,          TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.CancelledPurchaseOrderId,        ItemId = SeedConstants.TaskChairItemId,           OrderedQuantity = 3,  ReceivedQuantity = 0, UnitCost = 125.00m,  CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.EastlakeApprovedPurchaseOrderLineId,   TenantId = SeedConstants.FurnitureTenantId, PurchaseOrderId = SeedConstants.EastlakeApprovedPurchaseOrderId, ItemId = SeedConstants.MobilePedestalItemId,      OrderedQuantity = 10, ReceivedQuantity = 0, UnitCost = 176.50m,  CreatedAt = seedCreatedAt },
            // Electronics
            new PurchaseOrderLine { Id = SeedConstants.ElecPODraftLineId,    TenantId = SeedConstants.ElectronicsTenantId, PurchaseOrderId = SeedConstants.ElecPODraftId,    ItemId = SeedConstants.MonitorItemId, OrderedQuantity = 20, ReceivedQuantity = 0,  UnitCost = 340.00m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.ElecPOApprovedLineId,  TenantId = SeedConstants.ElectronicsTenantId, PurchaseOrderId = SeedConstants.ElecPOApprovedId,  ItemId = SeedConstants.SwitchItemId,  OrderedQuantity = 10, ReceivedQuantity = 0,  UnitCost = 490.00m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.ElecPOCompletedLineId, TenantId = SeedConstants.ElectronicsTenantId, PurchaseOrderId = SeedConstants.ElecPOCompletedId, ItemId = SeedConstants.WebcamItemId,  OrderedQuantity = 20, ReceivedQuantity = 20, UnitCost = 85.00m,  CreatedAt = seedCreatedAt },
            // Food & Beverage
            new PurchaseOrderLine { Id = SeedConstants.FoodPODraftLineId,    TenantId = SeedConstants.FoodBeverageTenantId, PurchaseOrderId = SeedConstants.FoodPODraftId,    ItemId = SeedConstants.FlourItemId,       OrderedQuantity = 1000, ReceivedQuantity = 0,    UnitCost = 0.82m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.FoodPOApprovedLineId,  TenantId = SeedConstants.FoodBeverageTenantId, PurchaseOrderId = SeedConstants.FoodPOApprovedId,  ItemId = SeedConstants.WaterBottleItemId, OrderedQuantity = 500,  ReceivedQuantity = 0,    UnitCost = 4.10m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.FoodPOCompletedLineId, TenantId = SeedConstants.FoodBeverageTenantId, PurchaseOrderId = SeedConstants.FoodPOCompletedId, ItemId = SeedConstants.KraftBoxItemId,    OrderedQuantity = 2000, ReceivedQuantity = 2000, UnitCost = 0.43m, CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new PurchaseOrderLine { Id = SeedConstants.SaasPODraftLineId,      TenantId = SeedConstants.SaasTenantId,         PurchaseOrderId = SeedConstants.SaasPODraftId,      ItemId = SeedConstants.VsLicenseItemId,       OrderedQuantity = 10, ReceivedQuantity = 0,  UnitCost = 530.00m,  CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.SaasPOApprovedLineId,   TenantId = SeedConstants.SaasTenantId,         PurchaseOrderId = SeedConstants.SaasPOApprovedId,   ItemId = SeedConstants.MacBookProItemId,      OrderedQuantity = 5,  ReceivedQuantity = 0,  UnitCost = 1950.00m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.SaasPOCompletedLineId,  TenantId = SeedConstants.SaasTenantId,         PurchaseOrderId = SeedConstants.SaasPOCompletedId,  ItemId = SeedConstants.NasStorageItemId,      OrderedQuantity = 3,  ReceivedQuantity = 3,  UnitCost = 1450.00m, CreatedAt = seedCreatedAt },
            // IT Services
            new PurchaseOrderLine { Id = SeedConstants.ItPODraftLineId,        TenantId = SeedConstants.ItServicesTenantId,   PurchaseOrderId = SeedConstants.ItPODraftId,        ItemId = SeedConstants.CiscoRouterItemId,     OrderedQuantity = 4,  ReceivedQuantity = 0,  UnitCost = 1850.00m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.ItPOApprovedLineId,     TenantId = SeedConstants.ItServicesTenantId,   PurchaseOrderId = SeedConstants.ItPOApprovedId,     ItemId = SeedConstants.DellDesktopItemId,     OrderedQuantity = 10, ReceivedQuantity = 0,  UnitCost = 820.00m,  CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.ItPOCompletedLineId,    TenantId = SeedConstants.ItServicesTenantId,   PurchaseOrderId = SeedConstants.ItPOCompletedId,    ItemId = SeedConstants.PatchCableItemId,      OrderedQuantity = 100, ReceivedQuantity = 100, UnitCost = 3.40m,  CreatedAt = seedCreatedAt },
            // Cybersecurity
            new PurchaseOrderLine { Id = SeedConstants.CyberPODraftLineId,     TenantId = SeedConstants.CyberTenantId,        PurchaseOrderId = SeedConstants.CyberPODraftId,     ItemId = SeedConstants.NgFirewallItemId,      OrderedQuantity = 2,  ReceivedQuantity = 0,  UnitCost = 3400.00m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.CyberPOApprovedLineId,  TenantId = SeedConstants.CyberTenantId,        PurchaseOrderId = SeedConstants.CyberPOApprovedId,  ItemId = SeedConstants.VpnConcentratorItemId, OrderedQuantity = 3,  ReceivedQuantity = 0,  UnitCost = 2150.00m, CreatedAt = seedCreatedAt },
            new PurchaseOrderLine { Id = SeedConstants.CyberPOCompletedLineId, TenantId = SeedConstants.CyberTenantId,        PurchaseOrderId = SeedConstants.CyberPOCompletedId, ItemId = SeedConstants.HwSecKeyItemId,        OrderedQuantity = 25, ReceivedQuantity = 25, UnitCost = 47.00m,   CreatedAt = seedCreatedAt });

        // ── Goods Receipts ───────────────────────────────────────────────────
        modelBuilder.Entity<GoodsReceipt>().HasData(
            // Furniture
            new GoodsReceipt { Id = SeedConstants.PartialGoodsReceiptId,   TenantId = SeedConstants.FurnitureTenantId,    PurchaseOrderId = SeedConstants.PartialPurchaseOrderId,  ReceiptNumber = "GR-2026-003", ReceivedAt = new DateTime(2026, 3, 25, 14, 0, 0, DateTimeKind.Utc), ReceivedByUserId = SeedConstants.WarehouseUserId,     CreatedAt = seedCreatedAt },
            new GoodsReceipt { Id = SeedConstants.CompletedGoodsReceiptId,  TenantId = SeedConstants.FurnitureTenantId,    PurchaseOrderId = SeedConstants.CompletedPurchaseOrderId, ReceiptNumber = "GR-2026-004", ReceivedAt = new DateTime(2026, 3, 16, 10, 30, 0, DateTimeKind.Utc), ReceivedByUserId = SeedConstants.WarehouseUserId,    CreatedAt = seedCreatedAt },
            // Electronics
            new GoodsReceipt { Id = SeedConstants.ElecGoodsReceiptId, TenantId = SeedConstants.ElectronicsTenantId, PurchaseOrderId = SeedConstants.ElecPOCompletedId, ReceiptNumber = "GR-ELEC-001", ReceivedAt = new DateTime(2026, 3, 14, 10, 0, 0, DateTimeKind.Utc), ReceivedByUserId = SeedConstants.ElecWarehouseUserId, CreatedAt = seedCreatedAt },
            // Food & Beverage
            new GoodsReceipt { Id = SeedConstants.FoodGoodsReceiptId, TenantId = SeedConstants.FoodBeverageTenantId, PurchaseOrderId = SeedConstants.FoodPOCompletedId, ReceiptNumber = "GR-FOOD-001", ReceivedAt = new DateTime(2026, 3, 16, 8, 30, 0, DateTimeKind.Utc), ReceivedByUserId = SeedConstants.FoodWarehouseUserId, CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new GoodsReceipt { Id = SeedConstants.SaasGoodsReceiptId, TenantId = SeedConstants.SaasTenantId,         PurchaseOrderId = SeedConstants.SaasPOCompletedId, ReceiptNumber = "GR-SAAS-001", ReceivedAt = new DateTime(2026, 3, 15, 11, 0, 0, DateTimeKind.Utc), ReceivedByUserId = SeedConstants.SaasWarehouseUserId, CreatedAt = seedCreatedAt },
            // IT Services
            new GoodsReceipt { Id = SeedConstants.ItGoodsReceiptId,   TenantId = SeedConstants.ItServicesTenantId,   PurchaseOrderId = SeedConstants.ItPOCompletedId,   ReceiptNumber = "GR-ITST-001", ReceivedAt = new DateTime(2026, 3, 16, 9, 0, 0, DateTimeKind.Utc),  ReceivedByUserId = SeedConstants.ItWarehouseUserId,   CreatedAt = seedCreatedAt },
            // Cybersecurity
            new GoodsReceipt { Id = SeedConstants.CyberGoodsReceiptId, TenantId = SeedConstants.CyberTenantId,       PurchaseOrderId = SeedConstants.CyberPOCompletedId, ReceiptNumber = "GR-SHLD-001", ReceivedAt = new DateTime(2026, 3, 18, 10, 0, 0, DateTimeKind.Utc), ReceivedByUserId = SeedConstants.CyberWarehouseUserId, CreatedAt = seedCreatedAt });

        // ── Goods Receipt Lines ──────────────────────────────────────────────
        modelBuilder.Entity<GoodsReceiptLine>().HasData(
            // Furniture
            new GoodsReceiptLine { Id = SeedConstants.PartialGoodsReceiptLineId,   TenantId = SeedConstants.FurnitureTenantId,    GoodsReceiptId = SeedConstants.PartialGoodsReceiptId,  PurchaseOrderLineId = SeedConstants.PartialPurchaseOrderLineId,  ItemId = SeedConstants.TaskChairItemId, ReceivedQuantity = 4,    CreatedAt = seedCreatedAt },
            new GoodsReceiptLine { Id = SeedConstants.CompletedGoodsReceiptLineId,  TenantId = SeedConstants.FurnitureTenantId,    GoodsReceiptId = SeedConstants.CompletedGoodsReceiptId, PurchaseOrderLineId = SeedConstants.CompletedPurchaseOrderLineId, ItemId = SeedConstants.DeskLegKitItemId, ReceivedQuantity = 8,   CreatedAt = seedCreatedAt },
            // Electronics
            new GoodsReceiptLine { Id = SeedConstants.ElecGoodsReceiptLineId, TenantId = SeedConstants.ElectronicsTenantId, GoodsReceiptId = SeedConstants.ElecGoodsReceiptId, PurchaseOrderLineId = SeedConstants.ElecPOCompletedLineId, ItemId = SeedConstants.WebcamItemId,  ReceivedQuantity = 20,   CreatedAt = seedCreatedAt },
            // Food & Beverage
            new GoodsReceiptLine { Id = SeedConstants.FoodGoodsReceiptLineId,  TenantId = SeedConstants.FoodBeverageTenantId, GoodsReceiptId = SeedConstants.FoodGoodsReceiptId,  PurchaseOrderLineId = SeedConstants.FoodPOCompletedLineId,  ItemId = SeedConstants.KraftBoxItemId,    ReceivedQuantity = 2000, CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new GoodsReceiptLine { Id = SeedConstants.SaasGoodsReceiptLineId,  TenantId = SeedConstants.SaasTenantId,         GoodsReceiptId = SeedConstants.SaasGoodsReceiptId,  PurchaseOrderLineId = SeedConstants.SaasPOCompletedLineId,  ItemId = SeedConstants.NasStorageItemId,  ReceivedQuantity = 3,    CreatedAt = seedCreatedAt },
            // IT Services
            new GoodsReceiptLine { Id = SeedConstants.ItGoodsReceiptLineId,    TenantId = SeedConstants.ItServicesTenantId,   GoodsReceiptId = SeedConstants.ItGoodsReceiptId,    PurchaseOrderLineId = SeedConstants.ItPOCompletedLineId,    ItemId = SeedConstants.PatchCableItemId,  ReceivedQuantity = 100,  CreatedAt = seedCreatedAt },
            // Cybersecurity
            new GoodsReceiptLine { Id = SeedConstants.CyberGoodsReceiptLineId, TenantId = SeedConstants.CyberTenantId,        GoodsReceiptId = SeedConstants.CyberGoodsReceiptId, PurchaseOrderLineId = SeedConstants.CyberPOCompletedLineId, ItemId = SeedConstants.HwSecKeyItemId,    ReceivedQuantity = 25,   CreatedAt = seedCreatedAt });

        // ── Inventory Transactions ───────────────────────────────────────────
        modelBuilder.Entity<InventoryTransaction>().HasData(
            // Furniture
            new InventoryTransaction { Id = SeedConstants.ReceiptTransactionId,                 TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.TaskChairItemId,           WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "GoodsReceipt",   ReferenceId = SeedConstants.PartialGoodsReceiptId,            Reason = null,                                          QuantityChange = 4,  BalanceAfter = 18, PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 25, 14, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.IssueTransactionId,                   TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.FilingCabinetItemId,       WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.Issue,              ReferenceType = "ManualIssue",    ReferenceId = null,                                           Reason = "Reserved for municipal office fit-out",      QuantityChange = -2, BalanceAfter = 4,  PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 29, 9, 15, 0, DateTimeKind.Utc),   CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.AdjustmentIncreaseTransactionId,      TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.DeskLegKitItemId,          WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.DeskLegCycleCountAdjustmentId,   Reason = "Cycle count found extra kit components",     QuantityChange = 3,  BalanceAfter = 32, PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 30, 8, 45, 0, DateTimeKind.Utc),   CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.AdjustmentDecreaseTransactionId,      TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.FilingCabinetItemId,       WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.AdjustmentDecrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.CabinetDamageAdjustmentId,       Reason = "One cabinet damaged in transit",             QuantityChange = -1, BalanceAfter = 3,  PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 30, 11, 0, 0, DateTimeKind.Utc),   CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.PedestalReceiptTransactionId,         TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.MobilePedestalItemId,      WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "VendorDelivery", ReferenceId = SeedConstants.EastlakeApprovedPurchaseOrderId, Reason = "Rush replenishment for mobile pedestals",    QuantityChange = 6,  BalanceAfter = 14, PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 31, 9, 30, 0, DateTimeKind.Utc),   CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.TaskChairIssueTransactionId,          TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.TaskChairItemId,           WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.Issue,              ReferenceType = "ShowroomRefresh", ReferenceId = null,                                           Reason = "Moved chairs to showroom staging area",      QuantityChange = -2, BalanceAfter = 16, PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 31, 13, 20, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.ConferenceBaseAdjustmentTransactionId, TenantId = SeedConstants.FurnitureTenantId, ItemId = SeedConstants.ConferenceTableBaseItemId, WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.ConferenceBaseAdjustmentId,      Reason = "Found two extra conference table bases during cycle count", QuantityChange = 2, BalanceAfter = 11, PerformedByUserId = SeedConstants.AdminUserId, PerformedAt = new DateTime(2026, 3, 31, 15, 5, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            // Electronics
            new InventoryTransaction { Id = SeedConstants.ElecTxn1Id, TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.WebcamItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "GoodsReceipt",   ReferenceId = SeedConstants.ElecGoodsReceiptId, Reason = null,                                    QuantityChange = 20, BalanceAfter = 30, PerformedByUserId = SeedConstants.ElecWarehouseUserId, PerformedAt = new DateTime(2026, 3, 14, 10, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.ElecTxn2Id, TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.MonitorItemId, WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, TransactionType = InventoryTransactionType.Issue,              ReferenceType = "DemoSetup",      ReferenceId = null,                              Reason = "Monitors deployed to showroom demo stations", QuantityChange = -5, BalanceAfter = 25, PerformedByUserId = SeedConstants.ElecWarehouseUserId, PerformedAt = new DateTime(2026, 3, 18, 9, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.ElecTxn3Id, TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.ServerItemId,  WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.ElecAdj1Id,          Reason = "Cycle count corrected server count",   QuantityChange = 2,  BalanceAfter = 8,  PerformedByUserId = SeedConstants.ElecAdminUserId,     PerformedAt = new DateTime(2026, 3, 22, 14, 30, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            // Food & Beverage
            new InventoryTransaction { Id = SeedConstants.FoodTxn1Id, TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.KraftBoxItemId, WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "GoodsReceipt",   ReferenceId = SeedConstants.FoodGoodsReceiptId, Reason = null,                               QuantityChange = 2000, BalanceAfter = 1000, PerformedByUserId = SeedConstants.FoodWarehouseUserId, PerformedAt = new DateTime(2026, 3, 16, 8, 30, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.FoodTxn2Id, TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.FlourItemId,    WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, TransactionType = InventoryTransactionType.Issue,              ReferenceType = "ProductionOrder", ReferenceId = null,                              Reason = "Issued to production line batch #B-042", QuantityChange = -100, BalanceAfter = 500, PerformedByUserId = SeedConstants.FoodWarehouseUserId, PerformedAt = new DateTime(2026, 3, 20, 7, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.FoodTxn3Id, TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.RiceItemId,     WarehouseId = SeedConstants.FoodWarehouseId, LocationId = SeedConstants.FoodLocationId, TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.FoodAdj1Id,       Reason = "Recount corrected rice inventory",              QuantityChange = 50,  BalanceAfter = 800, PerformedByUserId = SeedConstants.FoodAdminUserId,     PerformedAt = new DateTime(2026, 3, 25, 11, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new InventoryTransaction { Id = SeedConstants.SaasTxn1Id, TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.NasStorageItemId,   WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "GoodsReceipt",    ReferenceId = SeedConstants.SaasGoodsReceiptId, Reason = null,                                            QuantityChange = 3,   BalanceAfter = 4,   PerformedByUserId = SeedConstants.SaasWarehouseUserId, PerformedAt = new DateTime(2026, 3, 15, 11, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.SaasTxn2Id, TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.MacBookProItemId,   WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, TransactionType = InventoryTransactionType.Issue,              ReferenceType = "DevSetup",        ReferenceId = null,                              Reason = "Issued to new engineering hires",               QuantityChange = -2,  BalanceAfter = 8,   PerformedByUserId = SeedConstants.SaasWarehouseUserId, PerformedAt = new DateTime(2026, 3, 19, 9, 0, 0, DateTimeKind.Utc),   CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.SaasTxn3Id, TenantId = SeedConstants.SaasTenantId, ItemId = SeedConstants.VsLicenseItemId,    WarehouseId = SeedConstants.SaasWarehouseId, LocationId = SeedConstants.SaasLocationId, TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.SaasAdj1Id,         Reason = "Audit found unrecorded license seat",           QuantityChange = 2,   BalanceAfter = 20,  PerformedByUserId = SeedConstants.SaasAdminUserId,     PerformedAt = new DateTime(2026, 3, 23, 14, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            // IT Services
            new InventoryTransaction { Id = SeedConstants.ItTxn1Id,   TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.PatchCableItemId,   WarehouseId = SeedConstants.ItWarehouseId,   LocationId = SeedConstants.ItLocationId,   TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "GoodsReceipt",    ReferenceId = SeedConstants.ItGoodsReceiptId,   Reason = null,                                            QuantityChange = 100, BalanceAfter = 200, PerformedByUserId = SeedConstants.ItWarehouseUserId,   PerformedAt = new DateTime(2026, 3, 16, 9, 0, 0, DateTimeKind.Utc),   CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.ItTxn2Id,   TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.DellDesktopItemId,  WarehouseId = SeedConstants.ItWarehouseId,   LocationId = SeedConstants.ItLocationId,   TransactionType = InventoryTransactionType.Issue,              ReferenceType = "ClientDeployment", ReferenceId = null,                             Reason = "Deployed to Contoso client site",               QuantityChange = -5,  BalanceAfter = 15,  PerformedByUserId = SeedConstants.ItWarehouseUserId,   PerformedAt = new DateTime(2026, 3, 20, 10, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.ItTxn3Id,   TenantId = SeedConstants.ItServicesTenantId, ItemId = SeedConstants.PoeSwitchItemId,    WarehouseId = SeedConstants.ItWarehouseId,   LocationId = SeedConstants.ItLocationId,   TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.ItAdj1Id,           Reason = "Cycle count found extra switch in receiving",   QuantityChange = 1,   BalanceAfter = 10,  PerformedByUserId = SeedConstants.ItAdminUserId,       PerformedAt = new DateTime(2026, 3, 24, 15, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            // Cybersecurity
            new InventoryTransaction { Id = SeedConstants.CyberTxn1Id, TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.HwSecKeyItemId,        WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, TransactionType = InventoryTransactionType.Receipt,            ReferenceType = "GoodsReceipt",    ReferenceId = SeedConstants.CyberGoodsReceiptId, Reason = null,                                            QuantityChange = 25,  BalanceAfter = 50,  PerformedByUserId = SeedConstants.CyberWarehouseUserId, PerformedAt = new DateTime(2026, 3, 18, 10, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.CyberTxn2Id, TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.NgFirewallItemId,      WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, TransactionType = InventoryTransactionType.Issue,              ReferenceType = "ClientDeployment", ReferenceId = null,                               Reason = "Deployed firewall to enterprise client",        QuantityChange = -1,  BalanceAfter = 4,   PerformedByUserId = SeedConstants.CyberWarehouseUserId, PerformedAt = new DateTime(2026, 3, 21, 11, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            new InventoryTransaction { Id = SeedConstants.CyberTxn3Id, TenantId = SeedConstants.CyberTenantId, ItemId = SeedConstants.SmartCardReaderItemId, WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, TransactionType = InventoryTransactionType.AdjustmentIncrease, ReferenceType = "StockAdjustment", ReferenceId = SeedConstants.CyberAdj1Id,          Reason = "Found unregistered readers in secure vault",    QuantityChange = 5,   BalanceAfter = 30,  PerformedByUserId = SeedConstants.CyberAdminUserId,     PerformedAt = new DateTime(2026, 3, 26, 14, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt });

        // ── Stock Adjustments ────────────────────────────────────────────────
        modelBuilder.Entity<StockAdjustment>().HasData(
            // Furniture
            new StockAdjustment { Id = SeedConstants.DeskLegCycleCountAdjustmentId,  TenantId = SeedConstants.FurnitureTenantId,    ItemId = SeedConstants.DeskLegKitItemId,          WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, AdjustmentType = AdjustmentType.Increase, QuantityDelta = 3, Reason = "Cycle count found extra kit components",                   PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 30, 8, 45, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new StockAdjustment { Id = SeedConstants.CabinetDamageAdjustmentId,      TenantId = SeedConstants.FurnitureTenantId,    ItemId = SeedConstants.FilingCabinetItemId,       WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, AdjustmentType = AdjustmentType.Decrease, QuantityDelta = 1, Reason = "One cabinet damaged in transit",                           PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 30, 11, 0, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            new StockAdjustment { Id = SeedConstants.ConferenceBaseAdjustmentId,     TenantId = SeedConstants.FurnitureTenantId,    ItemId = SeedConstants.ConferenceTableBaseItemId, WarehouseId = SeedConstants.MainWarehouseId, LocationId = SeedConstants.MainAisleLocationId, AdjustmentType = AdjustmentType.Increase, QuantityDelta = 2, Reason = "Found two extra conference table bases during cycle count", PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 31, 15, 5, 0, DateTimeKind.Utc),  CreatedAt = seedCreatedAt },
            // Electronics
            new StockAdjustment { Id = SeedConstants.ElecAdj1Id, TenantId = SeedConstants.ElectronicsTenantId, ItemId = SeedConstants.ServerItemId, WarehouseId = SeedConstants.ElecWarehouseId, LocationId = SeedConstants.ElecLocationId, AdjustmentType = AdjustmentType.Increase, QuantityDelta = 2, Reason = "Cycle count corrected server count", PerformedByUserId = SeedConstants.ElecAdminUserId, PerformedAt = new DateTime(2026, 3, 22, 14, 30, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            // Food & Beverage
            new StockAdjustment { Id = SeedConstants.FoodAdj1Id,  TenantId = SeedConstants.FoodBeverageTenantId, ItemId = SeedConstants.RiceItemId,         WarehouseId = SeedConstants.FoodWarehouseId,  LocationId = SeedConstants.FoodLocationId,  AdjustmentType = AdjustmentType.Increase, QuantityDelta = 50, Reason = "Recount corrected rice inventory",              PerformedByUserId = SeedConstants.FoodAdminUserId,  PerformedAt = new DateTime(2026, 3, 25, 11, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new StockAdjustment { Id = SeedConstants.SaasAdj1Id,  TenantId = SeedConstants.SaasTenantId,         ItemId = SeedConstants.VsLicenseItemId,    WarehouseId = SeedConstants.SaasWarehouseId,  LocationId = SeedConstants.SaasLocationId,  AdjustmentType = AdjustmentType.Increase, QuantityDelta = 2,  Reason = "Audit found unrecorded license seat",           PerformedByUserId = SeedConstants.SaasAdminUserId,  PerformedAt = new DateTime(2026, 3, 23, 14, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            // IT Services
            new StockAdjustment { Id = SeedConstants.ItAdj1Id,    TenantId = SeedConstants.ItServicesTenantId,   ItemId = SeedConstants.PoeSwitchItemId,    WarehouseId = SeedConstants.ItWarehouseId,    LocationId = SeedConstants.ItLocationId,    AdjustmentType = AdjustmentType.Increase, QuantityDelta = 1,  Reason = "Cycle count found extra switch in receiving",   PerformedByUserId = SeedConstants.ItAdminUserId,    PerformedAt = new DateTime(2026, 3, 24, 15, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt },
            // Cybersecurity
            new StockAdjustment { Id = SeedConstants.CyberAdj1Id, TenantId = SeedConstants.CyberTenantId,        ItemId = SeedConstants.SmartCardReaderItemId, WarehouseId = SeedConstants.CyberWarehouseId, LocationId = SeedConstants.CyberLocationId, AdjustmentType = AdjustmentType.Increase, QuantityDelta = 5,  Reason = "Found unregistered readers in secure vault",    PerformedByUserId = SeedConstants.CyberAdminUserId, PerformedAt = new DateTime(2026, 3, 26, 14, 0, 0, DateTimeKind.Utc), CreatedAt = seedCreatedAt });

        // ── Audit Logs ───────────────────────────────────────────────────────
        modelBuilder.Entity<AuditLog>().HasData(
            // Furniture
            new AuditLog { Id = SeedConstants.PurchaseOrderCreatedAuditLogId,    TenantId = SeedConstants.FurnitureTenantId, Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder),         EntityId = SeedConstants.ApprovedPurchaseOrderId,        PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 22, 9, 30, 0, DateTimeKind.Utc),  Details = "Created approved demo purchase order PO-2026-002.",                                   CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.GoodsReceiptAuditLogId,            TenantId = SeedConstants.FurnitureTenantId, Action = "GoodsReceiptPosted",    EntityName = nameof(GoodsReceipt),          EntityId = SeedConstants.PartialGoodsReceiptId,          PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 25, 14, 0, 0, DateTimeKind.Utc), Details = "Received 4 task chairs against PO-2026-003.",                                         CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.StockIssueAuditLogId,              TenantId = SeedConstants.FurnitureTenantId, Action = "StockIssued",           EntityName = nameof(InventoryTransaction),  EntityId = SeedConstants.IssueTransactionId,             PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 29, 9, 15, 0, DateTimeKind.Utc),  Details = "Issued two filing cabinets for municipal office fit-out.",                            CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.StockAdjustmentAuditLogId,         TenantId = SeedConstants.FurnitureTenantId, Action = "StockAdjusted",         EntityName = nameof(StockAdjustment),       EntityId = SeedConstants.CabinetDamageAdjustmentId,      PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 30, 11, 0, 0, DateTimeKind.Utc), Details = "Recorded a damaged filing cabinet after inbound inspection.",                         CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.EastlakePurchaseOrderAuditLogId,   TenantId = SeedConstants.FurnitureTenantId, Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder),          EntityId = SeedConstants.EastlakeApprovedPurchaseOrderId, PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 27, 10, 0, 0, DateTimeKind.Utc), Details = "Created approved demo purchase order PO-2026-006 for Eastlake Office Furnishings.",    CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.PedestalReceiptAuditLogId,         TenantId = SeedConstants.FurnitureTenantId, Action = "GoodsReceiptPosted",    EntityName = nameof(InventoryTransaction),  EntityId = SeedConstants.PedestalReceiptTransactionId,   PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 31, 9, 30, 0, DateTimeKind.Utc),  Details = "Recorded rush replenishment receipt for mobile pedestals.",                          CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.TaskChairIssueAuditLogId,          TenantId = SeedConstants.FurnitureTenantId, Action = "StockIssued",           EntityName = nameof(InventoryTransaction),  EntityId = SeedConstants.TaskChairIssueTransactionId,    PerformedByUserId = SeedConstants.WarehouseUserId, PerformedAt = new DateTime(2026, 3, 31, 13, 20, 0, DateTimeKind.Utc), Details = "Issued two task chairs for showroom refresh.",                                        CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.ConferenceBaseAdjustmentAuditLogId, TenantId = SeedConstants.FurnitureTenantId, Action = "StockAdjusted",        EntityName = nameof(StockAdjustment),       EntityId = SeedConstants.ConferenceBaseAdjustmentId,     PerformedByUserId = SeedConstants.AdminUserId,     PerformedAt = new DateTime(2026, 3, 31, 15, 5, 0, DateTimeKind.Utc),  Details = "Cycle count increased conference table base inventory by two units.",                 CreatedAt = seedCreatedAt },
            // Electronics
            new AuditLog { Id = SeedConstants.ElecAuditLog1Id, TenantId = SeedConstants.ElectronicsTenantId, Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder),        EntityId = SeedConstants.ElecPOCompletedId,    PerformedByUserId = SeedConstants.ElecAdminUserId,     PerformedAt = new DateTime(2026, 3, 5, 9, 0, 0, DateTimeKind.Utc),   Details = "Created completed purchase order ELEC-2026-003 from NovaTech Components.",  CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.ElecAuditLog2Id, TenantId = SeedConstants.ElectronicsTenantId, Action = "GoodsReceiptPosted",    EntityName = nameof(GoodsReceipt),         EntityId = SeedConstants.ElecGoodsReceiptId,   PerformedByUserId = SeedConstants.ElecWarehouseUserId, PerformedAt = new DateTime(2026, 3, 14, 10, 0, 0, DateTimeKind.Utc), Details = "Received 20 HD webcams against ELEC-2026-003.",                              CreatedAt = seedCreatedAt },
            // Food & Beverage
            new AuditLog { Id = SeedConstants.FoodAuditLog1Id,  TenantId = SeedConstants.FoodBeverageTenantId, Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder), EntityId = SeedConstants.FoodPOCompletedId,    PerformedByUserId = SeedConstants.FoodAdminUserId,      PerformedAt = new DateTime(2026, 3, 8, 8, 30, 0, DateTimeKind.Utc),   Details = "Created completed purchase order FOOD-2026-003 from PackWorld Supplies.",    CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.FoodAuditLog2Id,  TenantId = SeedConstants.FoodBeverageTenantId, Action = "GoodsReceiptPosted",    EntityName = nameof(GoodsReceipt),  EntityId = SeedConstants.FoodGoodsReceiptId,   PerformedByUserId = SeedConstants.FoodWarehouseUserId,  PerformedAt = new DateTime(2026, 3, 16, 8, 30, 0, DateTimeKind.Utc),  Details = "Received 2000 kraft boxes against FOOD-2026-003.",                          CreatedAt = seedCreatedAt },
            // SaaS / Cloud
            new AuditLog { Id = SeedConstants.SaasAuditLog1Id,  TenantId = SeedConstants.SaasTenantId,         Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder), EntityId = SeedConstants.SaasPOCompletedId,    PerformedByUserId = SeedConstants.SaasAdminUserId,      PerformedAt = new DateTime(2026, 3, 6, 9, 0, 0, DateTimeKind.Utc),    Details = "Created completed purchase order SAAS-2026-003 from CloudStack Hardware.",  CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.SaasAuditLog2Id,  TenantId = SeedConstants.SaasTenantId,         Action = "GoodsReceiptPosted",    EntityName = nameof(GoodsReceipt),  EntityId = SeedConstants.SaasGoodsReceiptId,   PerformedByUserId = SeedConstants.SaasWarehouseUserId,  PerformedAt = new DateTime(2026, 3, 15, 11, 0, 0, DateTimeKind.Utc),  Details = "Received 3 NAS storage units against SAAS-2026-003.",                      CreatedAt = seedCreatedAt },
            // IT Services
            new AuditLog { Id = SeedConstants.ItAuditLog1Id,    TenantId = SeedConstants.ItServicesTenantId,   Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder), EntityId = SeedConstants.ItPOCompletedId,      PerformedByUserId = SeedConstants.ItAdminUserId,        PerformedAt = new DateTime(2026, 3, 7, 9, 0, 0, DateTimeKind.Utc),    Details = "Created completed purchase order ITST-2026-003 from AcceParts Direct.",     CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.ItAuditLog2Id,    TenantId = SeedConstants.ItServicesTenantId,   Action = "GoodsReceiptPosted",    EntityName = nameof(GoodsReceipt),  EntityId = SeedConstants.ItGoodsReceiptId,     PerformedByUserId = SeedConstants.ItWarehouseUserId,    PerformedAt = new DateTime(2026, 3, 16, 9, 0, 0, DateTimeKind.Utc),   Details = "Received 100 Cat6 patch cables against ITST-2026-003.",                    CreatedAt = seedCreatedAt },
            // Cybersecurity
            new AuditLog { Id = SeedConstants.CyberAuditLog1Id, TenantId = SeedConstants.CyberTenantId,        Action = "PurchaseOrderCreated", EntityName = nameof(PurchaseOrder), EntityId = SeedConstants.CyberPOCompletedId,   PerformedByUserId = SeedConstants.CyberAdminUserId,     PerformedAt = new DateTime(2026, 3, 9, 9, 0, 0, DateTimeKind.Utc),    Details = "Created completed purchase order SHLD-2026-003 from SecureKey Technologies.", CreatedAt = seedCreatedAt },
            new AuditLog { Id = SeedConstants.CyberAuditLog2Id, TenantId = SeedConstants.CyberTenantId,        Action = "GoodsReceiptPosted",    EntityName = nameof(GoodsReceipt),  EntityId = SeedConstants.CyberGoodsReceiptId,  PerformedByUserId = SeedConstants.CyberWarehouseUserId, PerformedAt = new DateTime(2026, 3, 18, 10, 0, 0, DateTimeKind.Utc), Details = "Received 25 hardware security keys against SHLD-2026-003.",                CreatedAt = seedCreatedAt });
    }
}
