using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaInvoiceReceivedMaterials
    {
        public Nullable<int> PIID { get; set; }
        public string PICode { get; set; }
        public string PINumber { get; set; }
        public string HSCode { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string ModeOfShipment { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public Nullable<decimal> CurrencyConversionRate { get; set; }
        public string CurrencyName { get; set; }
        public string IndentorCode { get; set; }
        public string IndentorName { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }

        public Nullable<decimal> BlockListQuantity { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Boolean isBlockListQualify { get; set; }
    }
}