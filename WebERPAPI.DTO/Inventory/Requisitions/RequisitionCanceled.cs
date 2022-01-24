using System;

namespace WebERPAPI.DTO.Inventory.Requisitions
{
    public class RequisitionCanceled
    {
        public string RequisitionID { get; set; }
        public Nullable<DateTime> ReqDate { get; set; }
        public string EmployeeName { get; set; }

        public string MaterialName { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialGrade { get; set; }
        public string VersionNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public string Remarks { get; set; }
        public Nullable<Boolean> IsApproved { get; set; }
        public string ProfileImagename { get; set; }
        public Nullable<int> QuotationCreated { get; set; }
        public Nullable<int> QuotationPending { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string MaterialType { get; set; }
        public string ReasonToCancel { get; set; }
        public string CanceledBy { get; set; }
        public Nullable<DateTime> CanceledOn { get; set; }
    }
}