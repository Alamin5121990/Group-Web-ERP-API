using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class LCDetails
    {
        public string LCID { get; set; }
        public string ProjectCD { get; set; }
        public string BlockListRefNo { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string CountryOfOrigin { get; set; }
        public string ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string ShipMode { get; set; }
        public Nullable<DateTime> ShipmentDate { get; set; }
        public Nullable<DateTime> ArrivalDate { get; set; }
        public Nullable<decimal> RTConvRate { get; set; }
    }
}