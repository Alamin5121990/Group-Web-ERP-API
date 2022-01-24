using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyLocal
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Boolean IsReviewed { get; set; }
        public Boolean IsAccountsApproved { get; set; }
        public Boolean IsMarketingGMVerified { get; set; }
        public Boolean IsManagementApproved { get; set; }
        public string Remarks { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> ID { get; set; }
        public string CSCode { get; set; }
        public string RequisitionCode { get; set; }
    }
}