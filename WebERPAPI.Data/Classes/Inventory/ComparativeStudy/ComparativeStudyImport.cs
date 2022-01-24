using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ComparativeStudyImport
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string Reference { get; set; }
        public string UOM { get; set; }
        public string Currency { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> CurrencyConversionRate { get; set; }
        public string DeliveryMode { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }

        public string ModeOfShipment { get; set; }

        public string IndentorCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }

        public string IndentorName { get; set; }
        public Nullable<Boolean> IsReviewed { get; set; }
        public Nullable<Boolean> IsAccountsApproved { get; set; }
        public Nullable<Boolean> IsMarketingGMVerified { get; set; }
        public Nullable<Boolean> IsManagementApproved { get; set; }

        public Nullable<DateTime> ReviewedOn { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public Nullable<DateTime> MarketingGMVerifiedOn { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }

        public string Remarks { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<int> ID { get; set; }
        public string CSCode { get; set; }
        public string RequisitionCode { get; set; }

        public Nullable<Boolean> IsLCComplete { get; set; }
        public Nullable<Boolean> IsGRNComplete { get; set; }
    }

    public class LCIDs
    {
        public string LCID { get; set; }
    }
}