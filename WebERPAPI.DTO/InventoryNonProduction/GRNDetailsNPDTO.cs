using System;
using System.Collections.Generic;
using WebERPAPI.DTO.Inventory.Procurement;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class GRNDetailsNPDTO
    {
        public Nullable<int> OrderNumber { get; set; }

        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string SerialNumber { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> ItemTotalGRNQuantity { get; set; }
        public Nullable<decimal> PassedQuantity { get; set; }
        public Nullable<decimal> RejectedQuantity { get; set; }

        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public List<ItemSpecification> Specifications { get; set; }
    }
}