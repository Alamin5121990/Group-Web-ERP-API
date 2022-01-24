using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyMaterialSupplier
    {
        public string MaterialCode { get; set; }
        public string RequisitionCode { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}