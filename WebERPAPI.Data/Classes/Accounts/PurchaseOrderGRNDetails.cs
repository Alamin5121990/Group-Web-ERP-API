using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class PurchaseOrderGRNDetails
    {
        public string GRNID { get; set; }
        public Nullable<DateTime> GRNDate { get; set; }
        public Nullable<DateTime> ChallanDate { get; set; }
        public string ChallanNo { get; set; }
        public string MaterialName { get; set; }
        public Nullable<decimal> GRNQuantity { get; set; }
        public Nullable<DateTime> QCHandOverDate { get; set; }
        public Nullable<DateTime> QCTestDate { get; set; }
        public Nullable<DateTime> QCPassedDate { get; set; }
        public Nullable<decimal> QCPassedQty { get; set; }
    }
}