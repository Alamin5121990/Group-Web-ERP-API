using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialGRNRequisition
    {
        public string GRNID { get; set; }

        public Nullable<DateTime> GRNDate { get; set; }
        public string POID { get; set; }
        public string RequisitionID { get; set; }
        public string LCID { get; set; }
        public Nullable<decimal> Qty { get; set; }

        public Nullable<decimal> ReceiveQty { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public string BatchNo { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> Rate { get; set; }

        public string PackingInfo { get; set; }
    }
}