using System;

namespace WebERPAPI.DTO.Inventory.Procurement
{
    public class RequistionSearchItems
    {
        public string MainGroupName { get; set; }

        public string SubGroupName { get; set; }
        public string StoreName { get; set; }
        public string RequisitionType { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<int> RequisitionID { get; set; }

        public string RequisitionRemarks { get; set; }
        public Nullable<int> ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public Nullable<int> OrderNo { get; set; }
        public string Purpose { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<int> VersionNo { get; set; }
        public string VersionStateName { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<Boolean> IsVerified { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifyRemarks { get; set; }

        public string VerifiedBy { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string ApprovalRemarks { get; set; }
        public string ApprovedBy { get; set; }

        public Nullable<bool> IsCanceled { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string ReasonToCancel { get; set; }
        public string CanceledBy { get; set; }

        public int Age { get; set; }
        public bool IsCSApproved { get; set; }
        public string ReqStatus { get; set; }

        //quantity

        public Nullable<decimal> CSQuantity { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<decimal> PendingQuantity { get; set; }
    }
}