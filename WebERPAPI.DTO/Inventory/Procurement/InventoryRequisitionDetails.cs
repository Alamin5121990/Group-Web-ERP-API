using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryRequisitionDetails
    {
        public int ID { get; set; }

        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<int> VersionNo { get; set; }

        public string Purpose { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string UOM { get; set; }

        public Nullable<int> VersionID { get; set; }
        public Nullable<int> SubGroupId { get; set; }
        public string SubGroupName { get; set; }
        public Nullable<int> MainGroupId { get; set; }
        public string MainGroupName { get; set; }
        public List<ItemSpecification> Specifications { get; set; }
        public int TotalSupplier { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Price { get; set; }
    }
}