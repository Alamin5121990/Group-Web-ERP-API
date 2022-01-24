using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryTypes
    {
        public Nullable<int> ID { get; set; }

        public string TypeName { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}