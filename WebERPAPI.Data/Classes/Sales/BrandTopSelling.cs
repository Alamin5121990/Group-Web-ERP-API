using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class BrandTopSelling
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public Nullable<decimal> CurrentMonthSales { get; set; }
        public Nullable<decimal> LastMonthSales { get; set; }
    }
}