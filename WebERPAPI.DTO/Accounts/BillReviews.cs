using System;

namespace WebERPAPI.DTO.Accounts
{
    public class BillReviews
    {
        public string BillCode { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> TDS { get; set; }
        public Nullable<decimal> AdvanceVAT { get; set; }
        public Nullable<decimal> OthersDeduction { get; set; }
        public Nullable<decimal> OthersAddition { get; set; }
        public Nullable<decimal> TotalPayable { get; set; }
        public string Remarks { get; set; }
        public string BillGroup { get; set; }
        public Nullable<Boolean> IsAccountVerified { get; set; }
        public string AccountsVerifiedBy { get; set; }
        public Nullable<DateTime> AccountsVerifiedOn { get; set; }
        public Nullable<Boolean> IsManagementApproved { get; set; }
        public Nullable<DateTime> ManagementApprovedOn { get; set; }
        public string ManagementRemarks { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<DateTime> ChallanBillDate { get; set; }
        public string ChallanBillNo { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}