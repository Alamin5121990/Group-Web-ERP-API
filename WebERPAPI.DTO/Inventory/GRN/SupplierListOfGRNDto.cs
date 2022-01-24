using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.Inventory.GRN
{
    public class SupplierListOfGRNDto
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int NumberOfLocalGRN { get; set; } = 0;
        public int NumberOfImportGRN { get; set; } = 0;
        public int NumberOfOtherGRN { get; set; } = 0;
    }
}