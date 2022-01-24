using System;

namespace WebERPAPI.DTO.Supplier
{
    public class SupplierListWithPOAndBillTotalDto
    {
        public string SupplierID { get; set; }

        public string SupplierName { get; set; }
        public Nullable<int> NumberOfPO { get; set; }
        public Nullable<int> NumberOfBill { get; set; }
        public string SupplierCategoryName { get; set; }
        public string SupplierTypeName { get; set; }

    }
}