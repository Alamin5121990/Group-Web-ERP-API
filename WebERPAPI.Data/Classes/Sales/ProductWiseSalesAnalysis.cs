using System;

namespace LabaidMIS.Data.Classes
{
    public class ProductWiseSalesAnalysis
    {
        public int BrandId { get; set; }
        public int ProductId { get; set; }
        public string BrandName { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }

        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> VAT { get; set; }

        public Nullable<decimal> Qty1 { get; set; }
        public Nullable<decimal> Qty2 { get; set; }
        public Nullable<decimal> Qty3 { get; set; }
        public Nullable<decimal> QtyChange { get; set; }

        public Nullable<decimal> QtyUp1 { get; set; }
        public Nullable<decimal> QtyUp2 { get; set; }
        public Nullable<decimal> QtyUp3 { get; set; }
        public Nullable<decimal> QtyUpChange { get; set; }
        public Nullable<decimal> QtyUp2Change { get; set; }

        public Nullable<decimal> Value1 { get; set; }
        public Nullable<decimal> Value2 { get; set; }
        public Nullable<decimal> Value3 { get; set; }
        public Nullable<decimal> ValueChange { get; set; }

        public Nullable<decimal> ValueUp1 { get; set; }
        public Nullable<decimal> ValueUp2 { get; set; }

        //public Nullable<decimal> ValueUpLastMonth { get; set; }
        public Nullable<decimal> ValueUp3 { get; set; }

        public Nullable<decimal> ValueUpChange { get; set; }

        public Nullable<decimal> Growth1 { get; set; }
        public Nullable<decimal> Growth2 { get; set; }

        //public Nullable<decimal> Rank1 { get; set; }
        //public Nullable<decimal> Rank2 { get; set; }
        //public Nullable<int> RankChange { get; set; }

        public Nullable<decimal> Contribution1 { get; set; }
        public Nullable<decimal> Contribution2 { get; set; }
    }
}