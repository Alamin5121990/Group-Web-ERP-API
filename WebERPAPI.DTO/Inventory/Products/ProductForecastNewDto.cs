using System;

namespace WebERPAPI.DTO.Inventory.Products
{
    public class ProductForecastNewDto
    {
        public int ProductID { get; set; }
        public string DateFrom { get; set; }
        public string Remarks { get; set; }

        public Nullable<int> Month1Quantity { get; set; }
        public Nullable<int> Month2Quantity { get; set; }
        public Nullable<int> Month3Quantity { get; set; }
        public Nullable<int> Month4Quantity { get; set; }
        public Nullable<int> Month5Quantity { get; set; }
        public Nullable<int> Month6Quantity { get; set; }
        public Nullable<int> Month7Quantity { get; set; }
        public Nullable<int> Month8Quantity { get; set; }
        public Nullable<int> Month9Quantity { get; set; }
        public Nullable<int> Month10Quantity { get; set; }
        public Nullable<int> Month11Quantity { get; set; }
        public Nullable<int> Month12Quantity { get; set; }

        public int CreatedByID { get; set; }
    }
}