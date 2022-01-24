using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Sales
{
    public class AllBrandSalesComparisonReport
    {
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }
        public List<AllBrandSalesReportMonthlyData> LocationDetails { get; set; }
    }

    public class AllBrandSalesReportMonthlyData
    {
        public Nullable<int> BrandId { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }

        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
    }

    public class BrandSalesComparisonReport
    {
        public Nullable<int> RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }

        public Nullable<int> ParentLocationID { get; set; }
        public string ParentLocationCode { get; set; }
        public string ParentLocationName { get; set; }

        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> STPercent { get; set; }

        public List<BrandSalesComparisonData> LocationDetails { get; set; }
    }

    public class BrandSalesComparisonData
    {
        public Nullable<int> LocationID { get; set; }

        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }

        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
    }
}