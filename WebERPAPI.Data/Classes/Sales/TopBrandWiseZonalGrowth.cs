using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Sales
{
    public class TopBrandWiseZonalGrowth
    {
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }
        public Nullable<decimal> CurrentMonthSales { get; set; }

        public List<BrandWiseZonalSales> ZonalDetails { get; set; }
    }

    public class TopBrandWiseMPOPerformance
    {
        public Nullable<int> RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }

        public Nullable<int> ParentID { get; set; }
        public string ParentLocationCode { get; set; }
        public string ParentLocationName { get; set; }

        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public Nullable<decimal> STPercent { get; set; }
        public List<BrandWiseMPOSales> BrandDetails { get; set; }
    }
}