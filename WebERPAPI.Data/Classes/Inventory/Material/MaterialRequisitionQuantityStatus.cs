using System;

namespace LabaidMIS.Data.Classes.Inventory.Material
{
    public class MaterialRequisitionQuantityStatus
    {
        public string RequisitionID { get; set; }

        public Nullable<DateTime> RequisitonDate { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public string VersionNo { get; set; }
        public string MaterialGrade { get; set; }
    }

    public class MaterialRequisitionQuantityStatusPO
    {
        public string RequisitionID { get; set; }
        public string Code { get; set; }

        public string LCNo { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string PurchaseType { get; set; }
    }

    public class MaterialRequisitionQuantityStatusPORemaining
    {
        public string RequisitionID { get; set; }
        public string Code { get; set; }

        public string LCNo { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }

        public string PurchaseType { get; set; }
    }
}