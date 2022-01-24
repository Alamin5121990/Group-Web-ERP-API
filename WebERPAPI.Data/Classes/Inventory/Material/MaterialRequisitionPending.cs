using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialRequisitionPending
    {
        public string RequisitionID { get; set; }

        public string MaterialCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }
    }
}