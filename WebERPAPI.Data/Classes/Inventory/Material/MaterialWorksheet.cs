using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialWorksheet
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }

        public string MaterialType { get; set; }
        public string MaterialCategory { get; set; }
        public string ProductPriorityCode { get; set; }

        public Nullable<decimal> MOQ { get; set; }
        public string SourceType { get; set; }
        public Nullable<int> LeadTime { get; set; }

        public Nullable<decimal> CurrentFreeStock { get; set; }
        public Nullable<decimal> FreeStock { get; set; }

        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> BookingQuantity { get; set; }
        public Nullable<decimal> QuarantineQuantity { get; set; }

        public Nullable<decimal> OneBatchRequiredQuantity { get; set; }

        public Nullable<DateTime> RequisitionDate { get; set; }

        public Boolean IsIntermediateMaterial { get; set; }
    }
}