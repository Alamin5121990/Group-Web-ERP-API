using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class AccountsExpenseMasterEntry
    {
        public int ExpenseID { get; set; }
        public System.DateTime ExpenseDate { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> ExpenseHeadID { get; set; }
        public Nullable<int> ExpenseDetailID { get; set; }
        public string HeadName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> DepoAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }
}