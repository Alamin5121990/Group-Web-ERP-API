using System;
using System.Collections.Generic;
using WebERPAPI.DTO.Inventory.Procurement;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class PurchaseOrderDetailsNP
    {
        public string CSCode { get; set; }

        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string RequisitionCode { get; set; }
        public int RequisitionID { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> PODoneQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }

        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> VATPercent { get; set; }
        public Nullable<int> RequisitionItemID { get; set; }
        public List<ItemSpecification> Specifications { get; set; }
    }
}