using System;

namespace LabaidMIS.Data.Classes.Inventory.LC
{
    public class LetterOfCreditEntry
    {
        public int LCID { get; set; }

        public string LCCode { get; set; }
        public string LCNumber { get; set; }
        public Nullable<DateTime> LCDate { get; set; }
        public Nullable<DateTime> LastShipmentDate { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }

        public Nullable<decimal> CurrencyConversionRate { get; set; }
        public Nullable<int> BankID { get; set; }
        public Nullable<int> AdvisoryBankID { get; set; }
        public Nullable<DateTime> PreLCDate { get; set; }
        public Nullable<DateTime> InsuranceDate { get; set; }

        public string InsuranceNumber { get; set; }
        public Nullable<decimal> InsuranceValue { get; set; }
        public Nullable<decimal> Margin { get; set; }
        public string LCType { get; set; }
        public string CreditFacility { get; set; }

        public string IRCNumber { get; set; }
        public string LCAFormNo { get; set; }
        public string InsuranceCoverNote { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<Boolean> IsBankApproved { get; set; }
        public string Remarks { get; set; }

        public string EmployeeID { get; set; }
        public string Data { get; set; }
    }

    public class LetterOfCreditDetails
    {
        public Nullable<int> LCID { get; set; }
        public Nullable<int> PIID { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string IndentorCode { get; set; }
        public string SupplierCode { get; set; }
        public string ManufacturerCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> CurrencyID { get; set; }
        public string ModeOfShipment { get; set; }
    }
}