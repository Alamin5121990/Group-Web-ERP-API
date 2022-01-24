using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class AccountsExpenseData
    {
        public string AccountsExpenseDetailData { get; set; }

        public int ExpenseID { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}