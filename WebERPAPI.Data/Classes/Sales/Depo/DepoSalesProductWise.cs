using System;

namespace LabaidMIS.Data.Classes.Sales.Depo
{
    public class DepoSalesProductWise
    {
        public string ProductName { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductCode { get; set; }
        public string PackSize { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Last3MonthsAVGSalesQuantity { get; set; }
        public Nullable<int> LastMonthSalesQuantity { get; set; }

        public Nullable<int> SalesQuantityUpto { get; set; }
        public Nullable<decimal> SalesValueUpto { get; set; }
    }

    public class DepoSalesProductReport
    {
        public string ProductName { get; set; }
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public string ProductCode { get; set; }
        public string PackSize { get; set; }
        public string ProductPriorityCode { get; set; }
        public Nullable<int> ProductID { get; set; }

        public Nullable<int> TotalBatchOutputInProgress { get; set; }
        public Nullable<int> TotalBatchOutputInRelease { get; set; }

        public Nullable<int> Last3MonthsAVGSalesQuantity { get; set; }
        public Nullable<int> LastMonthSalesQuantity { get; set; }

        public Nullable<int> SalesQuantityUpto { get; set; }
        public Nullable<decimal> SalesValueUpto { get; set; }

        public Nullable<decimal> CWHStock { get; set; }
        public Nullable<decimal> TransitStock { get; set; }
        public Nullable<decimal> AllDepoStock { get; set; }
        public Nullable<decimal> TotalStock { get; set; }

        public int DayCoverSales { get; set; }
    }
}