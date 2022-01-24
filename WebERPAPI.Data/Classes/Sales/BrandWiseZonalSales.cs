using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class BrandWiseZonalSales
    {
        public Nullable<int> ID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string EmployeeName { get; set; }

        public Nullable<decimal> STPercent { get; set; }

        public Nullable<decimal> CurrentMonthSales { get; set; }
        public Nullable<decimal> BrandTarget1 { get; set; }
        public Nullable<decimal> PreviousMonth1Sales { get; set; }
        public Nullable<decimal> BrandTarget2 { get; set; }
        public Nullable<decimal> Month2TotalSales { get; set; }
        public Nullable<decimal> PreviousMonth2Sales { get; set; }
        public Nullable<decimal> BrandTarget3 { get; set; }
        public Nullable<decimal> Month3TotalSales { get; set; }
        public Nullable<decimal> PreviousMonth3Sales { get; set; }
        public Nullable<decimal> BrandTarget4 { get; set; }
        public Nullable<decimal> Month4TotalSales { get; set; }
        public Nullable<decimal> PreviousMonth4Sales { get; set; }
        public Nullable<decimal> BrandTarget5 { get; set; }
        public Nullable<decimal> Month5TotalSales { get; set; }
        public Nullable<decimal> PreviousMonth5Sales { get; set; }
        public Nullable<decimal> BrandTarget6 { get; set; }
        public Nullable<decimal> Month6TotalSales { get; set; }

        public Nullable<decimal> RankAVG { get; set; }
        public Nullable<decimal> OverallAVG { get; set; }
    }

    public class BrandWiseMPOSales
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> BrandID { get; set; }

        public Nullable<decimal> CurrentMonthSales { get; set; }
        public Nullable<decimal> LastMonthSales { get; set; }
    }
}