using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ConsumptionRequisitionForItemIssueDto
    {
        public Nullable<int> RequisitionID { get; set; }
        public string RequisitionCode { get; set; }
        public string MainGroupName { get; set; }
        public string ApprovalRemarks { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string Designation { get; set; }
        public string VerifiedById { get; set; }
        public string VerifiedRemark { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public Nullable<decimal> IssedQuantity { get; set; }

        public string ItemNames { get; set; }
        public int IssuePending { get; set; }
    }

    public class ConsumptionRequisitionForApprovalDto
    {
        public Nullable<int> RequisitionID { get; set; }

        public string RequisitionCode { get; set; }
        public string MainGroupName { get; set; }
        public string ApprovalRemarks { get; set; }
        public string ApprovedBy { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<int> NumberOfItem { get; set; }
        public Nullable<Boolean> IsVerified { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifiedRemark { get; set; }

        public string Designation { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string ItemNames { get; set; }
        public int Age { get; set; }
    }
}