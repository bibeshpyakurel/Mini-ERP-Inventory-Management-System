using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClearErp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MultiTenantSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_warehouses_Code",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_Email",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_purchase_orders_PoNumber",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "IX_items_Sku",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_inventory_balances_ItemId_WarehouseId_LocationId",
                table: "inventory_balances");

            migrationBuilder.DropIndex(
                name: "IX_categories_Name",
                table: "categories");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "warehouses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "suppliers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "supplier_items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "stock_adjustments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "purchase_orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "purchase_order_lines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "inventory_transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "inventory_balances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "goods_receipts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "goods_receipt_lines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "audit_logs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Industry = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenants", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000005"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000006"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000007"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("94000000-0000-0000-0000-000000000008"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CreatedAt", "Name", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("32000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Displays", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("32000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Networking", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("32000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Compute", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("33000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dry Goods", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("33000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Refrigerated", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("33000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Packaging", new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.UpdateData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("91000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("91000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("91000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("91000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000005"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("80000000-0000-0000-0000-000000000006"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000005"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000006"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("92000000-0000-0000-0000-000000000007"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000005"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("70000000-0000-0000-0000-000000000006"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "locations",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000006"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000008"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000010"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000012"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000013"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000014"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000005"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000007"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000009"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("90000000-0000-0000-0000-000000000011"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("93000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("93000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("93000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000004"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000005"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("71000000-0000-0000-0000-000000000006"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000002"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.UpdateData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0000-000000000003"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "suppliers",
                columns: new[] { "Id", "ContactName", "CreatedAt", "Email", "IsActive", "Name", "Notes", "Phone", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("42000000-0000-0000-0000-000000000001"), "Alex Kim", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "supply@techsource.example", true, "TechSource Global", null, "555-0200", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("42000000-0000-0000-0000-000000000002"), "Sam Rivera", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "orders@digiparts.example", true, "DigiParts Distribution", null, "555-0210", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("42000000-0000-0000-0000-000000000003"), "Jamie Chen", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sales@novatech.example", true, "NovaTech Components", null, "555-0220", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("43000000-0000-0000-0000-000000000001"), "Casey Brown", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "orders@farmfresh.example", true, "FarmFresh Direct", null, "555-0300", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("43000000-0000-0000-0000-000000000002"), "Drew Wilson", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "supply@packworld.example", true, "PackWorld Supplies", null, "555-0310", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("43000000-0000-0000-0000-000000000003"), "Riley Garcia", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "trade@beverageco.example", true, "BeverageCo International", null, "555-0320", new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "Id", "CreatedAt", "Industry", "IsActive", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Furniture", true, "ClearFurniture Corp", "furniture", null },
                    { new Guid("01000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Electronics", true, "TechFlow Electronics", "electronics", null },
                    { new Guid("01000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Food & Beverage", true, "FreshFoods Co", "food-beverage", null }
                });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"),
                columns: new[] { "Email", "TenantId" },
                values: new object[] { "admin@clearfurniture.local", new Guid("01000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                columns: new[] { "Email", "TenantId" },
                values: new object[] { "warehouse@clearfurniture.local", new Guid("01000000-0000-0000-0000-000000000001") });

            migrationBuilder.UpdateData(
                table: "warehouses",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0000-000000000001"),
                column: "TenantId",
                value: new Guid("01000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "warehouses",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("52000000-0000-0000-0000-000000000001"), "ELEC", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Electronics Warehouse", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("53000000-0000-0000-0000-000000000001"), "COLD", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cold Storage Warehouse", new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsActive", "Name", "ReorderLevel", "Sku", "StandardCost", "TenantId", "Unit", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("72000000-0000-0000-0000-000000000001"), new Guid("32000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "27-inch 4K IPS display", true, "27\" Monitor", 8, "MON-2001", 349.99m, new Guid("01000000-0000-0000-0000-000000000002"), "EA", null },
                    { new Guid("72000000-0000-0000-0000-000000000002"), new Guid("32000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Managed 24-port gigabit network switch", true, "24-Port Switch", 5, "SWT-2002", 499.00m, new Guid("01000000-0000-0000-0000-000000000002"), "EA", null },
                    { new Guid("72000000-0000-0000-0000-000000000003"), new Guid("32000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "1U rack-mount server, 16-core, 64 GB RAM", true, "Rack Server 1U", 3, "SRV-2003", 2499.00m, new Guid("01000000-0000-0000-0000-000000000002"), "EA", null },
                    { new Guid("72000000-0000-0000-0000-000000000004"), new Guid("32000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "7-port USB-C docking hub", true, "USB-C Hub 7-Port", 15, "HUB-2004", 69.99m, new Guid("01000000-0000-0000-0000-000000000002"), "EA", null },
                    { new Guid("72000000-0000-0000-0000-000000000005"), new Guid("32000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "14-inch business laptop, i7, 16 GB RAM", true, "Business Laptop", 5, "LPT-2005", 1199.00m, new Guid("01000000-0000-0000-0000-000000000002"), "EA", null },
                    { new Guid("72000000-0000-0000-0000-000000000006"), new Guid("32000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "1080p USB webcam with built-in mic", true, "HD Webcam", 12, "CAM-2006", 89.99m, new Guid("01000000-0000-0000-0000-000000000002"), "EA", null },
                    { new Guid("74000000-0000-0000-0000-000000000001"), new Guid("33000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "All-purpose wheat flour, 25 kg sack", true, "Wheat Flour", 500, "FLR-4001", 0.85m, new Guid("01000000-0000-0000-0000-000000000003"), "KG", null },
                    { new Guid("74000000-0000-0000-0000-000000000002"), new Guid("33000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cold-pressed EVOO, 5-litre tin", true, "Extra Virgin Olive Oil", 100, "OIL-4002", 8.50m, new Guid("01000000-0000-0000-0000-000000000003"), "LTR", null },
                    { new Guid("74000000-0000-0000-0000-000000000003"), new Guid("33000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Double-wall kraft box 30x20x15 cm", true, "Kraft Shipping Box", 1000, "BOX-4003", 0.45m, new Guid("01000000-0000-0000-0000-000000000003"), "EA", null },
                    { new Guid("74000000-0000-0000-0000-000000000004"), new Guid("33000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "BPA-free PET water bottle, carton of 24", true, "500ml PET Bottle", 200, "BTL-4004", 4.20m, new Guid("01000000-0000-0000-0000-000000000003"), "CTN", null },
                    { new Guid("74000000-0000-0000-0000-000000000005"), new Guid("33000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Refined white cane sugar, 50 kg bag", true, "Cane Sugar", 300, "SGR-4005", 0.72m, new Guid("01000000-0000-0000-0000-000000000003"), "KG", null },
                    { new Guid("74000000-0000-0000-0000-000000000006"), new Guid("33000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Premium long-grain white rice, 25 kg sack", true, "Long Grain Rice", 400, "RCE-4006", 1.10m, new Guid("01000000-0000-0000-0000-000000000003"), "KG", null }
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "TenantId", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("62000000-0000-0000-0000-000000000001"), "B1", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rack B1", new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("63000000-0000-0000-0000-000000000001"), "C1", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bay C1", new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@techflow-electronics.local", "Electronics Administrator", true, "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("22000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "warehouse@techflow-electronics.local", "Electronics Warehouse Staff", true, "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("23000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "admin@freshfoods.local", "Food & Beverage Administrator", true, "100000.D7/na2fAshvnIG4dYnDY3w==.r1Wxdl0Svjd+hM1EFn3gwvocm0IuZvGY0HTcOEAuGUM=", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("23000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "warehouse@freshfoods.local", "Food & Beverage Warehouse Staff", true, "100000.yjJgxVnzj85lVCaN8of6NA==.NTw4Z2FymPSWFp5BzyaC8J1F9NpH6x8el2ST+FgofYE=", new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "audit_logs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "EntityId", "EntityName", "PerformedAt", "PerformedByUserId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("99000000-0000-0000-0000-000000000001"), "PurchaseOrderCreated", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Created completed purchase order ELEC-2026-003 from NovaTech Components.", new Guid("95000000-0000-0000-0000-000000000005"), "PurchaseOrder", new DateTime(2026, 3, 5, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("99000000-0000-0000-0000-000000000002"), "GoodsReceiptPosted", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Received 20 HD webcams against ELEC-2026-003.", new Guid("96000000-0000-0000-0000-000000000001"), "GoodsReceipt", new DateTime(2026, 3, 14, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("a9000000-0000-0000-0000-000000000001"), "PurchaseOrderCreated", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Created completed purchase order FOOD-2026-003 from PackWorld Supplies.", new Guid("a5000000-0000-0000-0000-000000000005"), "PurchaseOrder", new DateTime(2026, 3, 8, 8, 30, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("a9000000-0000-0000-0000-000000000002"), "GoodsReceiptPosted", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Received 2000 kraft boxes against FOOD-2026-003.", new Guid("a6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new DateTime(2026, 3, 16, 8, 30, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "inventory_balances",
                columns: new[] { "Id", "CreatedAt", "ItemId", "LocationId", "QuantityAvailable", "QuantityOnHand", "QuantityReserved", "TenantId", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("82000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), new Guid("62000000-0000-0000-0000-000000000001"), 22, 25, 3, new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("82000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000002"), new Guid("62000000-0000-0000-0000-000000000001"), 13, 15, 2, new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("82000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), new Guid("62000000-0000-0000-0000-000000000001"), 7, 8, 1, new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("82000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000004"), new Guid("62000000-0000-0000-0000-000000000001"), 35, 40, 5, new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("82000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000005"), new Guid("62000000-0000-0000-0000-000000000001"), 10, 12, 2, new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("82000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000006"), new Guid("62000000-0000-0000-0000-000000000001"), 26, 30, 4, new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("84000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000001"), new Guid("63000000-0000-0000-0000-000000000001"), 450, 500, 50, new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("84000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000002"), new Guid("63000000-0000-0000-0000-000000000001"), 180, 200, 20, new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("84000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000003"), new Guid("63000000-0000-0000-0000-000000000001"), 900, 1000, 100, new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("84000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000004"), new Guid("63000000-0000-0000-0000-000000000001"), 2160, 2400, 240, new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("84000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000005"), new Guid("63000000-0000-0000-0000-000000000001"), 315, 350, 35, new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("84000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000006"), new Guid("63000000-0000-0000-0000-000000000001"), 720, 800, 80, new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "inventory_transactions",
                columns: new[] { "Id", "BalanceAfter", "CreatedAt", "ItemId", "LocationId", "PerformedAt", "PerformedByUserId", "QuantityChange", "Reason", "ReferenceId", "ReferenceType", "TenantId", "TransactionType", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("97000000-0000-0000-0000-000000000001"), 30, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000006"), new Guid("62000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 14, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000002"), 20, null, new Guid("96000000-0000-0000-0000-000000000001"), "GoodsReceipt", new Guid("01000000-0000-0000-0000-000000000002"), 1, null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("97000000-0000-0000-0000-000000000002"), 25, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), new Guid("62000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 18, 9, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000002"), -5, "Monitors deployed to showroom demo stations", null, "DemoSetup", new Guid("01000000-0000-0000-0000-000000000002"), 2, null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("97000000-0000-0000-0000-000000000003"), 8, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), new Guid("62000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 22, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000001"), 2, "Cycle count corrected server count", new Guid("98000000-0000-0000-0000-000000000001"), "StockAdjustment", new Guid("01000000-0000-0000-0000-000000000002"), 3, null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("a7000000-0000-0000-0000-000000000001"), 1000, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000003"), new Guid("63000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 16, 8, 30, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000002"), 2000, null, new Guid("a6000000-0000-0000-0000-000000000001"), "GoodsReceipt", new Guid("01000000-0000-0000-0000-000000000003"), 1, null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("a7000000-0000-0000-0000-000000000002"), 500, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000001"), new Guid("63000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 20, 7, 0, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000002"), -100, "Issued to production line batch #B-042", null, "ProductionOrder", new Guid("01000000-0000-0000-0000-000000000003"), 2, null, new Guid("53000000-0000-0000-0000-000000000001") },
                    { new Guid("a7000000-0000-0000-0000-000000000003"), 800, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000006"), new Guid("63000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 25, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000001"), 50, "Recount corrected rice inventory", new Guid("a8000000-0000-0000-0000-000000000001"), "StockAdjustment", new Guid("01000000-0000-0000-0000-000000000003"), 3, null, new Guid("53000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "purchase_orders",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "ExpectedDate", "OrderDate", "PoNumber", "Status", "SupplierId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("95000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), "ELEC-2026-001", 1, new Guid("42000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("95000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Utc), "ELEC-2026-002", 2, new Guid("42000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("95000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), "ELEC-2026-003", 4, new Guid("42000000-0000-0000-0000-000000000003"), new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("a5000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), "FOOD-2026-001", 1, new Guid("43000000-0000-0000-0000-000000000001"), new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("a5000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000001"), new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), "FOOD-2026-002", 2, new Guid("43000000-0000-0000-0000-000000000003"), new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("a5000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), "FOOD-2026-003", 4, new Guid("43000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "stock_adjustments",
                columns: new[] { "Id", "AdjustmentType", "CreatedAt", "ItemId", "LocationId", "PerformedAt", "PerformedByUserId", "QuantityDelta", "Reason", "TenantId", "UpdatedAt", "WarehouseId" },
                values: new object[,]
                {
                    { new Guid("98000000-0000-0000-0000-000000000001"), 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), new Guid("62000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 22, 14, 30, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000001"), 2, "Cycle count corrected server count", new Guid("01000000-0000-0000-0000-000000000002"), null, new Guid("52000000-0000-0000-0000-000000000001") },
                    { new Guid("a8000000-0000-0000-0000-000000000001"), 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000006"), new Guid("63000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 25, 11, 0, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000001"), 50, "Recount corrected rice inventory", new Guid("01000000-0000-0000-0000-000000000003"), null, new Guid("53000000-0000-0000-0000-000000000001") }
                });

            migrationBuilder.InsertData(
                table: "supplier_items",
                columns: new[] { "Id", "CreatedAt", "ItemId", "SupplierId", "SupplierSku", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("73000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), new Guid("42000000-0000-0000-0000-000000000001"), "TS-MON-2001", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("73000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000003"), new Guid("42000000-0000-0000-0000-000000000001"), "TS-SRV-2003", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("73000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000002"), new Guid("42000000-0000-0000-0000-000000000002"), "DP-SWT-2002", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("73000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000004"), new Guid("42000000-0000-0000-0000-000000000002"), "DP-HUB-2004", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("73000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000005"), new Guid("42000000-0000-0000-0000-000000000003"), "NT-LPT-2005", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("73000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000006"), new Guid("42000000-0000-0000-0000-000000000003"), "NT-CAM-2006", new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("75000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000001"), new Guid("43000000-0000-0000-0000-000000000001"), "FF-FLR-4001", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("75000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000005"), new Guid("43000000-0000-0000-0000-000000000001"), "FF-SGR-4005", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("75000000-0000-0000-0000-000000000003"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000002"), new Guid("43000000-0000-0000-0000-000000000003"), "BC-OIL-4002", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("75000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000004"), new Guid("43000000-0000-0000-0000-000000000003"), "BC-BTL-4004", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("75000000-0000-0000-0000-000000000005"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000003"), new Guid("43000000-0000-0000-0000-000000000002"), "PW-BOX-4003", new Guid("01000000-0000-0000-0000-000000000003"), null },
                    { new Guid("75000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000006"), new Guid("43000000-0000-0000-0000-000000000002"), "PW-RCE-4006", new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("22000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("22000000-0000-0000-0000-000000000002") },
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("23000000-0000-0000-0000-000000000001") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("23000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "goods_receipts",
                columns: new[] { "Id", "CreatedAt", "PurchaseOrderId", "ReceiptNumber", "ReceivedAt", "ReceivedByUserId", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("96000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("95000000-0000-0000-0000-000000000005"), "GR-ELEC-001", new DateTime(2026, 3, 14, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("22000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("a6000000-0000-0000-0000-000000000001"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a5000000-0000-0000-0000-000000000005"), "GR-FOOD-001", new DateTime(2026, 3, 16, 8, 30, 0, 0, DateTimeKind.Utc), new Guid("23000000-0000-0000-0000-000000000002"), new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.InsertData(
                table: "purchase_order_lines",
                columns: new[] { "Id", "CreatedAt", "ItemId", "OrderedQuantity", "PurchaseOrderId", "ReceivedQuantity", "TenantId", "UnitCost", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("95000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000001"), 20, new Guid("95000000-0000-0000-0000-000000000001"), 0, new Guid("01000000-0000-0000-0000-000000000002"), 340.00m, null },
                    { new Guid("95000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000002"), 10, new Guid("95000000-0000-0000-0000-000000000003"), 0, new Guid("01000000-0000-0000-0000-000000000002"), 490.00m, null },
                    { new Guid("95000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("72000000-0000-0000-0000-000000000006"), 20, new Guid("95000000-0000-0000-0000-000000000005"), 20, new Guid("01000000-0000-0000-0000-000000000002"), 85.00m, null },
                    { new Guid("a5000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000001"), 1000, new Guid("a5000000-0000-0000-0000-000000000001"), 0, new Guid("01000000-0000-0000-0000-000000000003"), 0.82m, null },
                    { new Guid("a5000000-0000-0000-0000-000000000004"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000004"), 500, new Guid("a5000000-0000-0000-0000-000000000003"), 0, new Guid("01000000-0000-0000-0000-000000000003"), 4.10m, null },
                    { new Guid("a5000000-0000-0000-0000-000000000006"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("74000000-0000-0000-0000-000000000003"), 2000, new Guid("a5000000-0000-0000-0000-000000000005"), 2000, new Guid("01000000-0000-0000-0000-000000000003"), 0.43m, null }
                });

            migrationBuilder.InsertData(
                table: "goods_receipt_lines",
                columns: new[] { "Id", "CreatedAt", "GoodsReceiptId", "ItemId", "PurchaseOrderLineId", "ReceivedQuantity", "TenantId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("96000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("96000000-0000-0000-0000-000000000001"), new Guid("72000000-0000-0000-0000-000000000006"), new Guid("95000000-0000-0000-0000-000000000006"), 20, new Guid("01000000-0000-0000-0000-000000000002"), null },
                    { new Guid("a6000000-0000-0000-0000-000000000002"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a6000000-0000-0000-0000-000000000001"), new Guid("74000000-0000-0000-0000-000000000003"), new Guid("a5000000-0000-0000-0000-000000000006"), 2000, new Guid("01000000-0000-0000-0000-000000000003"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_TenantId_Code",
                table: "warehouses",
                columns: new[] { "TenantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_TenantId_Email",
                table: "users",
                columns: new[] { "TenantId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_TenantId_Email",
                table: "suppliers",
                columns: new[] { "TenantId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_orders_TenantId_PoNumber",
                table: "purchase_orders",
                columns: new[] { "TenantId", "PoNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_TenantId_Sku",
                table: "items",
                columns: new[] { "TenantId", "Sku" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_balances_ItemId",
                table: "inventory_balances",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_balances_TenantId_ItemId_WarehouseId_LocationId",
                table: "inventory_balances",
                columns: new[] { "TenantId", "ItemId", "WarehouseId", "LocationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_TenantId_Name",
                table: "categories",
                columns: new[] { "TenantId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tenants_Slug",
                table: "tenants",
                column: "Slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_tenants_TenantId",
                table: "users",
                column: "TenantId",
                principalTable: "tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_tenants_TenantId",
                table: "users");

            migrationBuilder.DropTable(
                name: "tenants");

            migrationBuilder.DropIndex(
                name: "IX_warehouses_TenantId_Code",
                table: "warehouses");

            migrationBuilder.DropIndex(
                name: "IX_users_TenantId_Email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_suppliers_TenantId_Email",
                table: "suppliers");

            migrationBuilder.DropIndex(
                name: "IX_purchase_orders_TenantId_PoNumber",
                table: "purchase_orders");

            migrationBuilder.DropIndex(
                name: "IX_items_TenantId_Sku",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_inventory_balances_ItemId",
                table: "inventory_balances");

            migrationBuilder.DropIndex(
                name: "IX_inventory_balances_TenantId_ItemId_WarehouseId_LocationId",
                table: "inventory_balances");

            migrationBuilder.DropIndex(
                name: "IX_categories_TenantId_Name",
                table: "categories");

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("99000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("99000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("a9000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "audit_logs",
                keyColumn: "Id",
                keyValue: new Guid("a9000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("96000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "goods_receipt_lines",
                keyColumn: "Id",
                keyValue: new Guid("a6000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("82000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("82000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("82000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("82000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("82000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("82000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("84000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("84000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("84000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("84000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("84000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "inventory_balances",
                keyColumn: "Id",
                keyValue: new Guid("84000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("97000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("97000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("97000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("a7000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("a7000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "inventory_transactions",
                keyColumn: "Id",
                keyValue: new Guid("a7000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("95000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("95000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("a5000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("a5000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("98000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "stock_adjustments",
                keyColumn: "Id",
                keyValue: new Guid("a8000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("73000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("75000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("75000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("75000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("75000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("75000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "supplier_items",
                keyColumn: "Id",
                keyValue: new Guid("75000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("22000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("22000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("23000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("23000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("96000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "goods_receipts",
                keyColumn: "Id",
                keyValue: new Guid("a6000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "Id",
                keyValue: new Guid("62000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "locations",
                keyColumn: "Id",
                keyValue: new Guid("63000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("95000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "purchase_order_lines",
                keyColumn: "Id",
                keyValue: new Guid("a5000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("95000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("95000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("a5000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("a5000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("32000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("32000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("33000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("33000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("72000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "items",
                keyColumn: "Id",
                keyValue: new Guid("74000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("95000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "purchase_orders",
                keyColumn: "Id",
                keyValue: new Guid("a5000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("42000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("42000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("43000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("43000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("22000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("23000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "warehouses",
                keyColumn: "Id",
                keyValue: new Guid("52000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "warehouses",
                keyColumn: "Id",
                keyValue: new Guid("53000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("32000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("33000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("42000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "suppliers",
                keyColumn: "Id",
                keyValue: new Guid("43000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("22000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("23000000-0000-0000-0000-000000000001"));

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "warehouses");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "suppliers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "supplier_items");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "stock_adjustments");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "purchase_orders");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "purchase_order_lines");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "items");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "inventory_transactions");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "inventory_balances");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "goods_receipts");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "goods_receipt_lines");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "audit_logs");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"),
                column: "Email",
                value: "admin@clearerp.local");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"),
                column: "Email",
                value: "warehouse@clearerp.local");

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_Code",
                table: "warehouses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_Email",
                table: "suppliers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_orders_PoNumber",
                table: "purchase_orders",
                column: "PoNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_Sku",
                table: "items",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_inventory_balances_ItemId_WarehouseId_LocationId",
                table: "inventory_balances",
                columns: new[] { "ItemId", "WarehouseId", "LocationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_Name",
                table: "categories",
                column: "Name",
                unique: true);
        }
    }
}
