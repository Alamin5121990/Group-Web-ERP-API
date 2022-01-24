using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyReport
    {
        public Nullable<int> ID { get; set; }
        public string CSCode { get; set; }
        public Nullable<decimal> CSTotal { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string Department { get; set; }
        public string PreparedByDesignation { get; set; }
        public string PreparedByDepartment { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedByDepartment { get; set; }
        public Nullable<DateTime> ReviewedOn { get; set; }
        public string ReviewRemarks { get; set; }
        public string ReviewedByDesignation { get; set; }
        public string AccountsApproveBy { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public string AccountsApprovalRemarks { get; set; }
        public string AccountsDesignation { get; set; }
        public string ManagementApproveBy { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public string ManagementApprovalRemarks { get; set; }

        // RECOMMENDATION
        public string RecommendedBy { get; set; }

        public Nullable<DateTime> RecommendedOn { get; set; }
        public string RecommendationRemarks { get; set; }
        public string RecommendationDesignation { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCanceled { get; set; }
        public string CanceledBy { get; set; }

        public Nullable<Boolean> IsAuditDone { get; set; }
        public Nullable<DateTime> AuditOn { get; set; }
        public string AuditById { get; set; }
        public string AuditBy { get; set; }
        public string AuditDesignation { get; set; }
        public string AuditDepartment { get; set; }

        public string RollBackRemark { get; set; }
        public string RollBackByID { get; set; }
        public string RollbackByName { get; set; }
    }
}