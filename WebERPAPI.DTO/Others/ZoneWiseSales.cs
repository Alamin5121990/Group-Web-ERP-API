using System;

namespace WebERPAPI.DTO
{
    public class ZoneWiseSales
    {
        public int ID { get; set; }
        public string ZoneID { get; set; }
        public string ZoneName { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
    }

    public class ZoneWiseSalesReport
    {
        public string ZoneID { get; set; }
        public string ZoneName { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> SoldValue { get; set; }
        public Nullable<int> Rank { get; set; }
    }
}