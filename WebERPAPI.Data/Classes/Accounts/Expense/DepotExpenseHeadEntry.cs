using LabaidMIS.Data.Models.PROCESSERVER;
using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class DepotExpenseHeadEntry
    {
        public int ExpenseHeadID { get; set; }
        public string HeadName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> AccountsExpenseHeadID { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }

        public bool assignDataFromDepotHead(DepotExpenseHead deh)
        {
            try
            {
                this.ExpenseHeadID = deh.ExpenseHeadID;
                this.HeadName = deh.HeadName;
                this.IsActive = deh.IsActive;
                this.AccountsExpenseHeadID = deh.AccountsExpenseHeadID;
                this.AddedBy = deh.AddedBy;
                this.DateAdded = deh.DateAdded;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}