using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class BillReviewSummary
    {
        public string BillID { get; set; }
        public string ChallanID { get; set; }
        public string POID { get; set; }
        public string GRNID { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }

        public string BillGroup { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> BillQty { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> AdvanceVAT { get; set; }
        public Nullable<decimal> TDS { get; set; }
        public Nullable<decimal> OthersDeduction { get; set; }
        public Nullable<decimal> OthersAddition { get; set; }
        public Nullable<decimal> TotalPayable { get; set; }
        public string Remarks { get; set; }

        public string SupplierName { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string ChallanBillNo { get; set; }
        public Nullable<DateTime> ChallanBillDate { get; set; }
    }
}