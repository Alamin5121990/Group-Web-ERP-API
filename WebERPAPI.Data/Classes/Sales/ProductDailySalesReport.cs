using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class ProductDailySalesReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public Nullable<decimal> Day1 { get; set; }
        public Nullable<decimal> OldDay1 { get; set; }
        public Nullable<decimal> PrvOldDay1 { get; set; }

        public Nullable<decimal> Day2 { get; set; }
        public Nullable<decimal> OldDay2 { get; set; }
        public Nullable<decimal> PrvOldDay2 { get; set; }

        public Nullable<decimal> Day3 { get; set; }
        public Nullable<decimal> OldDay3 { get; set; }
        public Nullable<decimal> PrvOldDay3 { get; set; }
    }
}