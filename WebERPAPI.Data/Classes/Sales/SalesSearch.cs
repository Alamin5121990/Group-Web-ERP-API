using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Sales
{
    public class SalesReportMonthlyData
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> TargetQuantity { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
    }

    public class SalesReportMonthlyReport
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

        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }

        public List<SalesReportMonthlyData> LocationDetails { get; set; }
    }

    public class SalesReportDepotMonthly
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> TargetQuantity { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
    }

    public class DepotMonthlySalesReport
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public List<SalesReportDepotMonthly> LocationDetails { get; set; }
    }
}