using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryItemVersionNew
    {
        public int ItemID { get; set; }
        public int VersionStateID { get; set; }
        public string Data { get; set; }
        public string EmployeeID { get; set; }
    }

    public class InventoryItemVersionSpecificationNew
    {
        public int SpecificationID { get; set; }
        public string SpecificationValue { get; set; }
        public string UOM { get; set; }
        public Nullable<Boolean> ShowInName { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}