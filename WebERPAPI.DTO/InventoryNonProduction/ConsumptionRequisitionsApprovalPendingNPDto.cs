using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ConsumptionRequisitionsApprovalPendingNPDto
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string RequisitionCode { get; set; }
        public string Remarks { get; set; }
        public string MainGroupName { get; set; }

        public Nullable<int> InventoryTypeID { get; set; }
        public string InventoryType { get; set; }
        public string StoreName { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedByID { get; set; }

        public string CreatedBy { get; set; }
        public int NumberOfItem { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCanceled { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string ApprovedBy { get; set; }
        public string UserCode { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string CanceledBy { get; set; }
        public string ReasonToCancel { get; set; }
        public string ApprovalRemarks { get; set; }

        public bool IsVerified { get; set; }
        public string VerifiedById { get; set; }
        public string VerifiedRemark { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifiedBy { get; set; }

        public string ItemNames { get; set; }
    }
}