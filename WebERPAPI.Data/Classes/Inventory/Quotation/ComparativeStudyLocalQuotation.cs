using System;

namespace LabaidMIS.Data.Classes.Inventory.Quotation
{
    public class ComparativeStudyLocalQuotation
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string UOM { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<decimal> InvitedQuantity { get; set; }
        public Nullable<decimal> OfferedQuantity { get; set; }
        public Nullable<decimal> OfferedRate { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string Remarks { get; set; }
    }
}