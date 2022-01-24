using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class LatestPOAndGRN
    {
        public string RequisitionID { get; set; }

        public string MaterialCode { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }
        public string POID { get; set; }
        public Nullable<decimal> POQuantity { get; set; }

        public Nullable<DateTime> PODate { get; set; }

        public string LCID { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<DateTime> LCDate { get; set; }

        public string GRNID { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
    }
}