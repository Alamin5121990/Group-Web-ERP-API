using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyReviewedMaterials
    {
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public string CSCode { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string ReviewedBy { get; set; }
        public Nullable<DateTime> ReviewedOn { get; set; }
        public string ReviewRemarks { get; set; }

        public string AccountsApproveBy { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public string AccountsApprovalRemarks { get; set; }

        public string MarketingGMVerifiedBy { get; set; }
        public Nullable<DateTime> MarketingGMVerifiedOn { get; set; }
        public string MarketingGMVerifiedRemarks { get; set; }

        public string ManagementApproveBy { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public string ManagementApprovalRemarks { get; set; }
    }
}