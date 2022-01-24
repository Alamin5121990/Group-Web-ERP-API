using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class AccountsExpenseDetailEntry
    {
        public int ExpenseDetailID { get; set; }
        public int ExpenseID { get; set; }
        public int ExpenseHeadID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}