using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class BillReviewNew
    {
        public string BillCode { get; set; }
        public decimal AdvancePaid { get; set; }
        public decimal BillAmount { get; set; }
        public decimal TDS { get; set; }
        public decimal AdvanceVAT { get; set; }
        public decimal OthersDeduction { get; set; }
        public decimal OthersAddition { get; set; }

        public decimal TotalPayable { get; set; }

        public string Remarks { get; set; }
        public string EmployeeID { get; set; }

        public string ChallanBillNo { get; set; }
        public Nullable<DateTime> ChallanBillDate { get; set; }
    }
}