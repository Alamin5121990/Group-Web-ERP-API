using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class AllAreaWiseZoneRegionTerritoryDto
    {
        public Nullable<int> OrderBy { get; set; }

        public string LocationType { get; set; }
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string Mobile { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public string ZoneID { get; set; }

        public string ZoneName { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string AreaID { get; set; }
        public string AreaName { get; set; }

        public decimal AllocateQty { get; set; } = 0;
    }
}