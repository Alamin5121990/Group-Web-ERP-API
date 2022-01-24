using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaBlockListApprovedMaterials
    {
        public Nullable<int> ID { get; set; }
        public string BlockListCode { get; set; }
        public Nullable<DateTime> SubmissionDate { get; set; }
        public Nullable<DateTime> FinancialYearStart { get; set; }
        public Nullable<DateTime> FinancialYearEnd { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public Nullable<decimal> CurrentYearApprovedQuantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string ModeOfShipment { get; set; }

        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<decimal> AvailableQuantity { get; set; }
    }
}