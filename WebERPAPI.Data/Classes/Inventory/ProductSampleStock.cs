using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ProductSampleStock
    {
        public Nullable<int> ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }
        public Nullable<decimal> TP { get; set; }
        public string ProductType { get; set; }
        public Nullable<decimal> ClosingQty { get; set; }
    }

    public class ProductSampleStockReport
    {
        public string BrandName { get; set; }

        public Nullable<int> ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }
        public Nullable<decimal> TP { get; set; }
        public string ProductType { get; set; }
        public Nullable<decimal> ClosingQty { get; set; }

        public Nullable<decimal> ForecastMonth1 { get; set; }
        public Nullable<decimal> AllocationQuantity1 { get; set; }
        public Nullable<decimal> DisptachedQuantity1 { get; set; }

        public Nullable<decimal> ForecastMonth2 { get; set; }
        public Nullable<decimal> AllocationQuantity2 { get; set; }
        public Nullable<decimal> DisptachedQuantity2 { get; set; }

        public Nullable<decimal> ForecastMonth3 { get; set; }
        public Nullable<decimal> AllocationQuantity3 { get; set; }

        public Nullable<decimal> ForecastMonth4 { get; set; }
        public Nullable<decimal> AllocationQuantity4 { get; set; }

        public Nullable<decimal> ForecastMonth5 { get; set; }
        public Nullable<decimal> AllocationQuantity5 { get; set; }

        public Nullable<decimal> ForecastMonth6 { get; set; }
        public Nullable<decimal> AllocationQuantity6 { get; set; }

        public decimal RequiredQuantity3 { get; set; }
        public decimal RequiredQuantity4 { get; set; }
        public decimal RequiredQuantity5 { get; set; }
        public decimal RequiredQuantity6 { get; set; }
    }
}