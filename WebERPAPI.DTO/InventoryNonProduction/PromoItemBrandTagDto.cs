using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class PromoItemBrandTagDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public bool IsTopBrand { get; set; }
    }
}