using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class ProductMapping
    {
        public Nullable<int> BrandId { get; set; }
        public string BrandName { get; set; }
        public string GenericName { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string UOM { get; set; }
        public string SalesCode { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> MRP { get; set; }
        public string SampleId { get; set; }
        public string ProductType { get; set; }
    }
}