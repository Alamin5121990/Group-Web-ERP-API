using System;

namespace WebERPAPI.DTO.Inventory.Products
{
    public class ProductForecastQuantityDto
    {
        public Nullable<int> ProductID { get; set; }

        public string SPS { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> CommercialQuantity { get; set; }
        public Nullable<int> SampleQuantity { get; set; }

        public Nullable<int> QuantityInTabletUnit { get; set; }
        public Nullable<int> SampleCommercialQuantity { get; set; }
    }
}