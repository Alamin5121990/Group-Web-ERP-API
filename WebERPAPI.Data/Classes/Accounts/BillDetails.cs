using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class BillInfo
    {
        public string BillID { get; set; }

        public Nullable<DateTime> BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string BillGroup { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }

        public Nullable<DateTime> SupplierBillDate { get; set; }
        public string SupplierBillNo { get; set; }
        public string BillDescription { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }

        public Nullable<decimal> AdvancePaid { get; set; }
        public string AccountsReceiveBy { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<decimal> CarryingCharge { get; set; }

        public Nullable<decimal> LoadingCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public string VoucherCode { get; set; }
    }
}