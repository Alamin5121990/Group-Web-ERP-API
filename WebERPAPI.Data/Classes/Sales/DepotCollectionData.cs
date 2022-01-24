using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DepotCollectionData
    {
        public Nullable<decimal> CashCollection { get; set; }
        public Nullable<decimal> InstrumentCollection { get; set; }
        public Nullable<decimal> CashDeposit { get; set; }
        public Nullable<decimal> InstrumentDeposit { get; set; }
        public Nullable<DateTime> TransactionDate { get; set; }
        public string Location { get; set; }
    }
}