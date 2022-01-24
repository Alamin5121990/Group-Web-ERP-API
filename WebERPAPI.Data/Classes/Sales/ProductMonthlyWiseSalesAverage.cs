using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes
{
    public class ProductMonthlyWiseReport
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> GrowthAVG { get; set; }

        public List<ProductMonthlyWiseLocationDetails> LocationDetails { get; set; }
    }

    public class ProductMonthlyWiseLocationDetails
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> STPercent { get; set; }

        public Nullable<int> Month1SalesQuantity { get; set; }
        public Nullable<int> Month2SalesQuantity { get; set; }
        public Nullable<int> Month3SalesQuantity { get; set; }
        public Nullable<int> Average1SalesQuantity { get; set; }

        public Nullable<int> Month4SalesQuantity { get; set; }
        public Nullable<int> Month5SalesQuantity { get; set; }
        public Nullable<int> Month6SalesQuantity { get; set; }
        public Nullable<int> Average2SalesQuantity { get; set; }

        public Nullable<int> Month7SalesQuantity { get; set; }
        public Nullable<int> Month8SalesQuantity { get; set; }
        public Nullable<int> Month9SalesQuantity { get; set; }
        public Nullable<int> Average3SalesQuantity { get; set; }

        public Nullable<int> Month10SalesQuantity { get; set; }
        public Nullable<int> Month11SalesQuantity { get; set; }
        public Nullable<int> Month12SalesQuantity { get; set; }
        public Nullable<int> Average4SalesQuantity { get; set; }

        public Nullable<int> Month1NationalQuantity { get; set; }
        public Nullable<int> Month2NationalQuantity { get; set; }
        public Nullable<int> Month3NationalQuantity { get; set; }
        public Nullable<int> Month4NationalQuantity { get; set; }
        public Nullable<int> Month5NationalQuantity { get; set; }
        public Nullable<int> Month6NationalQuantity { get; set; }
        public Nullable<int> Month7NationalQuantity { get; set; }
        public Nullable<int> Month8NationalQuantity { get; set; }
        public Nullable<int> Month9NationalQuantity { get; set; }
        public Nullable<int> Month10NationalQuantity { get; set; }
        public Nullable<int> Month11NationalQuantity { get; set; }
        public Nullable<int> Month12NationalQuantity { get; set; }

        public Nullable<int> National1QuantityAverage { get; set; }
        public Nullable<int> National2QuantityAverage { get; set; }
        public Nullable<int> National3QuantityAverage { get; set; }
        public Nullable<int> National4QuantityAverage { get; set; }
    }

    public class ProductWiseMonthlySalesAverageData
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
    }

    public class ProductWiseMonthlySalesValue
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }

    public class ProductWiseMonthlySalesValueReport
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }

        public Nullable<decimal> Month1Sales { get; set; }
        public Nullable<decimal> Month2Sales { get; set; }
        public Nullable<decimal> Month3Sales { get; set; }
        public Nullable<decimal> Quarter1SalesAverage { get; set; }

        public Nullable<decimal> Month4Sales { get; set; }
        public Nullable<decimal> Month5Sales { get; set; }
        public Nullable<decimal> Month6Sales { get; set; }
        public Nullable<decimal> Quarter2SalesAverage { get; set; }

        public Nullable<decimal> Month7Sales { get; set; }
        public Nullable<decimal> Month8Sales { get; set; }
        public Nullable<decimal> Month9Sales { get; set; }
        public Nullable<decimal> Quarter3SalesAverage { get; set; }

        public Nullable<decimal> Month10Sales { get; set; }
        public Nullable<decimal> Month11Sales { get; set; }
        public Nullable<decimal> Month12Sales { get; set; }
        public Nullable<decimal> Quarter4SalesAverage { get; set; }
    }

    // SALES VALUE

    public class BrandMonthlyWiseSalesValueReport
    {
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public Nullable<decimal> GrowthAVG { get; set; }

        public List<BrandMonthlyWiseSalesValueLocationDetails> LocationDetails { get; set; }
    }

    public class BrandMonthlyWiseSalesValueLocationDetails
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> STPercent { get; set; }

        public Nullable<decimal> Month1SalesValue { get; set; }
        public Nullable<decimal> Month2SalesValue { get; set; }
        public Nullable<decimal> Month3SalesValue { get; set; }
        public Nullable<decimal> Average1SalesValue { get; set; }

        public Nullable<decimal> Month4SalesValue { get; set; }
        public Nullable<decimal> Month5SalesValue { get; set; }
        public Nullable<decimal> Month6SalesValue { get; set; }
        public Nullable<decimal> Average2SalesValue { get; set; }

        public Nullable<decimal> Month7SalesValue { get; set; }
        public Nullable<decimal> Month8SalesValue { get; set; }
        public Nullable<decimal> Month9SalesValue { get; set; }
        public Nullable<decimal> Average3SalesValue { get; set; }

        public Nullable<decimal> Month10SalesValue { get; set; }
        public Nullable<decimal> Month11SalesValue { get; set; }
        public Nullable<decimal> Month12SalesValue { get; set; }
        public Nullable<decimal> Average4SalesValue { get; set; }

        public Nullable<decimal> National1SalesValueAverage { get; set; }
        public Nullable<decimal> National2SalesValueAverage { get; set; }
        public Nullable<decimal> National3SalesValueAverage { get; set; }
        public Nullable<decimal> National4SalesValueAverage { get; set; }
    }

    public class BrandWiseMonthlySalesValueAverageData
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> BrandId { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }

    public class ProductWiseMonthlyTotalSalesValue
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }

        public Nullable<decimal> Month1Sales { get; set; }
        public Nullable<decimal> Month2Sales { get; set; }
        public Nullable<decimal> Month3Sales { get; set; }

        public Nullable<decimal> Month4Sales { get; set; }
        public Nullable<decimal> Month5Sales { get; set; }
        public Nullable<decimal> Month6Sales { get; set; }

        public Nullable<decimal> Month7Sales { get; set; }
        public Nullable<decimal> Month8Sales { get; set; }
        public Nullable<decimal> Month9Sales { get; set; }

        public Nullable<decimal> Month10Sales { get; set; }
        public Nullable<decimal> Month11Sales { get; set; }
        public Nullable<decimal> Month12Sales { get; set; }
    }
}