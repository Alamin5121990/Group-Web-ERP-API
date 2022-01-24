using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class SalesGrowth
    {
        public int YearNo { get; set; }
        public int MonthNo { get; set; }
        public Nullable<decimal> GrowthAveragePercent { get; set; }
        public Nullable<decimal> GrowthAverageValue { get; set; }
        public Nullable<decimal> TargetMonthEndSalesTotal { get; set; }
    }
}