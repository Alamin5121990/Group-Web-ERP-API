using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryRequisitionSignatures
    {
        public Nullable<DateTime> CreatedOn { get; set; }

        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByMobile { get; set; }
        public string CreatedDesignation { get; set; }
        public string CreatedDepartment { get; set; }

        public Nullable<DateTime> UpdatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDesignation { get; set; }
        public string UpdatedDepartment { get; set; }

        public Nullable<Boolean> IsVerified { get; set; }
        public string VerifiedByID { get; set; }
        public string VerifyRemarks { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifiedBy { get; set; }
        public string VerifiedDesignation { get; set; }
        public string VerifiedDepartment { get; set; }

        public Nullable<Boolean> IsApproved { get; set; }
        public string ApprovedById { get; set; }
        public string ApprovalRemarks { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedDesignation { get; set; }
        public string ApprovedDepartment { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public string CanceledByID { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }
        public string CanceledBy { get; set; }

        public Nullable<Boolean> IsClosed { get; set; }
        public string ClosedById { get; set; }
        public Nullable<DateTime> ClosedOn { get; set; }
        public string ClosedBy { get; set; }
    }
}