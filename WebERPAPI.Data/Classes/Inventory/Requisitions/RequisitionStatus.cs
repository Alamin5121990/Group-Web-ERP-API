using System;

namespace LabaidMIS.Data.Classes.Inventory.Requisitions
{
    public class RequisitionStatus
    {
        public string RequisitionID { get; set; }

        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string MaterialGrade { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string Source { get; set; }

        public string UOM { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }
        public string QuotationCode { get; set; }
        public Nullable<DateTime> QuotationDate { get; set; }
        public string CSCode { get; set; }

        public Nullable<DateTime> CSDate { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public string LCID { get; set; }

        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public string POID { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
    }
}