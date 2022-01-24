using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ProductsDto
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }

        public Nullable<int> BrandId { get; set; }
        public string ProductCode { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> TPperPcs { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<int> PID { get; set; }
    }
}