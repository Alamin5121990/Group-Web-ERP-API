using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class MaterialFreeStock
    {
        public string MaterialCode { get; set; }
        public Nullable<decimal> FreeStockQuantity { get; set; }
    }
}