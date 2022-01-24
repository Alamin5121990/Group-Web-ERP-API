using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialProductList
    {
        public Nullable<int> ID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public string ProductPriorityCode { get; set; }
        public Nullable<decimal> BatchSize { get; set; }
        public string Brand { get; set; }

        public Nullable<decimal> StandardQuantity { get; set; }
        public Nullable<decimal> OutputQuantity { get; set; }

        public Nullable<int> Month1Quantity { get; set; }
        public Nullable<int> Month2Quantity { get; set; }
        public Nullable<int> Month3Quantity { get; set; }
        public Nullable<int> AVGQuantity { get; set; }
    }
}