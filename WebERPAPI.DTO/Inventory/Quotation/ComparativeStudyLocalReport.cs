using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory.Quotation
{
    public class ComparativeStudyLocalReport
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string RequisitionCode { get; set; }

        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerName { get; set; }

        public List<ComparativeStudyLocalQuotation> QuotationDetails { get; set; }
    }
}