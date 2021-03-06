using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyNewInternalApprovalMaterialDetails
    {
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string CSCode { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public string VersionNo { get; set; }
        public string QuotationCode { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<Boolean> IsReviewed { get; set; }
        public Nullable<Boolean> IsAccountsApproved { get; set; }
        public Nullable<Boolean> IsMarketingGMVerified { get; set; }
        public Nullable<Boolean> IsManagementApproved { get; set; }
    }
}