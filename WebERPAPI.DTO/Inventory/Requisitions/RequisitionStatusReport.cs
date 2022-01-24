using System;

namespace WebERPAPI.DTO.Inventory.Requisitions
{
    public class RequisitionStatusReport
    {
        public string RequisitionID { get; set; }

        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string VersionNo { get; set; }

        public Nullable<decimal> Quantity { get; set; }
        public string UOM { get; set; }

        public string Source { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }

        public string QuotationCode { get; set; }
        public Nullable<DateTime> QuotationDate { get; set; }

        public string CSCode { get; set; }
        public Nullable<DateTime> CSDate { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> CSRate { get; set; }

        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POQuantity { get; set; }

        public string LCID { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }

        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public Nullable<decimal> TotalCSQuantity { get; set; }
        public Nullable<decimal> TotalPOQuantity { get; set; }
        public Nullable<decimal> TotalLCQuantity { get; set; }
        public Nullable<decimal> TotalGRNQuantity { get; set; }

        public Nullable<decimal> RequisitionPendingQuantity { get; set; }

        public Nullable<Boolean> IsRequisitionClosed { get; set; }
        public string CSStatus { get; set; }
        public string LCStatus { get; set; }
        public string POStatus { get; set; }
        public string GRNStatus { get; set; }
    }
}