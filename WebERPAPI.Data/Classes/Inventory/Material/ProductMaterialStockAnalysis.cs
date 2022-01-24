using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class ProductMaterialStockAnalysis
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
    }
}