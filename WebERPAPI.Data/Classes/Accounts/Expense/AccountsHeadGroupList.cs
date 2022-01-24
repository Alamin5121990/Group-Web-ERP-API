using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Accounts.Expense
{
    public class AccountsHeadGroupList
    {
        public AccountsHeadGroup HeadGroup { get; set; }
        public List<AccountsExpenseHeadEntry> AccountsHead { get; set; }
    }
}