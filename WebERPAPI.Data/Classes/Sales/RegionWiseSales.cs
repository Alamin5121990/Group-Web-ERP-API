using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class RegionWiseSalesDetails
    {
        public int ID { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
    }
}