using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClearErp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTechTenantsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedAt", "Name", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("34000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Software Licenses", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("34000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dev Hardware", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("34000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cloud Infra", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("35000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Networking", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("35000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "End-User Devices", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("35000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Peripherals", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("36000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Security Appliances", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("36000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Identity & Access", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("36000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Threat Intel", new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "Id", "ContactName", "CreatedAt", "Email", "IsActive", "Name", "Notes", "Phone", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("44000000-0000-0000-0000-000000000001"), "Avery Zhang", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "orders@licensehub.example", true, "LicenseHub Global", null, "555-0400", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("44000000-0000-0000-0000-000000000002"), "Jordan Miles", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sales@devgearpro.example", true, "DevGear Pro", null, "555-0410", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("44000000-0000-0000-0000-000000000003"), "Morgan Tran", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "trade@cloudstack.example", true, "CloudStack Hardware", null, "555-0420", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("45000000-0000-0000-0000-000000000001"), "Taylor Reyes", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "orders@netcore.example", true, "NetCore Distribution", null, "555-0500", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("45000000-0000-0000-0000-000000000002"), "Alex Park", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "supply@devicemax.example", true, "DeviceMax Wholesale", null, "555-0510", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("45000000-0000-0000-0000-000000000003"), "Sam Ortega", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sales@acceparts.example", true, "AcceParts Direct", null, "555-0520", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("46000000-0000-0000-0000-000000000001"), "Jamie Nguyen", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "orders@fortitech.example", true, "FortiTech Systems", null, "555-0600", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("46000000-0000-0000-0000-000000000002"), "Riley Hassan", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "supply@zerotrust.example", true, "ZeroTrust Solutions", null, "555-0610", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("46000000-0000-0000-0000-000000000003"), "Drew Okafor", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sales@securekey.example", true, "SecureKey Technologies", null, "555-0620", new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "Id", "CreatedAt", "Industry", "IsActive", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SaaS / Cloud", true, "CloudPeak SaaS", "saas", null },
                    { new Guid("01000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "IT Services", true, "NetBridge IT Services", "it-services", null },
                    { new Guid("01000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cybersecurity", true, "ShieldCore Cybersecurity", "cybersecurity", null }
                });

            migrationBuilder.InsertData(
                table: "warehouses",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("54000000-0000-0000-0000-000000000001"), "SAAS", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "CloudPeak HQ Stockroom", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("55000000-0000-0000-0000-000000000001"), "ITST", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "NetBridge IT Store", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("56000000-0000-0000-0000-000000000001"), "SCSS", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ShieldCore Secure Store", new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "Name", "ReorderLevel", "Sku", "StandardCost", "TenantId", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("76000000-0000-0000-0000-000000000001"), new Guid("34000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VS Enterprise annual subscription seat", true, "Visual Studio License", 5, "LIC-6001", 549.00m, new Guid("01000000-0000-0000-0000-000000000004"), "EA", null },
                    { new Guid("76000000-0000-0000-0000-000000000002"), new Guid("34000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "JetBrains All Products Pack annual license", true, "JetBrains All Pack", 5, "LIC-6002", 779.00m, new Guid("01000000-0000-0000-0000-000000000004"), "EA", null },
                    { new Guid("76000000-0000-0000-0000-000000000003"), new Guid("34000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Apple M3 Pro MacBook Pro 14-inch, 18 GB RAM", true, "MacBook Pro 14\"", 3, "HW-6003", 1999.00m, new Guid("01000000-0000-0000-0000-000000000004"), "EA", null },
                    { new Guid("76000000-0000-0000-0000-000000000004"), new Guid("34000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mechanical keyboard, TKL layout, brown switches", true, "Mech Keyboard", 10, "HW-6004", 119.00m, new Guid("01000000-0000-0000-0000-000000000004"), "EA", null },
                    { new Guid("76000000-0000-0000-0000-000000000005"), new Guid("34000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "1-yr t3.large EC2 reserved instance (prepaid)", true, "AWS Reserved Instance", 2, "INF-6005", 840.00m, new Guid("01000000-0000-0000-0000-000000000004"), "EA", null },
                    { new Guid("76000000-0000-0000-0000-000000000006"), new Guid("34000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "8-bay NAS enclosure with 4 TB drives", true, "NAS Storage Unit", 2, "INF-6006", 1499.00m, new Guid("01000000-0000-0000-0000-000000000004"), "EA", null },
                    { new Guid("78000000-0000-0000-0000-000000000001"), new Guid("35000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cisco ISR 4321 integrated services router", true, "Cisco ISR Router", 3, "NET-7001", 1899.00m, new Guid("01000000-0000-0000-0000-000000000005"), "EA", null },
                    { new Guid("78000000-0000-0000-0000-000000000002"), new Guid("35000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "24-port PoE+ managed gigabit switch", true, "PoE Switch 24-Port", 4, "NET-7002", 699.00m, new Guid("01000000-0000-0000-0000-000000000005"), "EA", null },
                    { new Guid("78000000-0000-0000-0000-000000000003"), new Guid("35000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dell OptiPlex 7010 SFF, i5, 16 GB RAM", true, "Dell OptiPlex Desktop", 5, "DEV-7003", 849.00m, new Guid("01000000-0000-0000-0000-000000000005"), "EA", null },
                    { new Guid("78000000-0000-0000-0000-000000000004"), new Guid("35000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "HP LaserJet Pro MFP M428fdn mono printer", true, "HP LaserJet Pro", 3, "DEV-7004", 429.00m, new Guid("01000000-0000-0000-0000-000000000005"), "EA", null },
                    { new Guid("78000000-0000-0000-0000-000000000005"), new Guid("35000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Full-motion dual monitor arm desk mount", true, "Dual Monitor Stand", 8, "PER-7005", 89.00m, new Guid("01000000-0000-0000-0000-000000000005"), "EA", null },
                    { new Guid("78000000-0000-0000-0000-000000000006"), new Guid("35000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cat6 UTP patch cable 1 m, blue", true, "Cat6 Patch Cable 1m", 100, "PER-7006", 3.50m, new Guid("01000000-0000-0000-0000-000000000005"), "EA", null },
                    { new Guid("7a000000-0000-0000-0000-000000000001"), new Guid("36000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Next-gen firewall, 1 Gbps throughput", true, "NG Firewall Appliance", 2, "SEC-8001", 3499.00m, new Guid("01000000-0000-0000-0000-000000000006"), "EA", null },
                    { new Guid("7a000000-0000-0000-0000-000000000002"), new Guid("36000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "FIDO2 hardware security key USB-A/NFC", true, "HW Security Key", 20, "SEC-8002", 49.00m, new Guid("01000000-0000-0000-0000-000000000006"), "EA", null },
                    { new Guid("7a000000-0000-0000-0000-000000000003"), new Guid("36000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "On-prem SIEM log correlation appliance", true, "SIEM Appliance", 1, "SEC-8003", 8999.00m, new Guid("01000000-0000-0000-0000-000000000006"), "EA", null },
                    { new Guid("7a000000-0000-0000-0000-000000000004"), new Guid("36000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSL VPN concentrator, 500 concurrent tunnels", true, "VPN Concentrator", 2, "SEC-8004", 2199.00m, new Guid("01000000-0000-0000-0000-000000000006"), "EA", null },
                    { new Guid("7a000000-0000-0000-0000-000000000005"), new Guid("36000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Annual threat intelligence feed subscription", true, "Threat Intel License", 1, "SEC-8005", 1200.00m, new Guid("01000000-0000-0000-0000-000000000006"), "EA", null },
                    { new Guid("7a000000-0000-0000-0000-000000000006"), new Guid("36000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "USB CAC/PIV smart card reader", true, "Smart Card Reader", 10, "SEC-8006", 29.00m, new Guid("01000000-0000-0000-0000-000000000006"), "EA", null }
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "TenantId", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("64000000-0000-0000-0000-000000000001"), "S1", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rack S1", new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("65000000-0000-0000-0000-000000000001"), "N1", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rack N1", new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("66000000-0000-0000-0000-000000000001"), "V1", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Vault V1", new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("24000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@cloudpeak.local", "CloudPeak Administrator", true, "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("24000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "warehouse@cloudpeak.local", "CloudPeak Warehouse Staff", true, "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("25000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@netbridge.local", "NetBridge Administrator", true, "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("25000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "warehouse@netbridge.local", "NetBridge Warehouse Staff", true, "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("26000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@shieldcore.local", "ShieldCore Administrator", true, "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("26000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "warehouse@shieldcore.local", "ShieldCore Warehouse Staff", true, "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=", new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "audit_logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "EntityId", "EntityName", "PerformedAt", "PerformedByUserId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b9000000-0000-0000-0000-000000000001"), "PurchaseOrderCreated", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Created completed purchase order SAAS-2026-003 from CloudStack Hardware.", new Guid("b5000000-0000-0000-0000-000000000005"), "PurchaseOrder", new DateTime(2026, 3, 6, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("b9000000-0000-0000-0000-000000000002"), "GoodsReceiptPosted", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Received 3 NAS storage units against SAAS-2026-003.", new Guid("b6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new DateTime(2026, 3, 15, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("c9000000-0000-0000-0000-000000000001"), "PurchaseOrderCreated", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Created completed purchase order ITST-2026-003 from AcceParts Direct.", new Guid("c5000000-0000-0000-0000-000000000005"), "PurchaseOrder", new DateTime(2026, 3, 7, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("c9000000-0000-0000-0000-000000000002"), "GoodsReceiptPosted", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Received 100 Cat6 patch cables against ITST-2026-003.", new Guid("c6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new DateTime(2026, 3, 16, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("d9000000-0000-0000-0000-000000000001"), "PurchaseOrderCreated", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Created completed purchase order SHLD-2026-003 from SecureKey Technologies.", new Guid("d5000000-0000-0000-0000-000000000005"), "PurchaseOrder", new DateTime(2026, 3, 9, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("d9000000-0000-0000-0000-000000000002"), "GoodsReceiptPosted", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Received 25 hardware security keys against SHLD-2026-003.", new Guid("d6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new DateTime(2026, 3, 18, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "inventory_balances",
                columns: new[] { "Id", "CreatedAt", "ItemId", "LocationId", "QuantityAvailable", "QuantityOnHand", "QuantityReserved", "TenantId", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("86000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000001"), new Guid("64000000-0000-0000-0000-000000000001"), 18, 20, 2, new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("86000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000002"), new Guid("64000000-0000-0000-0000-000000000001"), 14, 15, 1, new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("86000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000003"), new Guid("64000000-0000-0000-0000-000000000001"), 7, 8, 1, new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("86000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000004"), new Guid("64000000-0000-0000-0000-000000000001"), 22, 25, 3, new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("86000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000005"), new Guid("64000000-0000-0000-0000-000000000001"), 5, 5, 0, new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("86000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000006"), new Guid("64000000-0000-0000-0000-000000000001"), 4, 4, 0, new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("87000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000001"), new Guid("65000000-0000-0000-0000-000000000001"), 5, 6, 1, new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("87000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000002"), new Guid("65000000-0000-0000-0000-000000000001"), 8, 10, 2, new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("87000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000003"), new Guid("65000000-0000-0000-0000-000000000001"), 12, 15, 3, new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("87000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000004"), new Guid("65000000-0000-0000-0000-000000000001"), 6, 7, 1, new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("87000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000005"), new Guid("65000000-0000-0000-0000-000000000001"), 18, 20, 2, new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("87000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000006"), new Guid("65000000-0000-0000-0000-000000000001"), 200, 200, 0, new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("88000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000001"), new Guid("66000000-0000-0000-0000-000000000001"), 3, 4, 1, new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("88000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000002"), new Guid("66000000-0000-0000-0000-000000000001"), 45, 50, 5, new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("88000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000003"), new Guid("66000000-0000-0000-0000-000000000001"), 2, 2, 0, new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("88000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000004"), new Guid("66000000-0000-0000-0000-000000000001"), 4, 5, 1, new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("88000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000005"), new Guid("66000000-0000-0000-0000-000000000001"), 3, 3, 0, new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("88000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000006"), new Guid("66000000-0000-0000-0000-000000000001"), 28, 30, 2, new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "inventory_transactions",
                columns: new[] { "Id", "BalanceAfter", "CreatedAt", "ItemId", "LocationId", "PerformedAt", "PerformedByUserId", "QuantityChange", "Reason", "ReferenceId", "ReferenceType", "TenantId", "TransactionType", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("b7000000-0000-0000-0000-000000000001"), 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000006"), new Guid("64000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 15, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000002"), 3, null, new Guid("b6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new Guid("01000000-0000-0000-0000-000000000004"), 1, null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("b7000000-0000-0000-0000-000000000002"), 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000003"), new Guid("64000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 19, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000002"), -2, "Issued to new engineering hires", null, "DevSetup", new Guid("01000000-0000-0000-0000-000000000004"), 2, null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("b7000000-0000-0000-0000-000000000003"), 20, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000001"), new Guid("64000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 23, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000001"), 2, "Audit found unrecorded license seat", new Guid("b8000000-0000-0000-0000-000000000001"), "StockAdjustment", new Guid("01000000-0000-0000-0000-000000000004"), 3, null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("c7000000-0000-0000-0000-000000000001"), 200, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000006"), new Guid("65000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 16, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000002"), 100, null, new Guid("c6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new Guid("01000000-0000-0000-0000-000000000005"), 1, null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("c7000000-0000-0000-0000-000000000002"), 15, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000003"), new Guid("65000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 20, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000002"), -5, "Deployed to Contoso client site", null, "ClientDeployment", new Guid("01000000-0000-0000-0000-000000000005"), 2, null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("c7000000-0000-0000-0000-000000000003"), 10, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000002"), new Guid("65000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 24, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000001"), 1, "Cycle count found extra switch in receiving", new Guid("c8000000-0000-0000-0000-000000000001"), "StockAdjustment", new Guid("01000000-0000-0000-0000-000000000005"), 3, null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("d7000000-0000-0000-0000-000000000001"), 50, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000002"), new Guid("66000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 18, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000002"), 25, null, new Guid("d6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new Guid("01000000-0000-0000-0000-000000000006"), 1, null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("d7000000-0000-0000-0000-000000000002"), 4, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000001"), new Guid("66000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 21, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000002"), -1, "Deployed firewall to enterprise client", null, "ClientDeployment", new Guid("01000000-0000-0000-0000-000000000006"), 2, null, new Guid("56000000-0000-0000-0000-000000000001") },
                    { new Guid("d7000000-0000-0000-0000-000000000003"), 30, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000006"), new Guid("66000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 26, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000001"), 5, "Found unregistered readers in secure vault", new Guid("d8000000-0000-0000-0000-000000000001"), "StockAdjustment", new Guid("01000000-0000-0000-0000-000000000006"), 3, null, new Guid("56000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "purchase_orders",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ExpectedDate", "OrderDate", "PoNumber", "Status", "SupplierId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b5000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), "SAAS-2026-001", 1, new Guid("44000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("b5000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "SAAS-2026-002", 2, new Guid("44000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("b5000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), "SAAS-2026-003", 4, new Guid("44000000-0000-0000-0000-000000000003"), new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("c5000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), "ITST-2026-001", 1, new Guid("45000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("c5000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Utc), "ITST-2026-002", 2, new Guid("45000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("c5000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), "ITST-2026-003", 4, new Guid("45000000-0000-0000-0000-000000000003"), new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("d5000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), "SHLD-2026-001", 1, new Guid("46000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("d5000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), "SHLD-2026-002", 2, new Guid("46000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("d5000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), "SHLD-2026-003", 4, new Guid("46000000-0000-0000-0000-000000000003"), new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "stock_adjustments",
                columns: new[] { "Id", "AdjustmentType", "CreatedAt", "ItemId", "LocationId", "PerformedAt", "PerformedByUserId", "QuantityDelta", "Reason", "TenantId", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("b8000000-0000-0000-0000-000000000001"), 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000001"), new Guid("64000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 23, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000001"), 2, "Audit found unrecorded license seat", new Guid("01000000-0000-0000-0000-000000000004"), null, new Guid("54000000-0000-0000-0000-000000000001") },
                    { new Guid("c8000000-0000-0000-0000-000000000001"), 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000002"), new Guid("65000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 24, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000001"), 1, "Cycle count found extra switch in receiving", new Guid("01000000-0000-0000-0000-000000000005"), null, new Guid("55000000-0000-0000-0000-000000000001") },
                    { new Guid("d8000000-0000-0000-0000-000000000001"), 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000006"), new Guid("66000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 26, 14, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000001"), 5, "Found unregistered readers in secure vault", new Guid("01000000-0000-0000-0000-000000000006"), null, new Guid("56000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "supplier_items",
                columns: new[] { "Id", "CreatedAt", "ItemId", "SupplierId", "SupplierSku", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("77000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000001"), new Guid("44000000-0000-0000-0000-000000000001"), "LH-VS-6001", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("77000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000002"), new Guid("44000000-0000-0000-0000-000000000001"), "LH-JB-6002", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("77000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000003"), new Guid("44000000-0000-0000-0000-000000000002"), "DG-MBP-6003", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("77000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000004"), new Guid("44000000-0000-0000-0000-000000000002"), "DG-KB-6004", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("77000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000005"), new Guid("44000000-0000-0000-0000-000000000003"), "CS-AWS-6005", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("77000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000006"), new Guid("44000000-0000-0000-0000-000000000003"), "CS-NAS-6006", new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("79000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000001"), new Guid("45000000-0000-0000-0000-000000000001"), "NC-CIS-7001", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("79000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000002"), new Guid("45000000-0000-0000-0000-000000000001"), "NC-POE-7002", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("79000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000003"), new Guid("45000000-0000-0000-0000-000000000002"), "DM-DEL-7003", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("79000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000004"), new Guid("45000000-0000-0000-0000-000000000002"), "DM-LJ-7004", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("79000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000005"), new Guid("45000000-0000-0000-0000-000000000003"), "AP-MS-7005", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("79000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000006"), new Guid("45000000-0000-0000-0000-000000000003"), "AP-PC-7006", new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("7b000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000001"), new Guid("46000000-0000-0000-0000-000000000001"), "FT-FW-8001", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("7b000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000003"), new Guid("46000000-0000-0000-0000-000000000001"), "FT-SIEM-8003", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("7b000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000004"), new Guid("46000000-0000-0000-0000-000000000002"), "ZT-VPN-8004", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("7b000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000005"), new Guid("46000000-0000-0000-0000-000000000002"), "ZT-TI-8005", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("7b000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000002"), new Guid("46000000-0000-0000-0000-000000000003"), "SK-HSK-8002", new Guid("01000000-0000-0000-0000-000000000006"), null },
                    { new Guid("7b000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000006"), new Guid("46000000-0000-0000-0000-000000000003"), "SK-SCR-8006", new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("24000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("24000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("25000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("25000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("26000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("26000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "goods_receipts",
                columns: new[] { "Id", "CreatedAt", "PurchaseOrderId", "ReceiptNumber", "ReceivedAt", "ReceivedByUserId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b6000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b5000000-0000-0000-0000-000000000005"), "GR-SAAS-001", new DateTime(2026, 3, 15, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("24000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("c6000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c5000000-0000-0000-0000-000000000005"), "GR-ITST-001", new DateTime(2026, 3, 16, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("25000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("d6000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d5000000-0000-0000-0000-000000000005"), "GR-SHLD-001", new DateTime(2026, 3, 18, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("26000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000006"), null }
                });

            migrationBuilder.InsertData(
                table: "purchase_order_lines",
                columns: new[] { "Id", "CreatedAt", "ItemId", "OrderedQuantity", "PurchaseOrderId", "ReceivedQuantity", "TenantId", "UnitCost", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b5000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000001"), 10, new Guid("b5000000-0000-0000-0000-000000000001"), 0, new Guid("01000000-0000-0000-0000-000000000004"), 530.00m, null },
                    { new Guid("b5000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000003"), 5, new Guid("b5000000-0000-0000-0000-000000000003"), 0, new Guid("01000000-0000-0000-0000-000000000004"), 1950.00m, null },
                    { new Guid("b5000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("76000000-0000-0000-0000-000000000006"), 3, new Guid("b5000000-0000-0000-0000-000000000005"), 3, new Guid("01000000-0000-0000-0000-000000000004"), 1450.00m, null },
                    { new Guid("c5000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000001"), 4, new Guid("c5000000-0000-0000-0000-000000000001"), 0, new Guid("01000000-0000-0000-0000-000000000005"), 1850.00m, null },
                    { new Guid("c5000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000003"), 10, new Guid("c5000000-0000-0000-0000-000000000003"), 0, new Guid("01000000-0000-0000-0000-000000000005"), 820.00m, null },
                    { new Guid("c5000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("78000000-0000-0000-0000-000000000006"), 100, new Guid("c5000000-0000-0000-0000-000000000005"), 100, new Guid("01000000-0000-0000-0000-000000000005"), 3.40m, null },
                    { new Guid("d5000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000001"), 2, new Guid("d5000000-0000-0000-0000-000000000001"), 0, new Guid("01000000-0000-0000-0000-000000000006"), 3400.00m, null },
                    { new Guid("d5000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000004"), 3, new Guid("d5000000-0000-0000-0000-000000000003"), 0, new Guid("01000000-0000-0000-0000-000000000006"), 2150.00m, null },
                    { new Guid("d5000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7a000000-0000-0000-0000-000000000002"), 25, new Guid("d5000000-0000-0000-0000-000000000005"), 25, new Guid("01000000-0000-0000-0000-000000000006"), 47.00m, null }
                });

            migrationBuilder.InsertData(
                table: "goods_receipt_lines",
                columns: new[] { "Id", "CreatedAt", "GoodsReceiptId", "ItemId", "PurchaseOrderLineId", "ReceivedQuantity", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b6000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b6000000-0000-0000-0000-000000000001"), new Guid("76000000-0000-0000-0000-000000000006"), new Guid("b5000000-0000-0000-0000-000000000006"), 3, new Guid("01000000-0000-0000-0000-000000000004"), null },
                    { new Guid("c6000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c6000000-0000-0000-0000-000000000001"), new Guid("78000000-0000-0000-0000-000000000006"), new Guid("c5000000-0000-0000-0000-000000000006"), 100, new Guid("01000000-0000-0000-0000-000000000005"), null },
                    { new Guid("d6000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d6000000-0000-0000-0000-000000000001"), new Guid("7a000000-0000-0000-0000-000000000002"), new Guid("d5000000-0000-0000-0000-000000000006"), 25, new Guid("01000000-0000-0000-0000-000000000006"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("b9000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("b9000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("c9000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("c9000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("d9000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("d9000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("b6000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("c6000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("d6000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("86000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("86000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("86000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("86000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("86000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("86000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("87000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("87000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("87000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("87000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("87000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("87000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("88000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("88000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("88000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("88000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("88000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("88000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("b7000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("b7000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("b7000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("c7000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("c7000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("c7000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("d7000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("d7000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("d7000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("b5000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("b5000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("c5000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("c5000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("d5000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("d5000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("b8000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("c8000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("d8000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("77000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("77000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("77000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("77000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("77000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("77000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("79000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("79000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("79000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("79000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("79000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("79000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("7b000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("7b000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("7b000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("7b000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("7b000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("7b000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("24000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("24000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("25000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("25000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("26000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("26000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("b6000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("c6000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("d6000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("76000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("76000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("76000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("76000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("76000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("78000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("78000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("78000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("78000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("78000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7a000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7a000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7a000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7a000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7a000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "Id",
                keyValue: new Guid("64000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "Id",
                keyValue: new Guid("65000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "Id",
                keyValue: new Guid("66000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("b5000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("c5000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("d5000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("b5000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("b5000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("c5000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("c5000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("d5000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("d5000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("34000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("34000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("35000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("35000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("36000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("36000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("76000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("78000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("7a000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("b5000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("c5000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("d5000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("44000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("44000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("45000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("45000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("46000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("46000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("24000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("25000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("26000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "warehouses",
                keyColumn: "Id",
                keyValue: new Guid("54000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "warehouses",
                keyColumn: "Id",
                keyValue: new Guid("55000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "warehouses",
                keyColumn: "Id",
                keyValue: new Guid("56000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("34000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("35000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("36000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("44000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("45000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("46000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("24000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("25000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("26000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "Id",
                keyValue: new Guid("01000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "Id",
                keyValue: new Guid("01000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "Id",
                keyValue: new Guid("01000000-0000-0000-0000-000000000006"));
        }
    }
}
