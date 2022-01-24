using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class MaterialShortageReport
    {
        public string ProductCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> STDQuantity { get; set; }
        public Nullable<decimal> BatchRequiredQuantity { get; set; }
        public Nullable<decimal> FreeStock { get; set; }
        public Nullable<decimal> ShortageQuantity { get; set; }
    }
}