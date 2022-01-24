using System;

namespace WebERPAPI.DTO.Accounts
{
    public class BillNew
    {
        public string BillID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string BillGroup { get; set; }
        public string SupplierID { get; set; }
        public string SupplierBillNo { get; set; }
        public Nullable<DateTime> SupplierBillDate { get; set; }
        public string BillDescription { get; set; }
        public string Remarks { get; set; }

        public Nullable<decimal> CarryingCharge { get; set; }
        public Nullable<decimal> LoadingCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Data { get; set; }
    }

    public class BillNewDetails
    {
        public string ChallanID { get; set; }
        public Nullable<int> SLNo { get; set; }
        public string POID { get; set; }
        public string GRNID { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> VatAmt { get; set; }
    }
}