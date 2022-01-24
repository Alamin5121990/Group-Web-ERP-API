using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class GRNDetailsByRequisition
    {
        public string POID { get; set; }
        public string LCID { get; set; }
        public string GRNID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> ReceiveQuantity { get; set; }
        public string BatchNo { get; set; }
        public Nullable<DateTime> MFGDate { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
        public string PackingInfo { get; set; }
        public string Damage { get; set; }
        public string Remarks { get; set; }
    }
}