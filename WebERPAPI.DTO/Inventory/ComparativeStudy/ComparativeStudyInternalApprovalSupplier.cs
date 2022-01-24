using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
{
    public class ComparativeStudyInternalApprovalSupplier
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<int> CSID { get; set; }
        public string RequisitionCode { get; set; }
        public string CSCode { get; set; }
    }

    public class ComparativeStudyInternalApprovalDetails
    {
        public Nullable<int> CSID { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }

    public class ComparativeStudyInternalApprovalReport
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string RequisitionCode { get; set; }
        public string CSCode { get; set; }
        public List<ComparativeStudyInternalApprovalMaterial> Materials { get; set; }
    }

    public class ComparativeStudyInternalApprovalMaterial
    {
        public int SL { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}