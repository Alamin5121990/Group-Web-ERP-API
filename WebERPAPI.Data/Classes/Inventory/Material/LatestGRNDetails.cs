using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class LatestGRNDetails
    {
        public string GRNID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }

        //public string SupplierCode { get; set; }
        //public string SupplierName { get; set; }

        public string POID { get; set; }
        public string LCID { get; set; }
    }
}