using LabaidMIS.Data.Classes.Accounts.Expense;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class AccountsDepotHeads
    {
        public AccountsExpenseHeadEntry AccountsHead { get; set; }
        public List<DepotExpenseHeadEntry> DepoteHeads { get; set; }
    }
}