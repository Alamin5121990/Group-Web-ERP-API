using System;

namespace WebERPAPI.DTO.Maintenance
{
    public class LatestAPIRequest
    {
        public string Route { get; set; }
        public Nullable<int> TotalRequest { get; set; }
        public Nullable<DateTime> LastRequestedOn { get; set; }
    }
}