using System;

namespace LabaidMIS.Data.Classes.Sales.Depo
{
    public class DepoSalesProductAllDepoLastWeek
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
    }

    public class DepoSalesProductAllDepoLastWeekReport
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
    }
}