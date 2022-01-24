using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class AllDepotExpenseAndCollection : AllDepotExpenseSummary
    {
        public Nullable<decimal> CashCollection { get; set; }
        public Nullable<decimal> InstrumentCollection { get; set; }
        public Nullable<decimal> CashDeposit { get; set; }
        public Nullable<decimal> InstrumentDeposit { get; set; }

        public Nullable<decimal> AvailableCash { get; set; }
        public Nullable<decimal> Disbursement { get; set; }
    }
}