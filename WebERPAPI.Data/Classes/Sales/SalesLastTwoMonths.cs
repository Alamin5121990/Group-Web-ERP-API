using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class SalesLastTwoMonths
    {
        public int ProductID { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<int> LastMonthQuantity { get; set; }
    }
}