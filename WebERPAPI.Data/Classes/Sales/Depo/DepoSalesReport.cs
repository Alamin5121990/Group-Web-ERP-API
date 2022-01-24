using System;

namespace LabaidMIS.Data.Classes.Sales.Depo
{
    public class DepoSalesReport
    {
        public Nullable<int> ID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> CurrentMonthUpto { get; set; }
        public Nullable<decimal> LastMonthUpto { get; set; }
        public Nullable<decimal> LastYearCurrentMonthUpto { get; set; }
        public Nullable<decimal> LastMonthTotal { get; set; }
        public Nullable<decimal> LastYearLastMonthTotal { get; set; }
        public Nullable<decimal> LastYearCurrentMonthTotal { get; set; }
    }
}