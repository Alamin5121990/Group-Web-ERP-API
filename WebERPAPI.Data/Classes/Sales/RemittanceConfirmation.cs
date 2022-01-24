using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class RemittanceConfirmationReport
    {
        public string DepositID { get; set; }
        public Nullable<System.DateTime> DepositDate { get; set; }
        public string DepositBy { get; set; }
        public string Location { get; set; }
        public string DepositBank { get; set; }
        public string BankName { get; set; }
        public string DepostByName { get; set; }
        public string Remarks { get; set; }
        public int SLNo { get; set; }
        public string DepositType { get; set; }
        public string DepositSlipNumber { get; set; }
        public string InstrumentNumber { get; set; }
        public Nullable<System.DateTime> InstrumentDate { get; set; }
        public string InstrumentBank { get; set; }
        public string BranchInfo { get; set; }
        public Nullable<decimal> InstrumentAmount { get; set; }
        public Boolean RemitanceConfirmed { get; set; }
        public Nullable<System.DateTime> ConfirmationDate { get; set; }
        public string ConfirmedBy { get; set; }
        public string ConfirmationRemarks { get; set; }
        public string Addedby { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
    }

    public class RemittanceConfirmation
    {
        public string DepositID { get; set; }
        public string SerialNumber { get; set; }
        public string DepositSlipNumber { get; set; }
        public string EmployeeID { get; set; }
        public string ConfirmationRemarks { get; set; }
        public Nullable<System.DateTime> VoucherDate { get; set; }
    }

    public class RemittanceConfirmationData
    {
        public string Data { get; set; }
        public string EmployeeID { get; set; }
    }

    public class DepositRemittanceCollection
    {
        public Nullable<System.DateTime> ReceivedDate { get; set; }
        public string DepotID { get; set; }
        public string PaymentMode { get; set; }
        public string BankName { get; set; }
        public string ChequeNumber { get; set; }
        public Nullable<decimal> collectionAmt { get; set; }
        public Nullable<System.DateTime> DepositDate { get; set; }
        public string DepositType { get; set; }
        public string InstrumentNumber { get; set; }
        public Nullable<decimal> DepositAmount { get; set; }
        public Nullable<Boolean> RemitanceConfirmed { get; set; }
        public Nullable<System.DateTime> ConfirmationDate { get; set; }
        public string ConfirmedBy { get; set; }
    }
}