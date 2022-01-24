using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory.Products
{
    public class ProductListReport
    {
        public Nullable<int> GenericID { get; set; }
        public string GenericName { get; set; }
        public Nullable<int> BrandID { get; set; }
        public string BrandName { get; set; }

        public List<ProductListDto> ProductList { get; set; }
    }
}