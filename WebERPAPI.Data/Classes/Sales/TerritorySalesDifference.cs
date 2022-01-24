using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class TerritorySalesDifference
    {
        public string ZoneName { get; set; }
        public string RegionName { get; set; }
        public string AreaName { get; set; }
        public string TerritoryCode { get; set; }
        public string TerritoryName { get; set; }

        public Nullable<decimal> MISTotal { get; set; }
        public Nullable<decimal> SDTotal { get; set; }
        public Nullable<decimal> ValueDifference { get; set; }
        public Nullable<decimal> LastMonthMISTotal { get; set; }
        public Nullable<decimal> LastMonthSDTotal { get; set; }
        public Nullable<decimal> LastMonthValueDifference { get; set; }
    }
}