using System;

namespace LabaidMIS.Data.Classes.Sales.Search
{
    public class SalesReportNationalData
    {
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }

    public class SalesReportNational
    {
        public Nullable<int> YearNo { get; set; }
        public Nullable<decimal> Month1 { get; set; }
        public Nullable<decimal> Month2 { get; set; }
        public Nullable<decimal> Month3 { get; set; }
        public Nullable<decimal> Month4 { get; set; }
        public Nullable<decimal> Month5 { get; set; }
        public Nullable<decimal> Month6 { get; set; }
        public Nullable<decimal> Month7 { get; set; }
        public Nullable<decimal> Month8 { get; set; }
        public Nullable<decimal> Month9 { get; set; }
        public Nullable<decimal> Month10 { get; set; }
        public Nullable<decimal> Month11 { get; set; }
        public Nullable<decimal> Month12 { get; set; }

        public Nullable<decimal> YearTotal { get; set; }
    }
}