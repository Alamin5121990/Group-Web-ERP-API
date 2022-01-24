using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class MaterialProduct
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<int> ScheduleQuantity { get; set; }

        public Nullable<int> NoofBatchInProcess { get; set; }
        public Nullable<decimal> BatchOutputInProcess { get; set; }
        public Nullable<int> NoofBatchInRelease { get; set; }
        public Nullable<decimal> BatchOutputInRelease { get; set; }
    }

    public class MaterialInBatchProductList
    {
        public Nullable<int> ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> StandardQuantity { get; set; }
    }
}