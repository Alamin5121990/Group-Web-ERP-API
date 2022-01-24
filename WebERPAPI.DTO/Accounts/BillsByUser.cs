using System;

namespace WebERPAPI.DTO.Accounts
{
    public class BillsByUser
    {
        public string POID { get; set; }

        public string BillID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string UOM { get; set; }

        public Nullable<decimal> TotalBillAmount { get; set; }
        public string SubmittedBy { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<DateTime> SupplierBillDate { get; set; }

        public string SupplierBillNo { get; set; }
        public string BillDescription { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public string AccountsReceiveBy { get; set; }

        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountsRemarks { get; set; }
    }
}