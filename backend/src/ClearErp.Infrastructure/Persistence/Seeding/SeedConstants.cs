namespace ClearErp.Infrastructure.Persistence.Seeding;

public static class SeedConstants
{
    // Tenants
    public static readonly Guid FurnitureTenantId    = Guid.Parse("01000000-0000-0000-0000-000000000001");
    public static readonly Guid ElectronicsTenantId  = Guid.Parse("01000000-0000-0000-0000-000000000002");
    public static readonly Guid FoodBeverageTenantId = Guid.Parse("01000000-0000-0000-0000-000000000003");
    public static readonly Guid SaasTenantId         = Guid.Parse("01000000-0000-0000-0000-000000000004");
    public static readonly Guid ItServicesTenantId   = Guid.Parse("01000000-0000-0000-0000-000000000005");
    public static readonly Guid CyberTenantId        = Guid.Parse("01000000-0000-0000-0000-000000000006");

    // Electronics tenant users
    public static readonly Guid ElecAdminUserId     = Guid.Parse("22000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecWarehouseUserId = Guid.Parse("22000000-0000-0000-0000-000000000002");

    // Electronics tenant data
    public static readonly Guid ElecDisplaysCategoryId   = Guid.Parse("32000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecNetworkingCategoryId = Guid.Parse("32000000-0000-0000-0000-000000000002");
    public static readonly Guid ElecComputeCategoryId    = Guid.Parse("32000000-0000-0000-0000-000000000003");

    public static readonly Guid TechSourceSupplierId = Guid.Parse("42000000-0000-0000-0000-000000000001");
    public static readonly Guid DigiPartsSupplierId  = Guid.Parse("42000000-0000-0000-0000-000000000002");
    public static readonly Guid NovaTechSupplierId   = Guid.Parse("42000000-0000-0000-0000-000000000003");

    public static readonly Guid ElecWarehouseId      = Guid.Parse("52000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecLocationId       = Guid.Parse("62000000-0000-0000-0000-000000000001");

    public static readonly Guid MonitorItemId        = Guid.Parse("72000000-0000-0000-0000-000000000001");
    public static readonly Guid SwitchItemId         = Guid.Parse("72000000-0000-0000-0000-000000000002");
    public static readonly Guid ServerItemId         = Guid.Parse("72000000-0000-0000-0000-000000000003");
    public static readonly Guid UsbHubItemId         = Guid.Parse("72000000-0000-0000-0000-000000000004");
    public static readonly Guid LaptopItemId         = Guid.Parse("72000000-0000-0000-0000-000000000005");
    public static readonly Guid WebcamItemId         = Guid.Parse("72000000-0000-0000-0000-000000000006");

    public static readonly Guid ElecSupplierItemId1  = Guid.Parse("73000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecSupplierItemId2  = Guid.Parse("73000000-0000-0000-0000-000000000002");
    public static readonly Guid ElecSupplierItemId3  = Guid.Parse("73000000-0000-0000-0000-000000000003");
    public static readonly Guid ElecSupplierItemId4  = Guid.Parse("73000000-0000-0000-0000-000000000004");
    public static readonly Guid ElecSupplierItemId5  = Guid.Parse("73000000-0000-0000-0000-000000000005");
    public static readonly Guid ElecSupplierItemId6  = Guid.Parse("73000000-0000-0000-0000-000000000006");

    public static readonly Guid ElecPODraftId        = Guid.Parse("95000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecPODraftLineId    = Guid.Parse("95000000-0000-0000-0000-000000000002");
    public static readonly Guid ElecPOApprovedId     = Guid.Parse("95000000-0000-0000-0000-000000000003");
    public static readonly Guid ElecPOApprovedLineId = Guid.Parse("95000000-0000-0000-0000-000000000004");
    public static readonly Guid ElecPOCompletedId    = Guid.Parse("95000000-0000-0000-0000-000000000005");
    public static readonly Guid ElecPOCompletedLineId= Guid.Parse("95000000-0000-0000-0000-000000000006");

    public static readonly Guid ElecGoodsReceiptId   = Guid.Parse("96000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecGoodsReceiptLineId=Guid.Parse("96000000-0000-0000-0000-000000000002");

    public static readonly Guid ElecTxn1Id           = Guid.Parse("97000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecTxn2Id           = Guid.Parse("97000000-0000-0000-0000-000000000002");
    public static readonly Guid ElecTxn3Id           = Guid.Parse("97000000-0000-0000-0000-000000000003");

    public static readonly Guid ElecAdj1Id           = Guid.Parse("98000000-0000-0000-0000-000000000001");

    public static readonly Guid ElecAuditLog1Id      = Guid.Parse("99000000-0000-0000-0000-000000000001");
    public static readonly Guid ElecAuditLog2Id      = Guid.Parse("99000000-0000-0000-0000-000000000002");

    // Food & Beverage tenant users
    public static readonly Guid FoodAdminUserId     = Guid.Parse("23000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodWarehouseUserId = Guid.Parse("23000000-0000-0000-0000-000000000002");

    // Food & Beverage tenant data
    public static readonly Guid FoodDryGoodsCategoryId   = Guid.Parse("33000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodRefrigeratedCategoryId = Guid.Parse("33000000-0000-0000-0000-000000000002");
    public static readonly Guid FoodPackagingCategoryId  = Guid.Parse("33000000-0000-0000-0000-000000000003");

    public static readonly Guid FarmFreshSupplierId  = Guid.Parse("43000000-0000-0000-0000-000000000001");
    public static readonly Guid PackWorldSupplierId  = Guid.Parse("43000000-0000-0000-0000-000000000002");
    public static readonly Guid BeverageCoSupplierId = Guid.Parse("43000000-0000-0000-0000-000000000003");

    public static readonly Guid FoodWarehouseId      = Guid.Parse("53000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodLocationId       = Guid.Parse("63000000-0000-0000-0000-000000000001");

    public static readonly Guid FlourItemId          = Guid.Parse("74000000-0000-0000-0000-000000000001");
    public static readonly Guid OliveOilItemId       = Guid.Parse("74000000-0000-0000-0000-000000000002");
    public static readonly Guid KraftBoxItemId       = Guid.Parse("74000000-0000-0000-0000-000000000003");
    public static readonly Guid WaterBottleItemId    = Guid.Parse("74000000-0000-0000-0000-000000000004");
    public static readonly Guid SugarItemId          = Guid.Parse("74000000-0000-0000-0000-000000000005");
    public static readonly Guid RiceItemId           = Guid.Parse("74000000-0000-0000-0000-000000000006");

    public static readonly Guid FoodSupplierItemId1  = Guid.Parse("75000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodSupplierItemId2  = Guid.Parse("75000000-0000-0000-0000-000000000002");
    public static readonly Guid FoodSupplierItemId3  = Guid.Parse("75000000-0000-0000-0000-000000000003");
    public static readonly Guid FoodSupplierItemId4  = Guid.Parse("75000000-0000-0000-0000-000000000004");
    public static readonly Guid FoodSupplierItemId5  = Guid.Parse("75000000-0000-0000-0000-000000000005");
    public static readonly Guid FoodSupplierItemId6  = Guid.Parse("75000000-0000-0000-0000-000000000006");

    public static readonly Guid FoodPODraftId        = Guid.Parse("A5000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodPODraftLineId    = Guid.Parse("A5000000-0000-0000-0000-000000000002");
    public static readonly Guid FoodPOApprovedId     = Guid.Parse("A5000000-0000-0000-0000-000000000003");
    public static readonly Guid FoodPOApprovedLineId = Guid.Parse("A5000000-0000-0000-0000-000000000004");
    public static readonly Guid FoodPOCompletedId    = Guid.Parse("A5000000-0000-0000-0000-000000000005");
    public static readonly Guid FoodPOCompletedLineId= Guid.Parse("A5000000-0000-0000-0000-000000000006");

    public static readonly Guid FoodGoodsReceiptId   = Guid.Parse("A6000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodGoodsReceiptLineId=Guid.Parse("A6000000-0000-0000-0000-000000000002");

    public static readonly Guid FoodTxn1Id           = Guid.Parse("A7000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodTxn2Id           = Guid.Parse("A7000000-0000-0000-0000-000000000002");
    public static readonly Guid FoodTxn3Id           = Guid.Parse("A7000000-0000-0000-0000-000000000003");

    public static readonly Guid FoodAdj1Id           = Guid.Parse("A8000000-0000-0000-0000-000000000001");

    public static readonly Guid FoodAuditLog1Id      = Guid.Parse("A9000000-0000-0000-0000-000000000001");
    public static readonly Guid FoodAuditLog2Id      = Guid.Parse("A9000000-0000-0000-0000-000000000002");

    public static readonly Guid AdminRoleId = Guid.Parse("10000000-0000-0000-0000-000000000001");
    public static readonly Guid InventoryManagerRoleId = Guid.Parse("10000000-0000-0000-0000-000000000002");
    public static readonly Guid WarehouseStaffRoleId = Guid.Parse("10000000-0000-0000-0000-000000000003");
    public static readonly Guid ViewerRoleId = Guid.Parse("10000000-0000-0000-0000-000000000004");

    public static readonly Guid AdminUserId = Guid.Parse("20000000-0000-0000-0000-000000000001");
    public static readonly Guid WarehouseUserId = Guid.Parse("20000000-0000-0000-0000-000000000002");

    public static readonly Guid SeatingCategoryId = Guid.Parse("30000000-0000-0000-0000-000000000001");
    public static readonly Guid StorageCategoryId = Guid.Parse("30000000-0000-0000-0000-000000000002");
    public static readonly Guid ComponentsCategoryId = Guid.Parse("30000000-0000-0000-0000-000000000003");

    public static readonly Guid AcmeSupplierId = Guid.Parse("40000000-0000-0000-0000-000000000001");
    public static readonly Guid NorthwoodSupplierId = Guid.Parse("40000000-0000-0000-0000-000000000002");
    public static readonly Guid EastlakeSupplierId = Guid.Parse("40000000-0000-0000-0000-000000000003");

    public static readonly Guid MainWarehouseId = Guid.Parse("50000000-0000-0000-0000-000000000001");
    public static readonly Guid MainAisleLocationId = Guid.Parse("60000000-0000-0000-0000-000000000001");

    public static readonly Guid TaskChairItemId = Guid.Parse("70000000-0000-0000-0000-000000000001");
    public static readonly Guid FilingCabinetItemId = Guid.Parse("70000000-0000-0000-0000-000000000002");
    public static readonly Guid DeskLegKitItemId = Guid.Parse("70000000-0000-0000-0000-000000000003");
    public static readonly Guid LoungeChairItemId = Guid.Parse("70000000-0000-0000-0000-000000000004");
    public static readonly Guid MobilePedestalItemId = Guid.Parse("70000000-0000-0000-0000-000000000005");
    public static readonly Guid ConferenceTableBaseItemId = Guid.Parse("70000000-0000-0000-0000-000000000006");

    public static readonly Guid AcmeTaskChairSupplierItemId = Guid.Parse("71000000-0000-0000-0000-000000000001");
    public static readonly Guid AcmeCabinetSupplierItemId = Guid.Parse("71000000-0000-0000-0000-000000000002");
    public static readonly Guid NorthwoodDeskLegSupplierItemId = Guid.Parse("71000000-0000-0000-0000-000000000003");
    public static readonly Guid EastlakeLoungeChairSupplierItemId = Guid.Parse("71000000-0000-0000-0000-000000000004");
    public static readonly Guid EastlakePedestalSupplierItemId = Guid.Parse("71000000-0000-0000-0000-000000000005");
    public static readonly Guid NorthwoodConferenceBaseSupplierItemId = Guid.Parse("71000000-0000-0000-0000-000000000006");

    public static readonly Guid DraftPurchaseOrderId = Guid.Parse("90000000-0000-0000-0000-000000000001");
    public static readonly Guid DraftPurchaseOrderLineId = Guid.Parse("90000000-0000-0000-0000-000000000002");
    public static readonly Guid ApprovedPurchaseOrderId = Guid.Parse("90000000-0000-0000-0000-000000000003");
    public static readonly Guid ApprovedPurchaseOrderLineId = Guid.Parse("90000000-0000-0000-0000-000000000004");
    public static readonly Guid PartialPurchaseOrderId = Guid.Parse("90000000-0000-0000-0000-000000000005");
    public static readonly Guid PartialPurchaseOrderLineId = Guid.Parse("90000000-0000-0000-0000-000000000006");
    public static readonly Guid CompletedPurchaseOrderId = Guid.Parse("90000000-0000-0000-0000-000000000007");
    public static readonly Guid CompletedPurchaseOrderLineId = Guid.Parse("90000000-0000-0000-0000-000000000008");
    public static readonly Guid CancelledPurchaseOrderId = Guid.Parse("90000000-0000-0000-0000-000000000009");
    public static readonly Guid CancelledPurchaseOrderLineId = Guid.Parse("90000000-0000-0000-0000-000000000010");
    public static readonly Guid EastlakeApprovedPurchaseOrderId = Guid.Parse("90000000-0000-0000-0000-000000000011");
    public static readonly Guid EastlakeApprovedPurchaseOrderLineId = Guid.Parse("90000000-0000-0000-0000-000000000012");
    public static readonly Guid DraftPurchaseOrderSecondLineId = Guid.Parse("90000000-0000-0000-0000-000000000013");
    public static readonly Guid ApprovedPurchaseOrderSecondLineId = Guid.Parse("90000000-0000-0000-0000-000000000014");

    public static readonly Guid PartialGoodsReceiptId = Guid.Parse("91000000-0000-0000-0000-000000000001");
    public static readonly Guid PartialGoodsReceiptLineId = Guid.Parse("91000000-0000-0000-0000-000000000002");
    public static readonly Guid CompletedGoodsReceiptId = Guid.Parse("91000000-0000-0000-0000-000000000003");
    public static readonly Guid CompletedGoodsReceiptLineId = Guid.Parse("91000000-0000-0000-0000-000000000004");

    public static readonly Guid ReceiptTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000001");
    public static readonly Guid IssueTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000002");
    public static readonly Guid AdjustmentIncreaseTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000003");
    public static readonly Guid AdjustmentDecreaseTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000004");
    public static readonly Guid PedestalReceiptTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000005");
    public static readonly Guid TaskChairIssueTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000006");
    public static readonly Guid ConferenceBaseAdjustmentTransactionId = Guid.Parse("92000000-0000-0000-0000-000000000007");

    public static readonly Guid DeskLegCycleCountAdjustmentId = Guid.Parse("93000000-0000-0000-0000-000000000001");
    public static readonly Guid CabinetDamageAdjustmentId = Guid.Parse("93000000-0000-0000-0000-000000000002");
    public static readonly Guid ConferenceBaseAdjustmentId = Guid.Parse("93000000-0000-0000-0000-000000000003");

    public static readonly Guid PurchaseOrderCreatedAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000001");
    public static readonly Guid GoodsReceiptAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000002");
    public static readonly Guid StockIssueAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000003");
    public static readonly Guid StockAdjustmentAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000004");
    public static readonly Guid EastlakePurchaseOrderAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000005");
    public static readonly Guid PedestalReceiptAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000006");
    public static readonly Guid TaskChairIssueAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000007");
    public static readonly Guid ConferenceBaseAdjustmentAuditLogId = Guid.Parse("94000000-0000-0000-0000-000000000008");

    // ── SaaS tenant (CloudPeak Software) ────────────────────────────────────
    public static readonly Guid SaasAdminUserId     = Guid.Parse("24000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasWarehouseUserId = Guid.Parse("24000000-0000-0000-0000-000000000002");

    public static readonly Guid SaasLicensesCategoryId    = Guid.Parse("34000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasDevHardwareCategoryId = Guid.Parse("34000000-0000-0000-0000-000000000002");
    public static readonly Guid SaasCloudInfraCategoryId  = Guid.Parse("34000000-0000-0000-0000-000000000003");

    public static readonly Guid LicenseHubSupplierId  = Guid.Parse("44000000-0000-0000-0000-000000000001");
    public static readonly Guid DevGearProSupplierId  = Guid.Parse("44000000-0000-0000-0000-000000000002");
    public static readonly Guid CloudStackSupplierId  = Guid.Parse("44000000-0000-0000-0000-000000000003");

    public static readonly Guid SaasWarehouseId = Guid.Parse("54000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasLocationId  = Guid.Parse("64000000-0000-0000-0000-000000000001");

    public static readonly Guid VsLicenseItemId    = Guid.Parse("76000000-0000-0000-0000-000000000001");
    public static readonly Guid JbPackItemId       = Guid.Parse("76000000-0000-0000-0000-000000000002");
    public static readonly Guid MacBookProItemId   = Guid.Parse("76000000-0000-0000-0000-000000000003");
    public static readonly Guid MechKeyboardItemId = Guid.Parse("76000000-0000-0000-0000-000000000004");
    public static readonly Guid AwsInstanceItemId  = Guid.Parse("76000000-0000-0000-0000-000000000005");
    public static readonly Guid NasStorageItemId   = Guid.Parse("76000000-0000-0000-0000-000000000006");

    public static readonly Guid SaasSupplierItemId1 = Guid.Parse("77000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasSupplierItemId2 = Guid.Parse("77000000-0000-0000-0000-000000000002");
    public static readonly Guid SaasSupplierItemId3 = Guid.Parse("77000000-0000-0000-0000-000000000003");
    public static readonly Guid SaasSupplierItemId4 = Guid.Parse("77000000-0000-0000-0000-000000000004");
    public static readonly Guid SaasSupplierItemId5 = Guid.Parse("77000000-0000-0000-0000-000000000005");
    public static readonly Guid SaasSupplierItemId6 = Guid.Parse("77000000-0000-0000-0000-000000000006");

    public static readonly Guid SaasPODraftId      = Guid.Parse("B5000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasPODraftLineId  = Guid.Parse("B5000000-0000-0000-0000-000000000002");
    public static readonly Guid SaasPOApprovedId   = Guid.Parse("B5000000-0000-0000-0000-000000000003");
    public static readonly Guid SaasPOApprovedLineId = Guid.Parse("B5000000-0000-0000-0000-000000000004");
    public static readonly Guid SaasPOCompletedId  = Guid.Parse("B5000000-0000-0000-0000-000000000005");
    public static readonly Guid SaasPOCompletedLineId = Guid.Parse("B5000000-0000-0000-0000-000000000006");

    public static readonly Guid SaasGoodsReceiptId     = Guid.Parse("B6000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasGoodsReceiptLineId = Guid.Parse("B6000000-0000-0000-0000-000000000002");

    public static readonly Guid SaasTxn1Id = Guid.Parse("B7000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasTxn2Id = Guid.Parse("B7000000-0000-0000-0000-000000000002");
    public static readonly Guid SaasTxn3Id = Guid.Parse("B7000000-0000-0000-0000-000000000003");

    public static readonly Guid SaasAdj1Id = Guid.Parse("B8000000-0000-0000-0000-000000000001");

    public static readonly Guid SaasAuditLog1Id = Guid.Parse("B9000000-0000-0000-0000-000000000001");
    public static readonly Guid SaasAuditLog2Id = Guid.Parse("B9000000-0000-0000-0000-000000000002");

    // ── IT Services tenant (NetBridge IT) ────────────────────────────────────
    public static readonly Guid ItAdminUserId     = Guid.Parse("25000000-0000-0000-0000-000000000001");
    public static readonly Guid ItWarehouseUserId = Guid.Parse("25000000-0000-0000-0000-000000000002");

    public static readonly Guid ItNetworkingCategoryId  = Guid.Parse("35000000-0000-0000-0000-000000000001");
    public static readonly Guid ItEndUserDevCategoryId  = Guid.Parse("35000000-0000-0000-0000-000000000002");
    public static readonly Guid ItPeripheralsCategoryId = Guid.Parse("35000000-0000-0000-0000-000000000003");

    public static readonly Guid NetCoreSupplierId   = Guid.Parse("45000000-0000-0000-0000-000000000001");
    public static readonly Guid DeviceMaxSupplierId = Guid.Parse("45000000-0000-0000-0000-000000000002");
    public static readonly Guid AccePartsSupplierId = Guid.Parse("45000000-0000-0000-0000-000000000003");

    public static readonly Guid ItWarehouseId = Guid.Parse("55000000-0000-0000-0000-000000000001");
    public static readonly Guid ItLocationId  = Guid.Parse("65000000-0000-0000-0000-000000000001");

    public static readonly Guid CiscoRouterItemId   = Guid.Parse("78000000-0000-0000-0000-000000000001");
    public static readonly Guid PoeSwitchItemId     = Guid.Parse("78000000-0000-0000-0000-000000000002");
    public static readonly Guid DellDesktopItemId   = Guid.Parse("78000000-0000-0000-0000-000000000003");
    public static readonly Guid LaserJetItemId      = Guid.Parse("78000000-0000-0000-0000-000000000004");
    public static readonly Guid MonitorStandItemId  = Guid.Parse("78000000-0000-0000-0000-000000000005");
    public static readonly Guid PatchCableItemId    = Guid.Parse("78000000-0000-0000-0000-000000000006");

    public static readonly Guid ItSupplierItemId1 = Guid.Parse("79000000-0000-0000-0000-000000000001");
    public static readonly Guid ItSupplierItemId2 = Guid.Parse("79000000-0000-0000-0000-000000000002");
    public static readonly Guid ItSupplierItemId3 = Guid.Parse("79000000-0000-0000-0000-000000000003");
    public static readonly Guid ItSupplierItemId4 = Guid.Parse("79000000-0000-0000-0000-000000000004");
    public static readonly Guid ItSupplierItemId5 = Guid.Parse("79000000-0000-0000-0000-000000000005");
    public static readonly Guid ItSupplierItemId6 = Guid.Parse("79000000-0000-0000-0000-000000000006");

    public static readonly Guid ItPODraftId       = Guid.Parse("C5000000-0000-0000-0000-000000000001");
    public static readonly Guid ItPODraftLineId   = Guid.Parse("C5000000-0000-0000-0000-000000000002");
    public static readonly Guid ItPOApprovedId    = Guid.Parse("C5000000-0000-0000-0000-000000000003");
    public static readonly Guid ItPOApprovedLineId = Guid.Parse("C5000000-0000-0000-0000-000000000004");
    public static readonly Guid ItPOCompletedId   = Guid.Parse("C5000000-0000-0000-0000-000000000005");
    public static readonly Guid ItPOCompletedLineId = Guid.Parse("C5000000-0000-0000-0000-000000000006");

    public static readonly Guid ItGoodsReceiptId     = Guid.Parse("C6000000-0000-0000-0000-000000000001");
    public static readonly Guid ItGoodsReceiptLineId = Guid.Parse("C6000000-0000-0000-0000-000000000002");

    public static readonly Guid ItTxn1Id = Guid.Parse("C7000000-0000-0000-0000-000000000001");
    public static readonly Guid ItTxn2Id = Guid.Parse("C7000000-0000-0000-0000-000000000002");
    public static readonly Guid ItTxn3Id = Guid.Parse("C7000000-0000-0000-0000-000000000003");

    public static readonly Guid ItAdj1Id = Guid.Parse("C8000000-0000-0000-0000-000000000001");

    public static readonly Guid ItAuditLog1Id = Guid.Parse("C9000000-0000-0000-0000-000000000001");
    public static readonly Guid ItAuditLog2Id = Guid.Parse("C9000000-0000-0000-0000-000000000002");

    // ── Cybersecurity tenant (ShieldCore Security) ───────────────────────────
    public static readonly Guid CyberAdminUserId     = Guid.Parse("26000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberWarehouseUserId = Guid.Parse("26000000-0000-0000-0000-000000000002");

    public static readonly Guid CyberAppliancesCategoryId   = Guid.Parse("36000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberIdentityCategoryId     = Guid.Parse("36000000-0000-0000-0000-000000000002");
    public static readonly Guid CyberThreatIntelCategoryId  = Guid.Parse("36000000-0000-0000-0000-000000000003");

    public static readonly Guid FortiTechSupplierId   = Guid.Parse("46000000-0000-0000-0000-000000000001");
    public static readonly Guid ZeroTrustSupplierId   = Guid.Parse("46000000-0000-0000-0000-000000000002");
    public static readonly Guid SecureKeySupplierId   = Guid.Parse("46000000-0000-0000-0000-000000000003");

    public static readonly Guid CyberWarehouseId = Guid.Parse("56000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberLocationId  = Guid.Parse("66000000-0000-0000-0000-000000000001");

    public static readonly Guid NgFirewallItemId    = Guid.Parse("7A000000-0000-0000-0000-000000000001");
    public static readonly Guid HwSecKeyItemId      = Guid.Parse("7A000000-0000-0000-0000-000000000002");
    public static readonly Guid SiemApplianceItemId = Guid.Parse("7A000000-0000-0000-0000-000000000003");
    public static readonly Guid VpnConcentratorItemId = Guid.Parse("7A000000-0000-0000-0000-000000000004");
    public static readonly Guid ThreatIntelLicItemId = Guid.Parse("7A000000-0000-0000-0000-000000000005");
    public static readonly Guid SmartCardReaderItemId = Guid.Parse("7A000000-0000-0000-0000-000000000006");

    public static readonly Guid CyberSupplierItemId1 = Guid.Parse("7B000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberSupplierItemId2 = Guid.Parse("7B000000-0000-0000-0000-000000000002");
    public static readonly Guid CyberSupplierItemId3 = Guid.Parse("7B000000-0000-0000-0000-000000000003");
    public static readonly Guid CyberSupplierItemId4 = Guid.Parse("7B000000-0000-0000-0000-000000000004");
    public static readonly Guid CyberSupplierItemId5 = Guid.Parse("7B000000-0000-0000-0000-000000000005");
    public static readonly Guid CyberSupplierItemId6 = Guid.Parse("7B000000-0000-0000-0000-000000000006");

    public static readonly Guid CyberPODraftId        = Guid.Parse("D5000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberPODraftLineId    = Guid.Parse("D5000000-0000-0000-0000-000000000002");
    public static readonly Guid CyberPOApprovedId     = Guid.Parse("D5000000-0000-0000-0000-000000000003");
    public static readonly Guid CyberPOApprovedLineId = Guid.Parse("D5000000-0000-0000-0000-000000000004");
    public static readonly Guid CyberPOCompletedId    = Guid.Parse("D5000000-0000-0000-0000-000000000005");
    public static readonly Guid CyberPOCompletedLineId = Guid.Parse("D5000000-0000-0000-0000-000000000006");

    public static readonly Guid CyberGoodsReceiptId     = Guid.Parse("D6000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberGoodsReceiptLineId = Guid.Parse("D6000000-0000-0000-0000-000000000002");

    public static readonly Guid CyberTxn1Id = Guid.Parse("D7000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberTxn2Id = Guid.Parse("D7000000-0000-0000-0000-000000000002");
    public static readonly Guid CyberTxn3Id = Guid.Parse("D7000000-0000-0000-0000-000000000003");

    public static readonly Guid CyberAdj1Id = Guid.Parse("D8000000-0000-0000-0000-000000000001");

    public static readonly Guid CyberAuditLog1Id = Guid.Parse("D9000000-0000-0000-0000-000000000001");
    public static readonly Guid CyberAuditLog2Id = Guid.Parse("D9000000-0000-0000-0000-000000000002");
}
