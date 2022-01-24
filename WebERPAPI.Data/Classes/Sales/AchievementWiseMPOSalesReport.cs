using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class AchievementWiseMPOSalesReport
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
        public Nullable<decimal> Month1Sales { get; set; }
        public Nullable<decimal> Month1Achievement { get; set; }
        public Nullable<decimal> Month2Sales { get; set; }
        public Nullable<decimal> Month2Achievement { get; set; }
        public Nullable<decimal> Month3Sales { get; set; }
        public Nullable<decimal> Month3Achievement { get; set; }
        public Nullable<decimal> Month4Sales { get; set; }
        public Nullable<decimal> Month4Achievement { get; set; }
        public Nullable<decimal> Month5Sales { get; set; }
        public Nullable<decimal> Month5Achievement { get; set; }
        public Nullable<decimal> Month6Sales { get; set; }
        public Nullable<decimal> Month6Achievement { get; set; }
    }
}