using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class TopSellingProducts
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<int> LastMonthQuantity { get; set; }
        public Nullable<decimal> LastMonthSales { get; set; }
    }
}