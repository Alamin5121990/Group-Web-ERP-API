using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class BrandSalesTarget
    {
        public string Brand { get; set; }
        public Nullable<decimal> TargetTP { get; set; }
        public Nullable<decimal> SoldTP { get; set; }
        public Nullable<decimal> BrandAch { get; set; }
        public Nullable<decimal> SoldValuePreUpto { get; set; }
        public Nullable<decimal> SoldValuePreTotal { get; set; }
        public Nullable<decimal> Growth { get; set; }
    }

    public class ProductWiseSalesTarget
    {
        public string CompanyID { get; set; }
        public string Brand { get; set; }
        public string productid { get; set; }
        public string productname { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TradePrice { get; set; }
        public Nullable<decimal> Targetqty { get; set; }
        public Nullable<decimal> SodlQty { get; set; }
        public Nullable<decimal> TargetTP { get; set; }
        public Nullable<decimal> SoldTP { get; set; }
        public Nullable<decimal> ProductAch { get; set; }
        public Nullable<decimal> SoldQtyPreUpto { get; set; }
        public Nullable<decimal> SoldQtyPretotal { get; set; }
        public Nullable<decimal> SoldValuePreUpto { get; set; }
        public Nullable<decimal> SoldValuePreTotal { get; set; }
        public Nullable<decimal> Growth { get; set; }
    }

    public class ZoneProductWiseTargetAchievement
    {
        public string CompanyID { get; set; }
        public int YEAR { get; set; }
        public int MONTH { get; set; }
        public string ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string ZSMID { get; set; }
        public string ZSMName { get; set; }
        public string Mobile { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public string Brand { get; set; }
        public string ProductID { get; set; }
        public string productName { get; set; }
        public int TargetQty { get; set; }
        public Nullable<decimal> SalesQty { get; set; }
        public Nullable<decimal> QtyAverage { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public Nullable<decimal> SalesValue { get; set; }
        public Nullable<decimal> ACHPercent { get; set; }
        public Nullable<decimal> Average { get; set; }
        public int NationalTargetQty { get; set; }
        public int NationalSalesQty { get; set; }
        public int NationalTargetValue { get; set; }
        public int NationalSalesValue { get; set; }
        public int NationalACHPercent { get; set; }
        public Nullable<decimal> BrandAVG { get; set; }
        public Nullable<decimal> SoldQtyPreUpto { get; set; }
        public Nullable<decimal> SoldValuePreUpto { get; set; }
        public Nullable<decimal> SoldQtyPretotal { get; set; }
        public Nullable<decimal> SoldValuePreTotal { get; set; }
        public Nullable<decimal> Growth { get; set; }
        public Nullable<decimal> AveragePre { get; set; }
        public Nullable<decimal> BrandAVGPre { get; set; }
        public Nullable<decimal> BrandTotal { get; set; }
        public Nullable<decimal> BrandTotalPre { get; set; }
    }

    public class RegionProductWiseTargetAchievement
    {
        public string CompanyID { get; set; }
        public int YEAR { get; set; }
        public int MONTH { get; set; }
        public string ZoneID { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string RSMID { get; set; }
        public string RSMName { get; set; }
        public string Mobile { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public string Brand { get; set; }
        public string ProductID { get; set; }
        public string productName { get; set; }
        public int TargetQty { get; set; }
        public Nullable<decimal> SalesQty { get; set; }
        public Nullable<decimal> QtyAverage { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public Nullable<decimal> SalesValue { get; set; }
        public Nullable<decimal> ACHPercent { get; set; }
        public Nullable<decimal> Average { get; set; }
        public int NationalTargetQty { get; set; }
        public Nullable<decimal> NationalSalesQty { get; set; }
        public Nullable<decimal> NationalTargetValue { get; set; }
        public Nullable<decimal> NationalSalesValue { get; set; }
        public Nullable<decimal> NationalACHPercent { get; set; }
        public Nullable<decimal> BrandAVG { get; set; }
        public Nullable<decimal> SoldQtyPreUpto { get; set; }
        public Nullable<decimal> SoldValuePreUpto { get; set; }
        public Nullable<decimal> SoldQtyPretotal { get; set; }
        public Nullable<decimal> SoldValuePreTotal { get; set; }
        public Nullable<decimal> Growth { get; set; }
        public Nullable<decimal> AveragePre { get; set; }
        public Nullable<decimal> BrandAVGPre { get; set; }
        public Nullable<decimal> BrandTotal { get; set; }
        public Nullable<decimal> BrandTotalPre { get; set; }
    }

    public class AreaProductWiseTargetAchievement
    {
        public string CompanyID { get; set; }
        public int YEAR { get; set; }
        public int MONTH { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string AreaID { get; set; }
        public string AreaName { get; set; }
        public string ASMID { get; set; }
        public string ASMName { get; set; }
        public string Mobile { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public string Brand { get; set; }
        public string ProductID { get; set; }
        public string productName { get; set; }
        public int TargetQty { get; set; }
        public Nullable<decimal> SalesQty { get; set; }
        public Nullable<decimal> QtyAverage { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public Nullable<decimal> SalesValue { get; set; }
        public Nullable<decimal> ACHPercent { get; set; }
        public Nullable<decimal> Average { get; set; }
        public int NationalTargetQty { get; set; }
        public Nullable<decimal> NationalSalesQty { get; set; }
        public Nullable<decimal> NationalTargetValue { get; set; }
        public Nullable<decimal> NationalSalesValue { get; set; }
        public Nullable<decimal> NationalACHPercent { get; set; }
        public int RegionTargetQty { get; set; }
        public Nullable<decimal> RegionSalesQty { get; set; }
        public Nullable<decimal> RegionTargetValue { get; set; }
        public Nullable<decimal> RegionSalesValue { get; set; }
        public Nullable<decimal> RegionACHPercent { get; set; }
        public Nullable<decimal> BrandAVG { get; set; }
        public Nullable<decimal> SoldQtyPreUpto { get; set; }
        public Nullable<decimal> SoldValuePreUpto { get; set; }
        public Nullable<decimal> SoldQtyPretotal { get; set; }
        public Nullable<decimal> SoldValuePreTotal { get; set; }
        public Nullable<decimal> Growth { get; set; }
        public Nullable<decimal> AveragePre { get; set; }
        public Nullable<decimal> BrandAVGPre { get; set; }
        public Nullable<decimal> BrandTotal { get; set; }
        public Nullable<decimal> BrandTotalPre { get; set; }
    }

    public class TerritoryProductWiseTargetAchievement
    {
        public string CompanyID { get; set; }
        public int YEAR { get; set; }
        public int MONTH { get; set; }
        public string AreaID { get; set; }
        public string AreaName { get; set; }
        public string territoryid { get; set; }
        public string territoryName { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public string Brand { get; set; }
        public string ProductID { get; set; }
        public string productName { get; set; }
        public int TargetQty { get; set; }
        public Nullable<decimal> SalesQty { get; set; }
        public Nullable<decimal> QtyAverage { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public Nullable<decimal> SalesValue { get; set; }
        public Nullable<decimal> ACHPercent { get; set; }
        public Nullable<decimal> Average { get; set; }
        public Nullable<decimal> BrandAVG { get; set; }
        public Nullable<decimal> SoldQtyPreUpto { get; set; }
        public Nullable<decimal> SoldValuePreUpto { get; set; }
        public Nullable<decimal> SoldQtyPretotal { get; set; }
        public Nullable<decimal> SoldValuePreTotal { get; set; }
        public Nullable<decimal> Growth { get; set; }
        public Nullable<decimal> AveragePre { get; set; }
        public Nullable<decimal> BrandAVGPre { get; set; }

        public Nullable<decimal> BrandTotal { get; set; }
        public Nullable<decimal> BrandTotalPre { get; set; }
    }
}