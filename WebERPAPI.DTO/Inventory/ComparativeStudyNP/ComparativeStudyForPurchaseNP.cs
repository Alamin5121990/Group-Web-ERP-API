using System;

namespace WebERPAPI.DTO.Inventory.ComparativeStudyNP
{
    public class ComparativeStudyForPurchaseNP
    {
        public Nullable<int> ID { get; set; }

        public string RequisitionCode { get; set; }
        public string CSCode { get; set; }
        public string ItemNames { get; set; }
        public Nullable<decimal> CSTotal { get; set; }
        public Nullable<decimal> PODoneQuantity { get; set; }
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
        public string MarketingGMVerifiedBy { get; set; }
        public Nullable<DateTime> MarketingGMVerifiedOn { get; set; }
        public string MarketingGMVerifiedRemarks { get; set; }

        public string SupplierCode { get; set; }
        public Nullable<decimal> CarryingCost { get; set; }
        public Nullable<decimal> LabourCost { get; set; }
        public string OtherCostName { get; set; }
        public Nullable<decimal> OtherCost { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string MainGroups { get; set; }
    }
}