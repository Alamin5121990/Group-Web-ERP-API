using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaEntryDetails
    {
        public Nullable<int> BlockListID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public string UOM { get; set; }
        public Nullable<int> Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public decimal CurrencyConversionRate { get; set; }
        public string CountryName { get; set; }
        public string ModeOfShipment { get; set; }
        public string FinishGoodProductName { get; set; }

        public Nullable<int> LastYearFinishGoodQuantity { get; set; }
        public Nullable<int> LastYearImportQuantity { get; set; }
        public Nullable<int> CurrentYearImportQuantity { get; set; }
        public string DMLInclude { get; set; }

        public Nullable<int> CurrentYearApprovedQuantity { get; set; }
        public string Remarks { get; set; }

        public string CreatedByID { get; set; }
    }
}