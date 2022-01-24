using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class VacantLocation
    {
        public string LocationType { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public string TerritoryCode { get; set; }
        public string TerritoryName { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
    }
}