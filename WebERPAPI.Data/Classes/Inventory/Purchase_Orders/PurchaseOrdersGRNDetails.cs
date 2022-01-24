using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class PurchaseOrdersGRNDetails
    {
        public string GRNID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string Remarks { get; set; }
        public string PackingInfo { get; set; }
        public string Damage { get; set; }
    }
}