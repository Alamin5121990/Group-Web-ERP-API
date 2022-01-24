using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialRetestQuantity
    {
        public string Materialcode { get; set; }
        public Nullable<decimal> ReTestQty { get; set; }
    }

    public class MaterialRetestQuantityDetails
    {
        public string Materialcode { get; set; }

        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string LabRefID { get; set; }
        public string GRNID { get; set; }
        public Nullable<decimal> ReTestQty { get; set; }
    }
}