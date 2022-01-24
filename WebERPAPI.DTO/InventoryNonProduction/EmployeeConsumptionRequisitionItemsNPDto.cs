using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class EmployeeConsumptionRequisitionItemsNPDto
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string RequisitionCode { get; set; }
        public string Remarks { get; set; }
        public string MainGroupName { get; set; }

        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public string ItemUsageType { get; set; }
    }
}