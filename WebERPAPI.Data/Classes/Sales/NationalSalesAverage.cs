using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class NationalSalesAverage
    {
        public Nullable<decimal> LastMonthSalesAverage { get; set; }
        public Nullable<decimal> LastMonthSalesUpto { get; set; }
        public Nullable<decimal> LastMonthSalesExpected { get; set; }
        public Nullable<decimal> CurrentMonthSalesAverage { get; set; }
        public Nullable<decimal> CurrentMonthSalesUpto { get; set; }
        public Nullable<decimal> CurrentMonthSalesExpected { get; set; }
    }
}