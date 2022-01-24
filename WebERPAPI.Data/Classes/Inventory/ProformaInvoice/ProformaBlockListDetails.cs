using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaBlockListDetails
    {
        public Nullable<int> BlockListID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string FinishGoodProductName { get; set; }
        public Nullable<decimal> LastYearImportQuantity { get; set; }
        public string DMLInclude { get; set; }
        public Nullable<decimal> CurrentYearApprovedQuantity { get; set; }
        public Nullable<decimal> LastYearFinishGoodQuantity { get; set; }
        public Nullable<decimal> CurrentYearImportQuantity { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<decimal> CurrencyConversionRate { get; set; }
    }
}