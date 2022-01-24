using System;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class PurchaseOrdersNPToVerifyDTO
    {
        public Nullable<int> ID { get; set; }
        public string MainGroupName { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public Nullable<int> InventoryTypeID { get; set; }
        public string InventoryTypeName { get; set; }
        public string RequisitionCode { get; set; }
        public string POCode { get; set; }
        public Nullable<decimal> POTotal { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
        public string Remarks { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string VerifiedBy { get; set; }
        public string VerifiedByID { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }

        public string VerifyRemarks { get; set; }
        public string CanceledBy { get; set; }
        public string CanceledByID { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string CanceledReason { get; set; }

        public string UpdatedBy { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }

        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string ItemNames { get; set; }
    }
}