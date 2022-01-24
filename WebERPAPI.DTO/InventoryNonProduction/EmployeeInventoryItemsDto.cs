using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class EmployeeInventoryItemsDto
    {
        public Nullable<int> ID { get; set; }

        public string MainGroupName { get; set; }
        public string SubGroupName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string Description { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public Nullable<int> VersionID { get; set; }
        public Nullable<int> VersionNo { get; set; }
        public string VersionStateName { get; set; }

        public Nullable<int> ItemUsageTypeID { get; set; }
        public string ItemUsageType { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}