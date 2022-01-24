using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class SalesDueLocationWise
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string EmployeeName { get; set; }

        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<decimal> CreditDaysDue { get; set; }
        public Nullable<decimal> TotalOverDue { get; set; }
        public Nullable<decimal> TotalCashDue { get; set; }
        public Nullable<decimal> TotalCreditDue { get; set; }
        public Nullable<decimal> TotalCreditOverDue { get; set; }
    }
}