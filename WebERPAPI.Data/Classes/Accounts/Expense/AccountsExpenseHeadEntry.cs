using LabaidMIS.Data.Models.PROCESSERVER;
using System;

namespace LabaidMIS.Data.Classes.Accounts.Expense
{
    public class AccountsExpenseHeadEntry
    {
        public int ExpenseHeadID { get; set; }
        public string HeadName { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }

        public bool assignDataFromAccountsHead(AccountsExpenseHead aeh)
        {
            try
            {
                this.ExpenseHeadID = aeh.ExpenseHeadID;
                this.HeadName = aeh.HeadName;
                this.GroupID = aeh.GroupID;
                this.IsActive = aeh.IsActive;
                this.AddedBy = aeh.AddedBy;
                this.DateAdded = aeh.DateAdded;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}