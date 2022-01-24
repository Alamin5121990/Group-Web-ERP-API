using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialWorksheetProduct
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string ProductPriorityCode { get; set; }
        public Nullable<decimal> BatchSize { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
        public Nullable<decimal> OutputQuantity { get; set; }

        public Nullable<decimal> ProductTotalStock { get; set; }

        public Nullable<decimal> TotalBatchInProgress { get; set; }
        public Nullable<decimal> TotalBatchInRelease { get; set; }

        public Nullable<int> Month1Quantity { get; set; }
        public Nullable<int> Month2Quantity { get; set; }
        public Nullable<int> Month3Quantity { get; set; }
        public Nullable<decimal> AVGQuantity { get; set; }

        public Nullable<decimal> ForecastMonth1 { get; set; }
        public Nullable<decimal> ForecastMonth2 { get; set; }
        public Nullable<decimal> ForecastMonth3 { get; set; }
    }
}