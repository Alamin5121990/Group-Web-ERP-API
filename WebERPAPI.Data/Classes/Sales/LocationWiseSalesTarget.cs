using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class LocationWiseSalesTargetReport
    {
        public Nullable<int> ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string PackSize { get; set; }
        public Nullable<decimal> TP { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<int> CurrentMonthTargetQuantity { get; set; }
        public Nullable<int> LastMonthTargetQuantity { get; set; }
        public Nullable<int> CW1 { get; set; }
        public Nullable<int> CW2 { get; set; }
        public Nullable<int> CW3 { get; set; }
        public Nullable<int> CW4 { get; set; }
        public Nullable<int> LW1 { get; set; }
        public Nullable<int> LW2 { get; set; }
        public Nullable<int> LW3 { get; set; }
        public Nullable<int> LW4 { get; set; }
    }
}