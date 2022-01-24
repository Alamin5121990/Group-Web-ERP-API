using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ProductForecastNew
    {
        public int ProductID { get; set; }
        public string Data { get; set; }
        public string EmployeeID { get; set; }
    }

    public class ProductForecastDetails
    {
        public Nullable<int> CommercialQuantity { get; set; }
        public string Month { get; set; }
        public string SampleQuantity { get; set; }
    }
}