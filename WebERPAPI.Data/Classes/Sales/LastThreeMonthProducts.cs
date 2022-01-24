using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class ProductSalesLastThreeMonths
    {
        public int ProductId { get; set; }
        public int Month { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}