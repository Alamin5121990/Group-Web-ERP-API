using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class PurchaseOrdersForBillSubmit
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public string ChallanNo { get; set; }
        public string RequisitionID { get; set; }
    }
}