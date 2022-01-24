using System;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class PurchaseOrderSignaturesNPDTO
    {
        public Nullable<int> ID { get; set; }

        public string PORemarks { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedDesignation { get; set; }
        public string CreatedDepartment { get; set; }

        public Nullable<Boolean> IsVerified { get; set; }
        public string VerifiedBy { get; set; }
        public string VerifiedByID { get; set; }
        public Nullable<DateTime> VerifiedOn { get; set; }
        public string VerifiedRemarks { get; set; }
        public string VerifiedDesignation { get; set; }
        public string VerifiedDepartment { get; set; }

        public Nullable<Boolean> IsCanceled { get; set; }
        public string CanceledBy { get; set; }

        public string CanceledByID { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
        public string CanceledReason { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string UpdatedDesignation { get; set; }
        public string UpdatedDepartment { get; set; }

        public Nullable<Boolean> IsClosed { get; set; }
        public Nullable<DateTime> ClosedOn { get; set; }
        public string ClosedByID { get; set; }
        public string ClosedBy { get; set; }

        public string ClosedRemarks { get; set; }
    }
}