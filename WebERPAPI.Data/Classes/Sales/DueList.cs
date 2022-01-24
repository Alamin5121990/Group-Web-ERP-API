using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DepotDueList
    {
        public string DepotID { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public Nullable<decimal> CashDue { get; set; }
        public Nullable<decimal> CreditDueAmount { get; set; }
        public Nullable<decimal> CreditOverDueAmount { get; set; }
    }

    public class RegionDueList
    {
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public Nullable<decimal> CashDue { get; set; }
        public Nullable<decimal> CreditDueAmount { get; set; }
        public Nullable<decimal> CreditOverDueAmount { get; set; }
    }

    public class DepotDueDetails
    {
        public string DepotID { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string Amid { get; set; }
        public string AMName { get; set; }
        public string TerritoryID { get; set; }
        public string TerritoryName { get; set; }
        public string ChemistID { get; set; }
        public string ChemistName { get; set; }
        public string InvoiceID { get; set; }
        public string InvoiceType { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public Nullable<decimal> SAmount { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public Nullable<decimal> ReturnValue { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public string InvoiceStatus { get; set; }
        public string InvoiceAge { get; set; }
        public int OverdueAge { get; set; }
    }
}