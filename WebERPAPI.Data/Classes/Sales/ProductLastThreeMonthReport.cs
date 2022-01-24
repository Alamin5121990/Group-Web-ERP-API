using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class ProductLastThreeMonthReport
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Month { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}