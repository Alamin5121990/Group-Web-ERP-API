using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ProductMonthlyShortageReport
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string PID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<int> ProductionLocationID { get; set; }

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

        public Nullable<int> BatchCreationQuantity { get; set; }

        public Nullable<int> Month1BatchQuantity { get; set; }
        public Nullable<int> Month1MaterialShort { get; set; }

        public Nullable<int> Month2BatchQuantity { get; set; }
        public Nullable<int> Month2MaterialShort { get; set; }

        public Nullable<int> Month3BatchQuantity { get; set; }
        public Nullable<int> Month3MaterialShort { get; set; }

        public Nullable<int> Month4BatchQuantity { get; set; }
        public Nullable<int> Month4MaterialShort { get; set; }

        public Nullable<int> Month5BatchQuantity { get; set; }
        public Nullable<int> Month5MaterialShort { get; set; }

        public Nullable<int> Month6BatchQuantity { get; set; }
        public Nullable<int> Month6MaterialShort { get; set; }

        public Boolean IsOpen { get; set; }
    }

    public class ProductMaterialShortageDetails
    {
        public string ProductCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
        public string UOM { get; set; }
        public string SourceType { get; set; }
        public Nullable<decimal> MOQ { get; set; }

        public Nullable<int> LeadTime { get; set; }
        public string LeadTimeDetails { get; set; }

        public Nullable<decimal> FreeStock { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }

        public Nullable<int> Month1BatchQuantity { get; set; }
        public Nullable<decimal> Month1BatchRequiredQuantity { get; set; }
        public Nullable<decimal> Month1AvailableQuantity { get; set; }

        public Nullable<int> Month2BatchQuantity { get; set; }
        public Nullable<decimal> Month2BatchRequiredQuantity { get; set; }
        public Nullable<decimal> Month2AvailableQuantity { get; set; }

        public Nullable<int> Month3BatchQuantity { get; set; }
        public Nullable<decimal> Month3BatchRequiredQuantity { get; set; }
        public Nullable<decimal> Month3AvailableQuantity { get; set; }

        public Nullable<int> Month4BatchQuantity { get; set; }
        public Nullable<decimal> Month4BatchRequiredQuantity { get; set; }
        public Nullable<decimal> Month4AvailableQuantity { get; set; }

        public Nullable<int> Month5BatchQuantity { get; set; }
        public Nullable<decimal> Month5BatchRequiredQuantity { get; set; }
        public Nullable<decimal> Month5AvailableQuantity { get; set; }

        public Nullable<int> Month6BatchQuantity { get; set; }
        public Nullable<decimal> Month6BatchRequiredQuantity { get; set; }
        public Nullable<decimal> Month6AvailableQuantity { get; set; }
    }
}