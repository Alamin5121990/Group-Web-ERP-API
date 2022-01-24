using System;

namespace LabaidMIS.Data.Classes.Sales.Depo
{
    public class DepoSalesStatistics
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public Nullable<int> LastWeekAvgQuantity { get; set; }
        public Nullable<int> SixMonthAvgQuantity { get; set; }
    }
}