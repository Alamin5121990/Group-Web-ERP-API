using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class InventoryRequisition
    {
        public Nullable<int> InventoryTypeID { get; set; }
        public string InventoryType { get; set; }

        public string StoreName { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<int> RequisitionID { get; set; }

        public string RequisitionRemarks { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> RequisitionTypeID { get; set; }
        public string RequisitionForMonths { get; set; }
        public string RequisitionForBrands { get; set; }
        public string CreatedBy { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string CreatedByID { get; set; }

        public string VerifiedByID { get; set; }
        public string VerifiedBy { get; set; }
        public Nullable<Boolean> IsVerified { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }

        public string TermAndCondition { get; set; }
        public string RequisitionStatus { get; set; }

        //for report with statua

        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string CSCode { get; set; }
        public string POCode { get; set; }
        public string GRNCode { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<decimal> PendingQuantity { get; set; }
        public Nullable<DateTime> CSDate { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
    }
}