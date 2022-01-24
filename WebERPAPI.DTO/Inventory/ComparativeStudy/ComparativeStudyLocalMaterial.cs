using System;

namespace WebERPAPI.DTO.Inventory.ComparativeStudy
{
    public class ComparativeStudyLocalMaterial
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }

        public Boolean IsReviewed { get; set; }
        public Boolean IsAccountsApproved { get; set; }
        public Boolean IsMarketingGMVerified { get; set; }
        public Boolean IsAuditDone { get; set; }
        public Boolean IsManagementApproved { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> NumberOfStatusComments { get; set; }
        public string CSCode { get; set; }
        public string RequisitionCode { get; set; }
        public string QuotationCode { get; set; }
        public string StatusComment { get; set; }

        public Nullable<DateTime> ReviewedOn { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public Nullable<DateTime> RecommendedOn { get; set; }
        public Nullable<DateTime> AuditOn { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }

        public Nullable<int> GRNCount { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public string POID { get; set; }
        public Nullable<decimal> TotalReceiveQty { get; set; }
        public Nullable<DateTime> PODate { get; set; }

    }
}