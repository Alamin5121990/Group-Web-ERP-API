using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DepotCollection
    {
        public Nullable<decimal> CashCollection { get; set; }
        public Nullable<decimal> InstrumentCollection { get; set; }
        public Nullable<DateTime> ReceivedDate { get; set; }
        public string Location { get; set; }
    }
}