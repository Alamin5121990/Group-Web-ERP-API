using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DailySalesStatus
    {
        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}