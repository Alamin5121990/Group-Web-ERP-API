using System.Collections.Generic;
using WebERPAPI.DTO.Inventory.Requisitions;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryTypesAndStores
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }

        public List<InventoryStores> TypesList { get; set; }
    }
}