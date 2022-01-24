using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class ProductDailySales
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<System.DateTime> ReportDate { get; set; }
        public Nullable<int> DayNo { get; set; }
        public Nullable<decimal> ColumnValue { get; set; }
    }
}