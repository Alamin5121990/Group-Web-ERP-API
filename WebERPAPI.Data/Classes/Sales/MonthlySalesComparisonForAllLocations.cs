using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class MonthlySalesComparisonForAllLocations
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationLevel { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<int> LastYear { get; set; }
        public Nullable<int> LastYearMonth { get; set; }
        public Nullable<decimal> LastYearSales { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
    }

    public class MonthlySalesComparisonReport
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationLevel { get; set; }

        public Nullable<decimal> CurrentYearSales1 { get; set; }
        public Nullable<decimal> CurrentYearSales2 { get; set; }
        public Nullable<decimal> CurrentYearSales3 { get; set; }
        public Nullable<decimal> CurrentYearSales4 { get; set; }
        public Nullable<decimal> CurrentYearSales5 { get; set; }
        public Nullable<decimal> CurrentYearSales6 { get; set; }
        public Nullable<decimal> CurrentYearSales7 { get; set; }
        public Nullable<decimal> CurrentYearSales8 { get; set; }
        public Nullable<decimal> CurrentYearSales9 { get; set; }
        public Nullable<decimal> CurrentYearSales10 { get; set; }
        public Nullable<decimal> CurrentYearSales11 { get; set; }
        public Nullable<decimal> CurrentYearSales12 { get; set; }

        public Nullable<decimal> LastYearSales1 { get; set; }
        public Nullable<decimal> LastYearSales2 { get; set; }
        public Nullable<decimal> LastYearSales3 { get; set; }
        public Nullable<decimal> LastYearSales4 { get; set; }
        public Nullable<decimal> LastYearSales5 { get; set; }
        public Nullable<decimal> LastYearSales6 { get; set; }
        public Nullable<decimal> LastYearSales7 { get; set; }
        public Nullable<decimal> LastYearSales8 { get; set; }
        public Nullable<decimal> LastYearSales9 { get; set; }
        public Nullable<decimal> LastYearSales10 { get; set; }
        public Nullable<decimal> LastYearSales11 { get; set; }
        public Nullable<decimal> LastYearSales12 { get; set; }

        public Nullable<decimal> CurrentYearSalesTarget1 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget2 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget3 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget4 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget5 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget6 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget7 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget8 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget9 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget10 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget11 { get; set; }
        public Nullable<decimal> CurrentYearSalesTarget12 { get; set; }
    }
}