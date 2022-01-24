using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class ProductMaterialPendingPOOrLCQuantity
    {
        public string MaterialCode { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
    }
}