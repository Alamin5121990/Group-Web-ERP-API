using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory.Quotation
{
    public class ComparativeStudyImportReport
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string Reference { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> CurrencyConversionRate { get; set; }
        public string DeliveryMode { get; set; }

        public string RequisitionCode { get; set; }

        public string IndentorCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string IndentorName { get; set; }

        public string Remarks { get; set; }

        public List<ComparativeStudyImportQuotation> QuotationDetails { get; set; }

        public List<LCIDs> LCS { get; set; }
    }
}