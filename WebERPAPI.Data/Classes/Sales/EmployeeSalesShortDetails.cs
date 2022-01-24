using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class EmployeeSalesSummary
    {
        public string Title { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<Boolean> IsPercent { get; set; }
    }
}