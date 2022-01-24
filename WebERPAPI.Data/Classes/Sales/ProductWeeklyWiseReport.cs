using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Sales
{
    public class ProductWeeklyWiseReport
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> GrowthAVG { get; set; }

        public List<ProductWeeklyWiseTerritoryDetails> TerritoryDetails { get; set; }
    }

    public class ProductWeeklyWiseTerritoryDetails
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public Nullable<int> CurrentMonthWeek1Quantity { get; set; }
        public Nullable<int> CurrentMonthWeek2Quantity { get; set; }
        public Nullable<int> CurrentMonthWeek3Quantity { get; set; }
        public Nullable<int> CurrentMonthWeek4Quantity { get; set; }

        public Nullable<int> PreviousMonth1Week1Quantity { get; set; }
        public Nullable<int> PreviousMonth1Week2Quantity { get; set; }
        public Nullable<int> PreviousMonth1Week3Quantity { get; set; }
        public Nullable<int> PreviousMonth1Week4Quantity { get; set; }

        public Nullable<int> PreviousMonth2Week1Quantity { get; set; }
        public Nullable<int> PreviousMonth2Week2Quantity { get; set; }
        public Nullable<int> PreviousMonth2Week3Quantity { get; set; }
        public Nullable<int> PreviousMonth2Week4Quantity { get; set; }
    }

    public class ProductWeeklyWiseValueReport
    {
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }
        public Nullable<decimal> GrowthAVG { get; set; }

        public List<ProductWeeklyWiseSalesValueLocationDetails> LocationDetails { get; set; }
    }

    public class ProductWeeklyWiseSalesValueLocationDetails
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public Nullable<decimal> CurrentMonthWeek1Value { get; set; }
        public Nullable<decimal> CurrentMonthWeek2Value { get; set; }
        public Nullable<decimal> CurrentMonthWeek3Value { get; set; }
        public Nullable<decimal> CurrentMonthWeek4Value { get; set; }

        public Nullable<decimal> PreviousMonth1Week1Value { get; set; }
        public Nullable<decimal> PreviousMonth1Week2Value { get; set; }
        public Nullable<decimal> PreviousMonth1Week3Value { get; set; }
        public Nullable<decimal> PreviousMonth1Week4Value { get; set; }

        public Nullable<decimal> PreviousMonth2Week1Value { get; set; }
        public Nullable<decimal> PreviousMonth2Week2Value { get; set; }
        public Nullable<decimal> PreviousMonth2Week3Value { get; set; }
        public Nullable<decimal> PreviousMonth2Week4Value { get; set; }
    }

    public class ProductWiseWeeklySalesReportData
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> ProductID { get; set; }

        public Nullable<int> CurrentMonthWeek1Quantity { get; set; }
        public Nullable<int> CurrentMonthWeek2Quantity { get; set; }
        public Nullable<int> CurrentMonthWeek3Quantity { get; set; }
        public Nullable<int> CurrentMonthWeek4Quantity { get; set; }

        public Nullable<int> PreviousMonth1Week1Quantity { get; set; }
        public Nullable<int> PreviousMonth1Week2Quantity { get; set; }
        public Nullable<int> PreviousMonth1Week3Quantity { get; set; }
        public Nullable<int> PreviousMonth1Week4Quantity { get; set; }

        public Nullable<int> PreviousMonth2Week1Quantity { get; set; }
        public Nullable<int> PreviousMonth2Week2Quantity { get; set; }
        public Nullable<int> PreviousMonth2Week3Quantity { get; set; }
        public Nullable<int> PreviousMonth2Week4Quantity { get; set; }
    }

    public class ProductWiseWeeklySalesValueReportData
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> BrandID { get; set; }

        public Nullable<decimal> CurrentMonthWeek1Value { get; set; }
        public Nullable<decimal> CurrentMonthWeek2Value { get; set; }
        public Nullable<decimal> CurrentMonthWeek3Value { get; set; }
        public Nullable<decimal> CurrentMonthWeek4Value { get; set; }

        public Nullable<decimal> PreviousMonth1Week1Value { get; set; }
        public Nullable<decimal> PreviousMonth1Week2Value { get; set; }
        public Nullable<decimal> PreviousMonth1Week3Value { get; set; }
        public Nullable<decimal> PreviousMonth1Week4Value { get; set; }

        public Nullable<decimal> PreviousMonth2Week1Value { get; set; }
        public Nullable<decimal> PreviousMonth2Week2Value { get; set; }
        public Nullable<decimal> PreviousMonth2Week3Value { get; set; }
        public Nullable<decimal> PreviousMonth2Week4Value { get; set; }
    }

    public class ProductWiseWeeklySales
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<decimal> CurrentMonthWeek1Sales { get; set; }
        public Nullable<decimal> CurrentMonthWeek2Sales { get; set; }
        public Nullable<decimal> CurrentMonthWeek3Sales { get; set; }
        public Nullable<decimal> CurrentMonthWeek4Sales { get; set; }
        public Nullable<decimal> PreviousMonth1Week1Sales { get; set; }
        public Nullable<decimal> PreviousMonth1Week2Sales { get; set; }
        public Nullable<decimal> PreviousMonth1Week3Sales { get; set; }
        public Nullable<decimal> PreviousMonth1Week4Sales { get; set; }
        public Nullable<decimal> PreviousMonth2Week1Sales { get; set; }
        public Nullable<decimal> PreviousMonth2Week2Sales { get; set; }
        public Nullable<decimal> PreviousMonth2Week3Sales { get; set; }
        public Nullable<decimal> PreviousMonth2Week4Sales { get; set; }
    }

    public class ProductDailySalesQuantity
    {
        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}