using System;

namespace LabaidMIS.Data.Classes.Inventory.Quotation
{
    public class QuotationImportReceiveDetails
    {
        public string QuotationCode { get; set; }
        public string IndentorCode { get; set; }
        public string IndentorName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string UOM { get; set; }

        public string RequisitionCode { get; set; }

        public Nullable<decimal> InvitedQuantity { get; set; }
        public string InvitedModeOfShipment { get; set; }

        public Nullable<decimal> OfferedQuantity { get; set; }
        public string OfferedModeOfShipment { get; set; }
        public Nullable<decimal> OfferedFOBRate { get; set; }
        public Nullable<decimal> OfferedCPTRate { get; set; }
        public Nullable<int> OfferedCurrencyID { get; set; }

        public Nullable<DateTime> UpdatedOn { get; set; }

        public Boolean IsLowestRate { get; set; }
        public Nullable<Boolean> IsIndentorSelected { get; set; }

        public string Remarks { get; set; }
        public string PackagingInfo { get; set; }
    }
}