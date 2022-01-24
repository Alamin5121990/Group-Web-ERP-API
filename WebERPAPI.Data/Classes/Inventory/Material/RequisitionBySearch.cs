using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class RequisitionBySearch
    {
        public string RequisitionDate { get; set; }
        public Boolean IsApproved { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public string VersionNo { get; set; }
        public string RequisitionID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> LCQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<decimal> RemainingQuantity { get; set; }
        public string MaterialGrade { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string ShortSpec { get; set; }
        public string Source { get; set; }
    }
}