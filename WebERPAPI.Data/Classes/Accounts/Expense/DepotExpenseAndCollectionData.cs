using System;

namespace LabaidMIS.Data.Classes.Accounts.Expense
{
    public class DepotExpenseAndCollectionData
    {
        public Nullable<decimal> Opening { get; set; }

        public Nullable<decimal> CashCollection { get; set; }
        public Nullable<decimal> InstrumentCollection { get; set; }
        public Nullable<decimal> CashDeposit { get; set; }
        public Nullable<decimal> InstrumentDeposit { get; set; }
        public Nullable<decimal> ExpenseReturn { get; set; }

        public Nullable<decimal> CashToHeadOffice { get; set; }
        public Nullable<decimal> TotalExpense { get; set; }
        public Nullable<decimal> Closing { get; set; }
    }
}