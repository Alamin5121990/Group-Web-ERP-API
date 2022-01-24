using System;

namespace LabaidMIS.Data.Classes.SalesAnalysis
{
    public class ProductAnalysis
    {
        public int BrandId { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<decimal> Vat { get; set; }
    }
}