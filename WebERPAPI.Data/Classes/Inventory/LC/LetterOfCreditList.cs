using System;

namespace LabaidMIS.Data.Classes.Inventory.LC
{
    public class LetterOfCreditList
    {
        public Nullable<int> ID { get; set; }
        public string LCCode { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string PINumber { get; set; }
        public string UOM { get; set; }
        public string ModeOfShipment { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Remarks { get; set; }
        public string CurrencyName { get; set; }
        public string IndentorCode { get; set; }
        public string IndentorName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}