using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DailySalesAnalysis
    {
        public Nullable<int> LocationID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> TotalSoldQuantity { get; set; }
        public Nullable<decimal> TotalSoldValue { get; set; }
        public Nullable<int> LastMonthSoldQuantity { get; set; }
        public Nullable<decimal> LastMonthSoldValue { get; set; }
        public Nullable<int> LastYearSoldQuantity { get; set; }
        public Nullable<decimal> LastYearSoldValue { get; set; }

        public Nullable<decimal> WeeklySoldValue { get; set; }
        public Nullable<decimal> LastMonthWeeklySoldValue { get; set; }
        public Nullable<decimal> LastYearWeeklySoldValue { get; set; }
        public Nullable<decimal> SoldValueUpto { get; set; }

        public Nullable<decimal> MonthASoldValue { get; set; }
        public Nullable<decimal> MonthBSoldValue { get; set; }
        public Nullable<decimal> MonthCSoldValue { get; set; }
        public Nullable<decimal> MonthDSoldValue { get; set; }
    }

    public class DailySalesAnalysisReport
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> STPercent { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }

        public string Department { get; set; }
        public string Designation { get; set; }
        public string ProfileImagename { get; set; }

        public Nullable<int> TotalSoldQuantity { get; set; }
        public Nullable<decimal> TotalSoldValue { get; set; }
        public Nullable<int> LastMonthSoldQuantity { get; set; }
        public Nullable<decimal> LastMonthSoldValue { get; set; }
        public Nullable<int> LastYearSoldQuantity { get; set; }
        public Nullable<decimal> LastYearSoldValue { get; set; }

        public Nullable<decimal> WeeklySoldValue { get; set; }
        public Nullable<decimal> LastMonthWeeklySoldValue { get; set; }
        public Nullable<decimal> LastYearWeeklySoldValue { get; set; }
        public Nullable<decimal> SoldValueUpto { get; set; }

        public Nullable<decimal> MonthASoldValue { get; set; }
        public Nullable<decimal> MonthBSoldValue { get; set; }
        public Nullable<decimal> MonthCSoldValue { get; set; }
        public Nullable<decimal> MonthDSoldValue { get; set; }
    }

    public class DailySalesForAllLocations
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationLevel { get; set; }
        public Nullable<decimal> YesterDaySales { get; set; }
        public Nullable<decimal> LastMonthDaySales { get; set; }
        public Nullable<decimal> LastYearThisDaySales { get; set; }
    }
}