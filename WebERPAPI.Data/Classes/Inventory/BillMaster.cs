using System;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class MasterBill
    {
        public string BillID { get; set; }
        public Nullable<DateTime> BillDate { get; set; }
        public string SubmittedBy { get; set; }
        public string BillGroup { get; set; }
        public string SupplierName { get; set; }
        public string SupplierID { get; set; }
        public Nullable<DateTime> SupplierBillDate { get; set; }
        public string SupplierBillNo { get; set; }
        public string BillDescription { get; set; }
        public Nullable<DateTime> BillSettledOn { get; set; }
        public string BillSettleRemarks { get; set; }
        public string BillSettledBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public string AccountsReceiveBy { get; set; }
        public Nullable<DateTime> AccountsReceiveDate { get; set; }
        public string AccountsRemarks { get; set; }
        public Nullable<decimal> CarryingCharge { get; set; }
        public Nullable<decimal> LoadingCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
    }

    public class ReceiveBill
    {
        public string BillId { get; set; }
        public string AccountsReceiveBy { get; set; }
        public string AccountsRemarks { get; set; }
    }

    public class BillDetails
    {
        public string BillID { get; set; }
        public int SLNo { get; set; }
        public string ChallanID { get; set; }
        public string POID { get; set; }
        public string GRNID { get; set; }
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> BillQty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> VatAmt { get; set; }
        public Nullable<decimal> AITAmt { get; set; }
        public string BillRemarks { get; set; }
    }

    public class BillPaymentDetails
    {
        public string BillID { get; set; }
        public Nullable<DateTime> PaymentDate { get; set; }
        public int PaymentTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public string BankID { get; set; }
        public string CheckNo { get; set; }
        public string BankBranchName { get; set; }
        public string PaymentBy { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public string Remarks { get; set; }
    }

    public class MasterBillPaymentDetailsReport
    {
        public int PaymentID { get; set; }
        public string PaymentTypeName { get; set; }
        public Nullable<DateTime> PaymentDate { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public string BankName { get; set; }
        public string BankBranchName { get; set; }
        public string CheckNo { get; set; }
        public string PaymentBy { get; set; }
        public string Remarks { get; set; }
    }

    public class SettleBill
    {
        public string BillId { get; set; }
        public string EmployeeID { get; set; }
        public string Remarks { get; set; }
    }
}