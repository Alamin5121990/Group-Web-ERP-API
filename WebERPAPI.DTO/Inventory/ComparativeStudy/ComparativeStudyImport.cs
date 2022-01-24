using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyImportDTO
    {
        public Nullable<int> GRNCount { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public Nullable<decimal> TotalReceiveQty { get; set; }
        public string MaterialCode { get; set; }

        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string UOM { get; set; }
        public string Reference { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> CurrencyConversionRate { get; set; }
        public string DeliveryMode { get; set; }
        public string ModeOfShipment { get; set; }
        public string IndentorCode { get; set; }

        public string IndentorID { get; set; }
        public string SupplierCode { get; set; }
        public string IndentorName { get; set; }
        public string ManufacturerCode { get; set; }

        public Nullable<Boolean> IsReviewed { get; set; }
        public Nullable<Boolean> IsAccountsApproved { get; set; }
        public Nullable<Boolean> IsRecommended { get; set; }
        public Nullable<Boolean> IsAuditDone { get; set; }
        public Nullable<Boolean> IsManagementApproved { get; set; }

        public string Remarks { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<int> ID { get; set; }
        public string CSCode { get; set; }
        public string RequisitionCode { get; set; }

        public Nullable<DateTime> ReviewedOn { get; set; }
        public Nullable<DateTime> AccountsApprovedOn { get; set; }
        public Nullable<DateTime> RecommendedOn { get; set; }
        public Nullable<DateTime> AuditOn { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public Nullable<int> CurrencyID { get; set; }

        public string CurrencyName { get; set; }
        public string POCodes { get; set; }
        public string LCCodes { get; set; }
        public Nullable<int> NumberOfStatusComments { get; set; }
        public string StatusComment { get; set; }
    }

    public class LCIDs
    {
        public string LCID { get; set; }
    }
}