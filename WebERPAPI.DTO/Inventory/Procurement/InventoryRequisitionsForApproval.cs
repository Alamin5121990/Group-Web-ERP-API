using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryRequisitionsForApproval
    {
        public string MainGroupName { get; set; }

        public string StoreName { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public string RequisitionRemarks { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
    }
}