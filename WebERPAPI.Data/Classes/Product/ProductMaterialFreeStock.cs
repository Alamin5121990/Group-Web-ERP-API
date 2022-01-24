using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class ProductMaterialStock
    {
        public string ProductCode { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> STDQuantity { get; set; }
        public Nullable<decimal> FreeStock { get; set; }
        public Nullable<decimal> QuarantineQty { get; set; }
        public Nullable<decimal> BookingQty { get; set; }
        public Nullable<decimal> ActualFreeStock { get; set; }
    }
}