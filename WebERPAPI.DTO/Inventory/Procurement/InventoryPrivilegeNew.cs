using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryPrivilegeNew
    {
        public int EmployeeID { get; set; }
        public int MainGroupID { get; set; }
        public int CreatedByID { get; set; }
        public Boolean HasPrivilege { get; set; }
    }
}