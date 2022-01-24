using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class PurchaseOrderMaterials
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string GRNID { get; set; }
        public string ChallanNo { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string VatChallanNo { get; set; }
        public Nullable<DateTime> VatChallanDate { get; set; }
        public Nullable<decimal> ChallanAmount { get; set; }
    }
}