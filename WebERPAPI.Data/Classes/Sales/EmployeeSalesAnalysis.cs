using System;
using System.ComponentModel.DataAnnotations;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class EmployeeSalesAnalysisReport
    {
        public Nullable<int> ID { get; set; }
        public string LocationName { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
        public string Mobile { get; set; }
        public string DateOfJoining { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public Nullable<decimal> TargetValue { get; set; }

        public Nullable<decimal> CurrentMonthUptoSales { get; set; }
        public Nullable<decimal> PreviousMonthUptoSales { get; set; }
        public Nullable<decimal> PreviousMonthTotalSales { get; set; }

        public Nullable<decimal> Achievement { get; set; }
        public Nullable<decimal> Average { get; set; }
        public Nullable<decimal> Growth { get; set; }
    }

    public class EmployeeSalesAnalysis
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationName { get; set; }

        [Key]
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> LastMonthUptoSales { get; set; }
        public Nullable<decimal> LastMonthTotalSales { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
    }

    public class EmployeeSalesAnalysisAchievement
    {
        public int OAID { get; set; }
        public int Achievement { get; set; }
        public int TotalEmployee { get; set; }
    }

    public class EmployeeSalesAnalysisAchievementReport
    {
        public Nullable<int> ID { get; set; }
        public string LocationName { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }
        public string Mobile { get; set; }
        public string DateOfJoining { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public Nullable<decimal> TargetValue { get; set; }

        public Nullable<decimal> CurrentMonthUptoSales { get; set; }
        public Nullable<decimal> PreviousMonthUptoSales { get; set; }
        public Nullable<decimal> PreviousMonthTotalSales { get; set; }

        public Nullable<decimal> Achievement { get; set; }
        public Nullable<decimal> Average { get; set; }
        public Nullable<decimal> Growth { get; set; }

        public int Achievement120 { get; set; }
        public int Achievement100 { get; set; }
        public int Achievement80 { get; set; }
        public int Achievement50 { get; set; }
        public int AchievementOthers { get; set; }
    }

    public class EmployeeSalesAnalysisAchievementDetails
    {
        public string ZoneName { get; set; }
        public string RegionName { get; set; }
        public string AreaName { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public decimal STPercent { get; set; }
        public decimal TargetValue { get; set; }

        public decimal TotalSales { get; set; }
        public decimal LastMonthUptoSales { get; set; }
        public decimal LastMonthTotalSales { get; set; }

        public decimal Achievement { get; set; }
        public decimal Average { get; set; }
        public decimal Growth { get; set; }
    }

    public class EmployeeSalesAnalysisAchievementDetailsReport
    {
        public string ZoneName { get; set; }
        public string RegionName { get; set; }
        public string AreaName { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string DateOfJoining { get; set; }
        public decimal STPercent { get; set; }
        public decimal TargetValue { get; set; }

        public decimal TotalSales { get; set; }
        public decimal LastMonthUptoSales { get; set; }
        public decimal LastMonthTotalSales { get; set; }

        public decimal Achievement { get; set; }
        public decimal Average { get; set; }
        public decimal Growth { get; set; }
    }

    public class EmployeeSalesAnalysisZoneAchievement
    {
        public int ID { get; set; }
        public int TotalEmployee { get; set; }
    }

    public class EmployeeSalesAnalysisZoneAchievementReport
    {
        public int ID { get; set; }
        public string ZoneName { get; set; }
        public int TotalEmployee { get; set; }
    }

    public class EmployeeProductSalesAnalysisReport
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }

        public decimal TargetQty { get; set; }
        public Nullable<decimal> TargetValue { get; set; }

        public Nullable<decimal> TotalSalesQty { get; set; }
        public Nullable<decimal> TotalSales { get; set; }

        public Nullable<decimal> LastMonthUptoSalesQty { get; set; }
        public Nullable<decimal> LastMonthUptoSales { get; set; }

        public Nullable<decimal> LastMonthTotalSalesQty { get; set; }
        public Nullable<decimal> LastMonthTotalSales { get; set; }

        public Nullable<decimal> Achievement { get; set; }
        public Nullable<decimal> Growth { get; set; }
    }

    public class EmployeeProductSalesSummary
    {
        public int ProductID { get; set; }
        public int SoldQuantity { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
        public int MonthNo { get; set; }
    }

    public class TerritoryProductTargetQuantity
    {
        public int ProductID { get; set; }
        public int TargetQty { get; set; }
    }

    public class EmployeeWiseSalesReport
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }

        public Nullable<decimal> STPercent { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> JoiningDate { get; set; }
        public string ProfileImageName { get; set; }

        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<decimal> CurrentMonthSalesUpto { get; set; }
        public Nullable<decimal> LastMonthSalesUpto { get; set; }
        public Nullable<decimal> LastYearMonthSalesUpto { get; set; }

        public Nullable<decimal> LastMonthTotalSales { get; set; }

        public Nullable<decimal> Achievement { get; set; }
        public Nullable<decimal> Growth { get; set; }

        public Nullable<decimal> YesterDaySales { get; set; }
        public Nullable<decimal> LastMonthDaySales { get; set; }
        public Nullable<decimal> LastYearThisDaySales { get; set; }
        public Nullable<decimal> DaySalesDifference { get; set; }

        public Nullable<int> TotalMPO { get; set; }
        public Nullable<int> CurrentMonthAchievement { get; set; }
        public Nullable<int> LastMonthAchievement { get; set; }
    }
}