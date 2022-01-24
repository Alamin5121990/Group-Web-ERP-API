using System;

namespace WebERPAPI.DTO
{
    public class RegionWiseSales
    {
        public string CompanyID { get; set; }
        public string ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string ZSMID { get; set; }
        public string ZSMName { get; set; }
        public string Designation { get; set; }
        public string ZSMMobile { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string RSMID { get; set; }
        public string RSMName { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string RMMobile { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public Nullable<decimal> PlanMonthly { get; set; }
        public Nullable<decimal> SalesGeneral { get; set; }
        public Nullable<int> SalesInjectable { get; set; }
        public Nullable<decimal> LabaidGeneral { get; set; }
        public Nullable<int> LabaidInjectable { get; set; }
        public Nullable<decimal> SaleswithVAT { get; set; }
        public Nullable<int> MPONo { get; set; }
        public Nullable<decimal> PlanToDay { get; set; }
        public Nullable<decimal> SalesGeneralToday { get; set; }
        public Nullable<int> SalesInjectableToday { get; set; }
        public Nullable<decimal> LabaidGeneralToDay { get; set; }
        public Nullable<int> LabaidInjectableToDay { get; set; }
        public Nullable<decimal> SalesMay { get; set; }
        public Nullable<int> NoOfMPOMay { get; set; }
        public Nullable<decimal> CommitedSales { get; set; }
        public Nullable<decimal> MTDTransitCollection { get; set; }
        public Nullable<decimal> MTDFinalCollection { get; set; }
        public Nullable<decimal> TodayTransitCollection { get; set; }
        public Nullable<decimal> TodayFinalCollection { get; set; }
        public Nullable<decimal> MTDOtherCollection { get; set; }
        public Nullable<decimal> TodayOtherCollection { get; set; }
    }
}