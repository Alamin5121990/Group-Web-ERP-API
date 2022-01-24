using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class AllDepotExpenseSummary
    {
        public string DepoID { get; set; }

        public Nullable<decimal> Opening { get; set; }
        public Nullable<DateTime> OpeningDate { get; set; }
        public Nullable<decimal> Closing { get; set; }
        public Nullable<DateTime> ClosingDate { get; set; }
        public Nullable<decimal> ExpenseReturn { get; set; }

        public Nullable<decimal> CashToHeadOffice { get; set; }
        public Nullable<decimal> ExpenseAmount { get; set; }
    }
}