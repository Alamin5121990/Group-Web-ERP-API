using System;

namespace LabaidMIS.Data.Classes.Inventory.Sample
{
    public class SampleAllocationQuantity
    {
        public string SampleID { get; set; }
        public Nullable<int> YearNo { get; set; }
        public Nullable<int> MonthNo { get; set; }
        public Nullable<decimal> AllocationQuantity { get; set; }
    }
}