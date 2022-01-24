using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MaterialRequisitionQuantity
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<DateTime> RequisitionDate { get; set; }
    }

    public class MaterialPurchaseOrderQuantity
    {
        public string MaterialCode { get; set; }

        public Nullable<decimal> POQuantity { get; set; }
    }
}