using System;

namespace LabaidMIS.Data.Classes.Sales.Search
{
    public class SalesReportNationalByProductData
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> TotalQuantity { get; set; }
    }

    public class SalesReportNationalByProduct
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
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

        public Nullable<decimal> Month13 { get; set; }
        public Nullable<decimal> Month14 { get; set; }
        public Nullable<decimal> Month15 { get; set; }
        public Nullable<decimal> Month16 { get; set; }
        public Nullable<decimal> Month17 { get; set; }
        public Nullable<decimal> Month18 { get; set; }
        public Nullable<decimal> Month19 { get; set; }
        public Nullable<decimal> Month20 { get; set; }
        public Nullable<decimal> Month21 { get; set; }
        public Nullable<decimal> Month22 { get; set; }
        public Nullable<decimal> Month23 { get; set; }
        public Nullable<decimal> Month24 { get; set; }

        public Nullable<decimal> YearTotal { get; set; }
    }

    public class SalesReportNationalByProductMonthTitle
    {
        public string MonthTitle1 { get; set; }
        public string MonthTitle2 { get; set; }
        public string MonthTitle3 { get; set; }
        public string MonthTitle4 { get; set; }
        public string MonthTitle5 { get; set; }
        public string MonthTitle6 { get; set; }
        public string MonthTitle7 { get; set; }
        public string MonthTitle8 { get; set; }
        public string MonthTitle9 { get; set; }
        public string MonthTitle10 { get; set; }
        public string MonthTitle11 { get; set; }
        public string MonthTitle12 { get; set; }
        public string MonthTitle13 { get; set; }
        public string MonthTitle14 { get; set; }
        public string MonthTitle15 { get; set; }
        public string MonthTitle16 { get; set; }
        public string MonthTitle17 { get; set; }
        public string MonthTitle18 { get; set; }
        public string MonthTitle19 { get; set; }
        public string MonthTitle20 { get; set; }
        public string MonthTitle21 { get; set; }
        public string MonthTitle22 { get; set; }
        public string MonthTitle23 { get; set; }
        public string MonthTitle24 { get; set; }
    }
}