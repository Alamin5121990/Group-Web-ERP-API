using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class ServiceBillDetails
    {
        public string BillID { get; set; }
        public int SLNo { get; set; }
        public string ServiceType { get; set; }
        public string ServiceID { get; set; }
        public Nullable<DateTime> ServiceDate { get; set; }
        public string LCDocumentNo { get; set; }
        public string InvoiceNo { get; set; }
        public string ItemName { get; set; }
        public string LoadingPoint { get; set; }
        public Nullable<decimal> DocumentValue { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> DiscountAmt { get; set; }
        public Nullable<decimal> NetPayableAmount { get; set; }
        public string OthersInfo { get; set; }
    }
}