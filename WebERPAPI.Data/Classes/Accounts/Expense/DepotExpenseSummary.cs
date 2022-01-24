using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class DepotExpenseSummary
    {
        public string DepoID { get; set; }

        public Nullable<DateTime> ExpenseDate { get; set; }
        public Nullable<decimal> CashInHand { get; set; }
        public Nullable<decimal> ExpenseReturn { get; set; }
        public string ExpenseReturnCause { get; set; }
        public Nullable<decimal> CashToHeadOffice { get; set; }
        public string CashToHeadCause { get; set; }
        public string HeadName { get; set; }

        public Nullable<int> ExpenseHeadID { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}