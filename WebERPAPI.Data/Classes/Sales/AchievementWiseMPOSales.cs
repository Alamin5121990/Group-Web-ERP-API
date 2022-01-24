using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class AchievementWiseMPOSales
    {
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public Nullable<int> MPOID { get; set; }
        public string TerritoryCode { get; set; }
        public string TerritoryName { get; set; }
        public Nullable<decimal> CurrentMonthSales { get; set; }
        public Nullable<decimal> CurrentMonthAchievement { get; set; }
        public Nullable<decimal> LastMonthSales { get; set; }
        public Nullable<decimal> LastMonthAchievement { get; set; }
    }
}