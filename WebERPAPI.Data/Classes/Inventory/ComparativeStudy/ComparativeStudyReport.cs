using System;

namespace LabaidMIS.Data.Classes.Inventory
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
        public string ReviewedBy { get; set; }
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
        public string MarketingGMVerifiedBy { get; set; }
        public Nullable<DateTime> MarketingGMVerifiedOn { get; set; }
        public string MarketingGMVerifiedRemarks { get; set; }
        public string MarketingDesignation { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCanceled { get; set; }
        public string CanceledBy { get; set; }
    }
}