using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.User
{
    public class SupplierGlobalSearchResultDto
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierID { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string SupplierType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Nullable<int> SupplierTypeID { get; set; }
        public string SupplierCategory { get; set; }
        public Nullable<int> SupplierCategoryID { get; set; }
        public string Country { get; set; }
        public string Remarks { get; set; }
        public string Webaddress { get; set; }
        public string Fax { get; set; }
    }

    public class MaterialGlobalSearchResultDto
    {
        public string MaterialName { get; set; }
        public string MaterialCode { get; set; }
    }
}