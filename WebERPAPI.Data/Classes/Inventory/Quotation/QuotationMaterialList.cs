using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class QuotationMaterialList
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string RequisitionCode { get; set; }

        public string VersionNo { get; set; }
        public string MaterialGrade { get; set; }
        public string ModeOfShipment { get; set; }

        public Nullable<int> IsReceived { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}