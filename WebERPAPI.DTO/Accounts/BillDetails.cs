using System;

namespace WebERPAPI.DTO.Accounts
{
    public class BillInfo
    {
        public string BillID { get; set; }

        public Nullable<DateTime> BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string SubmittedDepartment { get; set; }
        public string SubmittedDesignation { get; set; }
        public string AccountsReceivedDepartment { get; set; }
        public string AccountsReceivedDesignation { get; set; }

        public string BillGroup { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }

        public Nullable<DateTime> SupplierBillDate { get; set; }
        public string SupplierBillNo { get; set; }
        public string BillDescription { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }
        public decimal Discount { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public string AccountsReceiveBy { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<decimal> CarryingCharge { get; set; }

        public Nullable<decimal> LoadingCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public string VoucherCode { get; set; }

        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<Boolean> BillSettleStatus { get; set; }
        public Nullable<Boolean> isBillReceived { get; set; }
        public Nullable<Boolean> IsForwarded { get; set; }
        public string ForwardBy { get; set; }
        public string ForwardRemarks { get; set; }
        public string ForwardByID { get; set; }
    }

    public class BillReportStatusDto
    {
        public Nullable<DateTime> DateAdded { get; set; }
        public string AddedById { get; set; }
        public string AddedBy { get; set; }
        public Nullable<Boolean> IsForwarded { get; set; }
        public Nullable<DateTime> ForwardOn { get; set; }
        public string ForwardByID { get; set; }
        public string ForwardBy { get; set; }
        public Nullable<Boolean> IsAccountsReceived { get; set; }
        public string AccountsReceiveById { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountsReceiveBy { get; set; }
        public Nullable<Boolean> IsBillSettled { get; set; }
        public Nullable<DateTime> BillSettledOn { get; set; }
        public string BillSettledById { get; set; }
        public string BillSettledBy { get; set; }
    }
}