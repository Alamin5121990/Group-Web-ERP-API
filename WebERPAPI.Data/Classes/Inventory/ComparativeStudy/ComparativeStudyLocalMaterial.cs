using LabaidMIS.Data.Classes.Inventory.Material;
using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory.ComparativeStudy
{
    public class ComparativeStudyLocalMaterial
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
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
        public string QuotationCode { get; set; }

        public Nullable<DateTime> ReviewedOn { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public Nullable<DateTime> MarketingGMVerifiedOn { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }

        public Nullable<Boolean> IsPOComplete { get; set; }
        public Nullable<Boolean> IsGRNComplete { get; set; }

        public List<LatestPOAndGRN> POList { get; set; }
    }
}