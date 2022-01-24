using System;

namespace WebERPAPI.DTO
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public class BrandDailySales
    {
        public int BrandID { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }

    public class BrandAndCurrentSales
    {
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}