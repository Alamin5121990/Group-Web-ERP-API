using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ProductForecastEntry
    {
        public int ProductID { get; set; }
        public string EmployeeID { get; set; }
        public string Data { get; set; }
    }

    public class ProductForecastList
    {
        public DateTime ForecastDate { get; set; }
        public int CommercialQuantity { get; set; }
        public int SampleQuantity { get; set; }
    }
}