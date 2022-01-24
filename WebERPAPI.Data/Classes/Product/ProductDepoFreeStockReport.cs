using System;

namespace LabaidMIS.Data.Classes.Product
{
    public class ProductDepoFreeStockReport
    {
        public string DepotID { get; set; }
        public string DepotName { get; set; }
        public Nullable<decimal> ReceiveQuantity { get; set; }
        public Nullable<decimal> SoldQuantity { get; set; }
        public Nullable<decimal> TransitQuantity { get; set; }
        public Nullable<decimal> ClosingQuantity { get; set; }

        public Nullable<int> LastWeekAvgQuantity { get; set; }
        public Nullable<int> SixMonthAvgQuantity { get; set; }
    }
}