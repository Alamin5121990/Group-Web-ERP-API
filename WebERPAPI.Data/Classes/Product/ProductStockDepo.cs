using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class ProductStockDepo
    {
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string LocationType { get; set; }
        public bool IsCurrent { get; set; }
        public Nullable<System.DateTime> ClosingDate { get; set; }
    }
}