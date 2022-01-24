using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class InventoryItemIssuedDto : BaseEntityDTO
    {
        public string IssueCode { get; set; }
        public string IssueToID { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public string MainGroupName { get; set; }
        public string IssuedFrom { get; set; }
        public string IssueTo { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public string CanceledBy { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }

        public string IssueStatus { get; set; }
        public string IssuedToDesignation { get; set; }
        public string IssuedToDepartment { get; set; }
        public string ItemNames { get; set; }
        public string Location { get; set; }
        public string CreatedDepartment { get; set; }
        public string CreatedDesignation { get; set; }
        public string CreatedLocation { get; set; }
    }
}