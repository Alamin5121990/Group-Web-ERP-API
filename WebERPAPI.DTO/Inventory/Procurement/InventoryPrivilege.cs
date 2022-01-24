using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryPrivilege
    {
        public int MainGroupID { get; set; }
        public string MainGroupName { get; set; }
        public Boolean HasPrivilege { get; set; }
    }
}