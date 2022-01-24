using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialBatchStockVerification
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string ProductType { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductCategory { get; set; }
        public string CategoryName { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> MOQ { get; set; }
        public string SourceType { get; set; }
        public Nullable<int> LeadTime { get; set; }

        public Nullable<decimal> FreeStock { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }

        public Nullable<decimal> OneBatchRequiredQuantity { get; set; }
        public Nullable<int> TotalRunningBatch { get; set; }

        public int TotalQualify { get; set; }
    }
}