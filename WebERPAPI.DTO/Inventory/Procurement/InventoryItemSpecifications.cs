using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryItemSpecifications
    {
        public Nullable<int> ID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }

        public Nullable<int> SpecificationID { get; set; }
        public string SpecificationValue { get; set; }
        public string SpecificationName { get; set; }
        public Nullable<Boolean> ShowInName { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}