using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class ProductLastThreeMonthSales
    {
        public Nullable<int> ProductID { get; set; }

        public string ProductCode { get; set; }
        public Nullable<int> Month1Quantity { get; set; }
        public Nullable<int> Month2Quantity { get; set; }
        public Nullable<int> Month3Quantity { get; set; }
        public Nullable<decimal> AVGQuantity { get; set; }
    }
}