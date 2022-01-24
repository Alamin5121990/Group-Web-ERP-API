using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ProformaInvitations
    {
        public Nullable<int> PIID { get; set; }
        public string PICode { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string ModeOfShipment { get; set; }
        public string IndentorCode { get; set; }
        public string IndentorName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }
        public string MaterialGrade { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string Remarks { get; set; }
        public string CSCode { get; set; }
        public string DeliveryMode { get; set; }
        public string CurrencyName { get; set; }

        public string FinishGoodBrands { get; set; }
        public string BlockStatus { get; set; }
        public string ReasonToAmendment { get; set; }
    }
}