using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialPurchaseEvents
    {
        public string MaterialCode { get; set; }
        public string Code { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string Remarks { get; set; }
        public string Step { get; set; }
    }
}