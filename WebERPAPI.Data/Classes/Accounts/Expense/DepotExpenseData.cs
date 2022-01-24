using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class DepotExpenseData
    {
        public string ExpenseDetailsData { get; set; }
        public int ExpenseID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public Nullable<decimal> CashInHand { get; set; }
        public Nullable<decimal> ExpenseReturn { get; set; }
        public string ExpenseReturnCause { get; set; }
        public Nullable<decimal> CashToHeadOffice { get; set; }
        public string CashToHeadCause { get; set; }
        public string ClosingBalanceCause { get; set; }
        public Boolean IsLocked { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public string DepoID { get; set; }
        public string AddedBy { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
    }
}