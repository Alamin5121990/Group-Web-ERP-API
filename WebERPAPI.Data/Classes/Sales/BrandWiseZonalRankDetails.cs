using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class BrandWiseZonalRankDetails
    {
        public Nullable<int> ID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<long> Rank1 { get; set; }
        public Nullable<long> Rank2 { get; set; }
        public Nullable<long> Rank3 { get; set; }
        public Nullable<long> Rank4 { get; set; }
        public Nullable<long> Rank5 { get; set; }
        public Nullable<long> Rank6 { get; set; }
        public Nullable<decimal> RankAVG { get; set; }
    }
}