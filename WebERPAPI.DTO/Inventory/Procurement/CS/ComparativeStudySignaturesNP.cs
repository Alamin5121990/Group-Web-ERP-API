using System;

namespace WebERPAPI.DTO.Inventory.Procurement.CS
{
    public class ComparativeStudySignaturesNP
    {
        public Nullable<DateTime> CreatedOn { get; set; }

        public string CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public string Remarks { get; set; }
        public string CreatedDesignation { get; set; }
        public string CreatedDepartment { get; set; }

        public Nullable<DateTime> UpdatedOn { get; set; }
        public string UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }

        public Nullable<Boolean> IsChecked { get; set; }
        public string CheckedByID { get; set; }
        public string CheckedRemarks { get; set; }
        public Nullable<DateTime> CheckedOn { get; set; }
        public string CheckedBy { get; set; }
        public string CheckedDesignation { get; set; }
        public string CheckedDepartment { get; set; }

        public Nullable<Boolean> IsReviewed { get; set; }
        public string ReviewedByID { get; set; }
        public string ReviewRemarks { get; set; }
        public Nullable<DateTime> ReviewedOn { get; set; }
        public string ReviewedBy { get; set; }
        public string ReviewedDesignation { get; set; }
        public string ReviewedDepartment { get; set; }

        public Nullable<Boolean> IsAccountsApproved { get; set; }
        public string AccountsApprovedByID { get; set; }
        public string AccountsApprovalRemarks { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public string AccountsApprovedBy { get; set; }
        public string AccountsApprovedDesignation { get; set; }
        public string AccountsApprovedDepartment { get; set; }

        public Nullable<Boolean> IsRecommended { get; set; }
        public Nullable<DateTime> RecommendedOn { get; set; }
        public string RecommendedBy { get; set; }
        public string RecommendedByID { get; set; }
        public string RecommendationRemarks { get; set; }
        public string RecommendationDesignation { get; set; }
        public string RecommendationDepartment { get; set; }

        public Nullable<Boolean> IsManagementApproved { get; set; }
        public string ManagementApprovalRemarks { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public string ManagementApprovedBy { get; set; }
        public string ManagementApprovedDesignation { get; set; }
        public string ManagementApprovedDepartment { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public string CanceledByID { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }
        public string CanceledBy { get; set; }

        public string AuditBy { get; set; }
        public Nullable<DateTime> AuditOn { get; set; }
        public Nullable<Boolean> IsAuditDone { get; set; }
        public string AuditRemarks { get; set; }
        public string AuditDesignation { get; set; }
        public string AuditDepartment { get; set; }
    }
}