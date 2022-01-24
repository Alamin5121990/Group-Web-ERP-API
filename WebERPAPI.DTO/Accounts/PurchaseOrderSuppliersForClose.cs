using System;

namespace WebERPAPI.DTO.Accounts
{
    public class PurchaseOrderSuppliersForClose
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> TotalPO { get; set; }
        public Nullable<decimal> TotalPOAmount { get; set; }
    }
}