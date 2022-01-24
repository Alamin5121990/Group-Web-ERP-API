using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
{
    public class ProductionPlanningReport
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string PID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<int> ProductionLocationID { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<int> TotalMaterialShortage { get; set; }
        public Nullable<int> MaterialShortagePercent { get; set; }

        public Nullable<decimal> TotalBatchInProgress { get; set; }
        public Nullable<decimal> TotalBatchOutputInProgress { get; set; }

        public Nullable<decimal> TotalBatchInRelease { get; set; }
        public Nullable<decimal> TotalBatchOutputInRelease { get; set; }

        public Nullable<decimal> TotalFreeStock { get; set; }
        public Nullable<decimal> TotalInProgress { get; set; }

        public Nullable<decimal> SalesUptoQty { get; set; }
        public Nullable<decimal> LastMonthSalesQty { get; set; }
        public Nullable<decimal> TwoMonthsAgoSalesQty { get; set; }

        public Nullable<decimal> ForecastMonth1SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth1CommercialQty { get; set; }
        public Nullable<int> BatchMonth1Quantity { get; set; }

        public Nullable<decimal> ForecastMonth2SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth2CommercialQty { get; set; }
        public Nullable<int> BatchMonth2Quantity { get; set; }

        public Nullable<decimal> ForecastMonth3SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth3CommercialQty { get; set; }
        public Nullable<int> BatchMonth3Quantity { get; set; }

        public Nullable<decimal> ForecastMonth4SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth4CommercialQty { get; set; }
        public Nullable<int> BatchMonth4Quantity { get; set; }

        public Nullable<decimal> ForecastMonth5SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth5CommercialQty { get; set; }
        public Nullable<int> BatchMonth5Quantity { get; set; }

        public Nullable<decimal> ForecastMonth6SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth6CommercialQty { get; set; }
        public Nullable<int> BatchMonth6Quantity { get; set; }

        public Nullable<decimal> BatchUnitQuantity { get; set; }

        public Nullable<decimal> DayCoverSale { get; set; }
        public Nullable<decimal> DayCoverForecast { get; set; }

        public Nullable<decimal> NoOfBatchRequired { get; set; }
        public Nullable<int> BatchCreationQuantity { get; set; }
        public Nullable<decimal> NoOfBatchRequiredOutput { get; set; }

        public Nullable<decimal> TotalQuantityDayCoverSale { get; set; }
        public Nullable<decimal> TotalQuantityDayCoverForecast { get; set; }

        public Nullable<decimal> ForecastTotalSampleQty { get; set; }
        public Nullable<decimal> ForecastTotalQty { get; set; }

        public Nullable<decimal> TotalBatchOutputQty { get; set; }

        public Boolean IsOpen { get; set; }
        public Boolean IsBatchScheduleCreated { get; set; }
    }

    public class ProductionPlanningProduct
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> TotalClosing { get; set; }
    }

    public class MasterProductionScheduleData
    {
        public int UserID { get; set; }
        public int YearNo { get; set; }
        public int MonthNo { get; set; }
        public string Data { get; set; }
    }

    public class MasterProductionSchedule
    {
        public int ProductID { get; set; }

        public Nullable<decimal> TotalBatchInProgress { get; set; }
        public Nullable<decimal> TotalBatchOutputInProgress { get; set; }

        public Nullable<decimal> TotalFreeStock { get; set; }
        public Nullable<decimal> TotalInProgress { get; set; }

        public Nullable<decimal> SalesUptoQty { get; set; }
        public Nullable<decimal> LastMonthSalesQty { get; set; }
        public Nullable<decimal> TwoMonthsAgoSalesQty { get; set; }

        public Nullable<decimal> ForecastCurrentMonthSampleQty { get; set; }
        public Nullable<decimal> ForecastCurrentMonthCommercialQty { get; set; }

        public Nullable<decimal> ForecastMonth1SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth1CommercialQty { get; set; }

        public Nullable<decimal> ForecastMonth2SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth2CommercialQty { get; set; }

        public Nullable<decimal> ForecastMonth3SampleQty { get; set; }
        public Nullable<decimal> ForecastMonth3CommercialQty { get; set; }

        public Nullable<decimal> BatchUnitQuantity { get; set; }

        public Nullable<decimal> DayCoverSale { get; set; }
        public Nullable<decimal> DayCoverForecast { get; set; }

        public Nullable<decimal> NoOfBatchRequired { get; set; }
        public Nullable<decimal> NoOfBatchRequiredOutput { get; set; }

        public Nullable<decimal> TotalQuantityDayCoverSale { get; set; }
        public Nullable<decimal> TotalQuantityDayCoverForecast { get; set; }
    }

    public class PMSMaterialReport
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> TotalBatchQuantity { get; set; }
        public Nullable<decimal> FreeStockQuantity { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> RequiredQuantity { get; set; }
        public string UOM { get; set; }
        public Boolean IsOpen { get; set; }
    }

    public class PMSMaterialAvailableReport
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> TotalBatchRequiredQuantity { get; set; }
        public Nullable<decimal> FreeStockQuantity { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> ActualFreeStockQuantity { get; set; }
        public Nullable<decimal> TotalAvailableQuantity { get; set; }
    }

    public class MPSDetails
    {
        public int MPSID { get; set; }
        public string MPSCode { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        public int TotalBatchRequired { get; set; }
        public int BatchInProgress { get; set; }
        public Nullable<decimal> ShortagePercent { get; set; }
        public string EmployeeName { get; set; }
    }

    public class ProductScheduleData
    {
        public string Data { get; set; }
        public int ProductID { get; set; }
        public string CreatedByID { get; set; }
    }

    public class ProductScheduleBatchDetails
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<DateTime> ScheduleStartDate { get; set; }
        public Nullable<int> ScheduleYear { get; set; }
        public Nullable<int> ScheduleMonth { get; set; }
        public Nullable<int> ScheduleQuantity { get; set; }
    }

    public class PPICProductBatchScheduleReport
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductPriorityCode { get; set; }

        public List<ProductScheduleBatchDetails> Month1 { get; set; }
        public List<ProductScheduleBatchDetails> Month2 { get; set; }
        public List<ProductScheduleBatchDetails> Month3 { get; set; }
        public List<ProductScheduleBatchDetails> Month4 { get; set; }
        public List<ProductScheduleBatchDetails> Month5 { get; set; }
        public List<ProductScheduleBatchDetails> Month6 { get; set; }
    }

    public class PPICProductBatchCreationSummary
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
    }

    public class PPICProductBatchMonthlyScheduleQuantity
    {
        public Nullable<DateTime> Month { get; set; }
        public Nullable<int> Quantity { get; set; }
    }

    public class PPICProductBatchMonthlyScheduleQuantityReport
    {
        public Nullable<int> Month1 { get; set; }
        public Nullable<int> Month2 { get; set; }
        public Nullable<int> Month3 { get; set; }
        public Nullable<int> Month4 { get; set; }
        public Nullable<int> Month5 { get; set; }
        public Nullable<int> Month6 { get; set; }
        public Nullable<int> Month7 { get; set; }
    }

    public class MaterialShortageReportData
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> CurrentFreeStock { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }

        public Nullable<decimal> Month1Stock { get; set; }
        public Nullable<decimal> Month2Stock { get; set; }
        public Nullable<decimal> Month3Stock { get; set; }
        public Nullable<decimal> Month4Stock { get; set; }
        public Nullable<decimal> Month5Stock { get; set; }
        public Nullable<decimal> Month6Stock { get; set; }
    }

    public class PPICMaterialShortageReport
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }

        public string MaterialType { get; set; }
        public string MaterialCategory { get; set; }
        public string ProductPriorityCode { get; set; }
        public string PurchaseStatus { get; set; }

        public Nullable<decimal> MOQ { get; set; }
        public string SourceType { get; set; }
        public Nullable<int> LeadTime { get; set; }

        public Nullable<decimal> CurrentFreeStock { get; set; }
        public Nullable<decimal> FreeStock { get; set; }
        public Nullable<decimal> ProductionFloorStock { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }

        public Nullable<decimal> RetestQuantity { get; set; }

        public Nullable<DateTime> RequisitionDate { get; set; }

        public Nullable<decimal> Month1Stock { get; set; }
        public Nullable<decimal> Month2Stock { get; set; }
        public Nullable<decimal> Month3Stock { get; set; }
        public Nullable<decimal> Month4Stock { get; set; }
        public Nullable<decimal> Month5Stock { get; set; }
        public Nullable<decimal> Month6Stock { get; set; }

        public Boolean IsIntermediateMaterial { get; set; }
    }

    public class MaterialProductMonthlyBatch
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> TotalBatchQuantity { get; set; }
    }

    public class PPICMaterialProductMonthlyDetails
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductPriorityCode { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }

        public Nullable<decimal> Month1BatchQuantity { get; set; }
        public Nullable<decimal> Month2BatchQuantity { get; set; }
        public Nullable<decimal> Month3BatchQuantity { get; set; }
        public Nullable<decimal> Month4BatchQuantity { get; set; }
        public Nullable<decimal> Month5BatchQuantity { get; set; }
        public Nullable<decimal> Month6BatchQuantity { get; set; }
    }

    public class ProductBatchTotalQuantity
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> ScheduleQuantity { get; set; }
    }

    public class MaterialMonthlyShortage
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string ProductTypeName { get; set; }
        public string CategoryName { get; set; }
        public string SourceType { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public Nullable<decimal> RUOMConvFac { get; set; }

        public string UOM { get; set; }

        public string RequisitionUOM { get; set; }
        public string VersionNo { get; set; }

        public Nullable<int> LeadTime { get; set; }

        public Nullable<decimal> CurrentFreeStock { get; set; }
        public Nullable<decimal> FreeStock { get; set; }
        public Nullable<decimal> ProductionFloorStock { get; set; }

        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> PORequisitionQuantity { get; set; }
        public Nullable<decimal> PODoneQuantity { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }

        public Nullable<decimal> PORemainingQuantity { get; set; }

        public Nullable<decimal> RetestQuantity { get; set; }

        public Nullable<DateTime> RequisitionDate { get; set; }

        public Nullable<decimal> ActualStockQuantity { get; set; }

        public Nullable<int> TotalBatchQuantity { get; set; }
        public Nullable<decimal> TotalBatchRequiredQuantity { get; set; }
        public Nullable<decimal> AvailableQuantity { get; set; }
        public Nullable<decimal> NewRequisitionQuantity { get; set; }

        public Nullable<Boolean> IsIntermediateMaterial { get; set; }

        public Nullable<int> SupplierTotal { get; set; }
    }

    public class InventoryPPICProductionSchedule
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> MPSID { get; set; }
        public string ScheduleCode { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> ScheduleNo { get; set; }
        public Nullable<DateTime> ScheduleStartDate { get; set; }
        public Nullable<DateTime> ScheduleEndDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }

    public class InventoryPPICProductionScheduleDetails
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string PackSize { get; set; }
        public Nullable<int> ProductionLocationID { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<decimal> TP { get; set; }

        public Nullable<decimal> TotalBatchInProgress { get; set; }
        public Nullable<decimal> TotalBatchOutputInProgress { get; set; }

        public Nullable<decimal> TotalBatchInRelease { get; set; }
        public Nullable<decimal> TotalBatchOutputInRelease { get; set; }

        public Nullable<decimal> BatchUnitQuantity { get; set; }
        public string SPS { get; set; }

        public Nullable<int> RequiredBatch { get; set; }
        public Nullable<int> TotalBatchQualify { get; set; }
        public Nullable<int> TotalBatch { get; set; }
        public Nullable<int> BatchPriority { get; set; }
        public Nullable<int> TotalBatchCreated { get; set; }

        public string UpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string Remarks { get; set; }
    }

    public class MaterialQualify
    {
        public string MaterialCode { get; set; }
        public int TotalQualify { get; set; }
    }

    public class ProductionScheduleData
    {
        public int ScheduleID { get; set; }
        public string Data { get; set; }
        public string CreatedBy { get; set; }
    }

    public class ProductionScheduleDetails
    {
        public int ProductID { get; set; }
        public int TotalBatch { get; set; }
        public Nullable<int> BatchPriority { get; set; }
        public string Remarks { get; set; }
    }
}