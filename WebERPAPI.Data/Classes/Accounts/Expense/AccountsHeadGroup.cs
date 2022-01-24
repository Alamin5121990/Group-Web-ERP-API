using LabaidMIS.Data.Models.PROCESSERVER;
using System;

namespace LabaidMIS.Data.Classes.Accounts.Expense
{
    public class AccountsHeadGroup
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }

        public void assignDataFromDepotHead(AccountsExpenseHeadGroup data)
        {
            this.GroupID = data.GroupID;
            this.GroupName = data.GroupName;
            this.IsActive = data.IsActive;
            this.AddedBy = data.AddedBy;
            this.DateAdded = data.DateAdded;
        }
    }
}