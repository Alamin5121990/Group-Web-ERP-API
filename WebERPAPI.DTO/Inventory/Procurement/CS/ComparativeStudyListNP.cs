using System;

namespace WebERPAPI.DTO.Inventory.Procurement.CS
{
    public class ComparativeStudyListNP
    {
        public Nullable<int> ID { get; set; }
        public string RequisitionCode { get; set; }
        public string CSCode { get; set; }
        public Nullable<decimal> CSTotal { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public string ReviewedBy { get; set; }
        public Nullable<DateTime> ReviewedOn { get; set; }
        public string ReviewRemarks { get; set; }
        public string AccountsApproveBy { get; set; }

        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public string AccountsApprovalRemarks { get; set; }
        public string ManagementApproveBy { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public string ManagementApprovalRemarks { get; set; }

        public string RecommendedBy { get; set; }
        public Nullable<DateTime> RecommendedOn { get; set; }
        public string RecommendationRemarks { get; set; }

        public string CheckedBy { get; set; }
        public Nullable<DateTime> CheckedOn { get; set; }
        public string CheckedRemarks { get; set; }

        public Nullable<bool> IsCanceled { get; set; }
        public string CanceledBy { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }

        public string AuditBy { get; set; }
        public Nullable<DateTime> AuditOn { get; set; }
        public string AuditRemarks { get; set; }
        public string AuditById { get; set; }

        public string MainGroups { get; set; }
        public string SubGroups { get; set; }
        public string ItemNames { get; set; }

        public string CreatedByDesignation { get; set; }
        public string CreatedByDepartment { get; set; }
        public string ReviewedByDesignation { get; set; }
        public string ReviewedByDepartment { get; set; }
        public string AccountsApproveByDesignation { get; set; }
        public string AccountsApproveByDepartment { get; set; }
        public string RecommendedByDesignation { get; set; }
        public string RecommendedByDepartment { get; set; }
        public string AuditByDesignation { get; set; }
        public string AuditByDepartment { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Subgroup { get; set; }
        public string MainGroup { get; set; }

        public Nullable<DateTime> PODate { get; set; }
        public string POCodes { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string GRNCodes { get; set; }

    }
}