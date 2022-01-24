using System;

namespace LabaidMIS.Data.Classes
{
    public class BrandWiseSalesAnalysis
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public Nullable<decimal> Value1 { get; set; }
        public Nullable<decimal> Value2 { get; set; }
        public Nullable<decimal> Value3 { get; set; }
        public Nullable<decimal> ValueLastMonth { get; set; }

        public Nullable<decimal> ValueUp1 { get; set; }
        public Nullable<decimal> ValueUp2 { get; set; }
        public Nullable<decimal> ValueUpPrvMonth { get; set; }
        public Nullable<decimal> ValueUp3 { get; set; }

        public Nullable<decimal> DailySalesLastYear { get; set; }
        public Nullable<decimal> DailySalesLastMonth { get; set; }
        public Nullable<decimal> DailySalesYesterday { get; set; }

        public Nullable<decimal> Growth1 { get; set; }
        public Nullable<decimal> Growth2 { get; set; }

        public Nullable<decimal> Rank1 { get; set; }
        public Nullable<decimal> Rank2 { get; set; }
        public Nullable<int> RankChange { get; set; }

        public Nullable<decimal> Contribution1 { get; set; }
        public Nullable<decimal> Contribution2 { get; set; }
        public Nullable<decimal> ContributionChange { get; set; }

        public Boolean IsOpen { get; set; }
    }

    public class BrandWiseSalesTotal
    {
        public int YearNo { get; set; }
        public int ReportColumnTypeId { get; set; }
        public Nullable<decimal> TotalTP { get; set; }
        public Nullable<decimal> SalesWithVAT { get; set; }
        public Nullable<decimal> NetSales { get; set; }
    }

    public class BrandWiseYearlySales
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public Nullable<decimal> YearOneSales { get; set; }
        public Nullable<decimal> YearTwoSales { get; set; }
        public Nullable<decimal> YearThreeSales { get; set; }
        public Nullable<decimal> LastMonthSales { get; set; }

        public Nullable<decimal> TotalSalesUpto1 { get; set; }
        public Nullable<decimal> TotalSalesUpto2 { get; set; }
        public Nullable<decimal> TotalSalesUpto3 { get; set; }
        public Nullable<decimal> TotalSalesUpto4 { get; set; }

        public Nullable<decimal> DailySales1 { get; set; }
        public Nullable<decimal> DailySales2 { get; set; }
        public Nullable<decimal> DailySales3 { get; set; }

        public Nullable<decimal> Growth1 { get; set; }
        public Nullable<decimal> Growth2 { get; set; }

        public Nullable<decimal> Rank1 { get; set; }
        public Nullable<decimal> Rank2 { get; set; }

        public Boolean IsOpen { get; set; }
    }

    public class BrandWiseYearlyProductSales
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<int> YearOneQuantity { get; set; }
        public Nullable<decimal> YearOneSales { get; set; }
        public Nullable<int> YearTwoQuantity { get; set; }
        public Nullable<decimal> YearTwoSales { get; set; }
        public Nullable<int> YearThreeQuantity { get; set; }
        public Nullable<decimal> YearThreeSales { get; set; }
        public Nullable<int> Upto1Quantity { get; set; }
        public Nullable<decimal> Upto1Sales { get; set; }
        public Nullable<int> Upto2Quantity { get; set; }
        public Nullable<decimal> Upto2Sales { get; set; }
        public Nullable<int> Upto3Quantity { get; set; }
        public Nullable<decimal> Upto3Sales { get; set; }

        public Nullable<int> MonthOneQuantity { get; set; }
        public Nullable<decimal> MonthOneSales { get; set; }
        public Nullable<int> MonthTwoQuantity { get; set; }
        public Nullable<decimal> MonthTwoSales { get; set; }
        public Nullable<int> MonthThreeQuantity { get; set; }
        public Nullable<decimal> MonthThreeSales { get; set; }

        public Nullable<decimal> Growth1 { get; set; }
        public Nullable<decimal> Growth2 { get; set; }
    }

    public class BrandWiseYearlyProductDailySales
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<int> Day3Quantity1 { get; set; }
        public Nullable<decimal> Day3Sales1 { get; set; }
        public Nullable<int> Day3Quantity2 { get; set; }
        public Nullable<decimal> Day3Sales2 { get; set; }
        public Nullable<int> Day3Quantity3 { get; set; }
        public Nullable<decimal> Day3Sales3 { get; set; }
        public Nullable<int> Day2Quantity1 { get; set; }
        public Nullable<decimal> Day2Sales1 { get; set; }
        public Nullable<int> Day2Quantity2 { get; set; }
        public Nullable<decimal> Day2Sales2 { get; set; }
        public Nullable<int> Day2Quantity3 { get; set; }
        public Nullable<decimal> Day2Sales3 { get; set; }
        public Nullable<int> Day1Quantity1 { get; set; }
        public Nullable<decimal> Day1Sales1 { get; set; }
        public Nullable<int> Day1Quantity2 { get; set; }
        public Nullable<decimal> Day1Sales2 { get; set; }
        public Nullable<int> Day1Quantity3 { get; set; }
        public Nullable<decimal> Day1Sales3 { get; set; }
    }

    public class BrandWiseYearlyLocationSales
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> JoiningDate { get; set; }
        public string ProfileImageName { get; set; }

        public Nullable<decimal> STPercent { get; set; }
        public Nullable<decimal> MonthlySales1 { get; set; }
        public Nullable<decimal> MonthlySales2 { get; set; }
        public Nullable<decimal> MonthlySales3 { get; set; }
        public Nullable<decimal> MonthlySales4 { get; set; }
        public Nullable<decimal> UptoSales1 { get; set; }
        public Nullable<decimal> UptoSales2 { get; set; }
        public Nullable<decimal> UptoSales3 { get; set; }

        public Nullable<decimal> Rank1 { get; set; }
        public Nullable<decimal> Rank2 { get; set; }

        public Nullable<decimal> Growth { get; set; }
    }
}