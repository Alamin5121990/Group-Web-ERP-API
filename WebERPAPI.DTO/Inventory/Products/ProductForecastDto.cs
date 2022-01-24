using System;

namespace WebERPAPI.DTO.Inventory.Products
{
    public class ProductForecastReportDto
    {
        public Nullable<int> ProductID { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string UOM { get; set; }
        public string SPS { get; set; }
        public string Remarks { get; set; }

        public Nullable<int> ProductTypeID { get; set; }
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
    }

    public class ProductForecastDto
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }

        public Nullable<int> ProductTypeID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Remarks { get; set; }
    }
}