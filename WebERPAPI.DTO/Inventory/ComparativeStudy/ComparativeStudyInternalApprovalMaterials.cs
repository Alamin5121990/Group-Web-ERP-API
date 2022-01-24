using System;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyInternalApprovalMaterials
    {
        public Nullable<int> ID { get; set; }
        public string InternalApprovalCode { get; set; }
        public Nullable<DateTime> ReportDate { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }

        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string CSCode { get; set; }

        public string Remarks { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
    }
}