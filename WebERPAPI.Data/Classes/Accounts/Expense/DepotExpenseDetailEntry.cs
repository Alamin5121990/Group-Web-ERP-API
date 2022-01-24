using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class DepotExpenseDetailEntry
    {
        public int ExpenseID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public Nullable<decimal> CashInHand { get; set; }
        public Nullable<decimal> ExpenseReturn { get; set; }
        public string ExpenseReturnCause { get; set; }
        public Nullable<decimal> CashToHeadOffice { get; set; }
        public string CashToHeadCause { get; set; }
        public string ClosingBalanceCause { get; set; }
        public string DepoID { get; set; }
        public Nullable<Boolean> IsLocked { get; set; }
        public int ExpenseDetailID { get; set; }
        public int ExpenseHeadID { get; set; }
        public string HeadName { get; set; }
        public string Purpose { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public string Addedby { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Updatedby { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}