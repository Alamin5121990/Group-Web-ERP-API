using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class SupplierMasterBills
    {
        public string BillID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string BillGroup { get; set; }
        public string SupplierBillNo { get; set; }
        public string BillDescription { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public string AccountsReceiveBy { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<decimal> CarryingCharge { get; set; }
        public Nullable<decimal> LoadingCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
    }
}