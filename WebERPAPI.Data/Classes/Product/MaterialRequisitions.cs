using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class MaterialRequisitions
    {
        public Nullable<DateTime> RequisitionDate { get; set; }
        public string RequisitionID { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public string GRNQuantity { get; set; }
        public string QuotationCode { get; set; }
        public string CSCode { get; set; }
        public string POID { get; set; }
        public string LCID { get; set; }
        public Nullable<DateTime> QuotationDate { get; set; }
        public Nullable<DateTime> CSDate { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public string CreatedBy { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
    }
}