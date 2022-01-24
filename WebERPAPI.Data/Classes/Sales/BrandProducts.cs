using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class BrandProducts
    {
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string SalesCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string SPS { get; set; }
        public string ProductionLocation { get; set; }
        public string ProductPriorityCode { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
    }

    public class BrandProductsTarget
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public Nullable<decimal> ActualQty { get; set; }
    }

    public class ProductSalesDetails
    {
        public int ProductId { get; set; }
        public int MonthNo { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
    }

    public class ProductSalesQuantity
    {
        public int ID { get; set; }
        public int MonthNo { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
    }

    public class LocationSalesTargetQuantity
    {
        public string ID { get; set; }
        public string LocationName { get; set; }
        public Nullable<int> TargetQuantity { get; set; }
    }

    public class ProductMonitorReport
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ProductID { get; set; }
        public string SalesCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }

        public Nullable<decimal> TargetQty { get; set; }
        public Nullable<decimal> SalesPrevMonth { get; set; }
        public Nullable<decimal> SalesUpToPrevMonth { get; set; }
        public Nullable<decimal> SalesUpTo { get; set; }
        public Nullable<decimal> TodaysSalesPrevMonth { get; set; }
        public Nullable<decimal> TodaysSales { get; set; }

        public Nullable<decimal> SalesUptoValue { get; set; }
        public Nullable<decimal> SalesUpToValuePrevMonth { get; set; }

        public Nullable<decimal> Ach { get; set; }
        public Nullable<decimal> Growth { get; set; }
    }

    public class LocationProductQuantityReport
    {
        public int ID { get; set; }
        public string LocationName { get; set; }

        public Nullable<decimal> TargetQty { get; set; }
        public Nullable<decimal> SalesUpToPrevMonth { get; set; }
        public Nullable<decimal> SalesUpTo { get; set; }

        public Nullable<decimal> SalesUptoValue { get; set; }
        public Nullable<decimal> SalesUpToValuePrevMonth { get; set; }

        public Nullable<decimal> SalesAverage { get; set; }

        public Nullable<decimal> TodaysSalesPrevMonth { get; set; }
        public Nullable<decimal> TodaysSales { get; set; }

        public Nullable<decimal> Ach { get; set; }
        public Nullable<decimal> Growth { get; set; }
    }

    public class ProductFreeStock
    {
        public string DepotID { get; set; }
        public string DepotName { get; set; }
        public Nullable<decimal> ReceiveQuantity { get; set; }
        public Nullable<decimal> SoldQuantity { get; set; }
        public Nullable<decimal> TransitQuantity { get; set; }
        public Nullable<decimal> ClosingQuantity { get; set; }
    }
}