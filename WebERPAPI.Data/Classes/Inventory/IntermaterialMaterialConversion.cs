using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class IntermaterialMaterialConversion
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> ProductionLocationID { get; set; }
        public string LocationName { get; set; }
        public string MaterialCodeFrom { get; set; }
        public string MaterialNameFrom { get; set; }
        public string MaterialCodeTo { get; set; }
        public string MaterialNameTo { get; set; }
    }
}