using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class BrandWiseSalesAchievement
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<decimal> CurrentMonthSalesUpto { get; set; }
        public Nullable<decimal> LastMonthSalesUpto { get; set; }
        public Nullable<decimal> LastMonthTotalSales { get; set; }
        public Nullable<decimal> Achievement { get; set; }
        public Nullable<decimal> Growth { get; set; }
        public Nullable<Boolean> IsOpen { get; set; }
    }

    public class ProductEmployeeWiseSalesAchievement
    {
        public int ProductID { get; set; }
        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<int> TargetTotalQuantity { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
        public Nullable<int> CurrentMonthQuantityUpto { get; set; }
        public Nullable<decimal> CurrentMonthSalesUpto { get; set; }
        public Nullable<int> LastMonthQuantityUpto { get; set; }
        public Nullable<decimal> LastMonthSalesUpto { get; set; }
        public Nullable<int> LastMonthTotalQuantity { get; set; }
        public Nullable<decimal> LastMonthTotalSales { get; set; }
        public Nullable<int> YesterdaySalesQuantity { get; set; }
    }

    public class ProductEmployeeWiseSalesAchievementReport
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }

        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<int> TargetTotalQuantity { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<decimal> TotalSales { get; set; }

        public Nullable<int> CurrentMonthQuantityUpto { get; set; }
        public Nullable<decimal> CurrentMonthSalesUpto { get; set; }

        public Nullable<int> LastMonthQuantityUpto { get; set; }
        public Nullable<decimal> LastMonthSalesUpto { get; set; }

        public Nullable<int> LastMonthTotalQuantity { get; set; }
        public Nullable<decimal> LastMonthTotalSales { get; set; }

        public Nullable<int> YesterdaySalesQuantity { get; set; }

        public Nullable<decimal> BrandTotal { get; set; }
        public Nullable<decimal> LastMonthBrandTotal { get; set; }

        public Nullable<decimal> Growth { get; set; }
    }

    public class ProductEmployeeLocationSalesAchievement
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public string ProfileImageName { get; set; }
        public Nullable<decimal> STPercent { get; set; }

        public Nullable<decimal> SalesTarget { get; set; }
        public Nullable<int> TargetQuantity { get; set; }
        public Nullable<int> TotalSoldQuantity { get; set; }
        public Nullable<decimal> TotalSoldValue { get; set; }

        public Nullable<int> CurrentMonthQuantityUpto { get; set; }
        public Nullable<decimal> CurrentMonthSalesUpto { get; set; }
        public Nullable<int> LastMonthQuantityUpto { get; set; }
        public Nullable<decimal> LastMonthSalesUpto { get; set; }
        public Nullable<int> LastMonthTotalQuantity { get; set; }
        public Nullable<decimal> LastMonthTotalSales { get; set; }

        public Nullable<decimal> BrandTotal { get; set; }
        public Nullable<decimal> LastMonthBrandTotal { get; set; }

        public Nullable<int> LastYearThisDayQuantity { get; set; }
        public Nullable<int> LastMonthDayQuantity { get; set; }
        public Nullable<int> YesterDayQuantity { get; set; }

        public Nullable<decimal> Growth { get; set; }
    }
}