using System;

namespace WebERPAPI.DTO.Inventory.Requisitions
{
    public class InventoryStores
    {
        public Nullable<int> TypeID { get; set; }

        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}