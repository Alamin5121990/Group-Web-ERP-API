using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Inventory
{
    public class InternalApprovalMaterialsForPurchaseOrder
    {
        public Nullable<int> CSID { get; set; }
        public string CSCode { get; set; }

        public Nullable<int> InternalApprovalID { get; set; }
        public string InternalApprovalCode { get; set; }
        public Nullable<DateTime> InternalApprovalDate { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string CountryOfOrigin { get; set; }

        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> RemainingQuantity { get; set; }
        public Nullable<decimal> Price { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string VersionNo { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
    }

    public class InternalApprovalMaterialsForPurchaseOrderReport
    {
        public Nullable<int> CSID { get; set; }

        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public List<PurchaseOrderSupplierMaterials> SupplierMaterials { get; set; }
    }

    public class PurchaseOrderSupplierMaterials
    {
        public Nullable<int> InternalApprovalID { get; set; }
        public string InternalApprovalCode { get; set; }
        public Nullable<DateTime> InternalApprovalDate { get; set; }

        public string CSCode { get; set; }

        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }
        public string CountryOfOrigin { get; set; }
        public Nullable<decimal> RemainingQuantity { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string VersionNo { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
    }
}