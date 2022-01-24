using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DepotDeposit
    {
        public Nullable<decimal> CashDeposit { get; set; }
        public Nullable<decimal> InstrumentDeposit { get; set; }
        public Nullable<DateTime> DepositDate { get; set; }
        public string Location { get; set; }
    }
}