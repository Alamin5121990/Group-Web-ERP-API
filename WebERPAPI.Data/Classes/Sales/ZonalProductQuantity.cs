using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class ZonalProductQuantity
    {
        public int ProductID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
    }

    public class ZonalProductQuantityUpto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int ProductID { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
    }

    public class ZonalProductQuantityReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
    }
}