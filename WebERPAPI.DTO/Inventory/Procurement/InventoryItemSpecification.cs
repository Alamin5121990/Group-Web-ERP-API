using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryItemSpecification
    {
        public int ID { get; set; }
        public string SpecificationName { get; set; }
        public string UOM { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}