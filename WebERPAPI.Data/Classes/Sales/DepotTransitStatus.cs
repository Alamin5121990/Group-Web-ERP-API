using System;

namespace LabaidMIS.Data.Classes.Sales
{
    public class DepotTransitStatus
    {
        public string DepotID { get; set; }
        public string DeliveryAssistantID { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> NoOfAllocation { get; set; }
        public Nullable<DateTime> MaxAlloDate { get; set; }
        public Nullable<DateTime> MaxReturnDate { get; set; }
        public Nullable<int> NoOfInvoice { get; set; }
        public Nullable<decimal> TransitAmount { get; set; }
        public Nullable<int> NoOfCashInvoice { get; set; }
        public Nullable<decimal> CashInvoiceValue { get; set; }
        public Nullable<DateTime> MaxCashInvoiceDate { get; set; }
        public Nullable<int> NoOfCreditInvoice { get; set; }
        public Nullable<decimal> CreditInvoiceValue { get; set; }
        public Nullable<DateTime> MaxCreditInvoiceDate { get; set; }
    }

    public class DepotTransitTerritoryStatus
    {
        public string AllocationID { get; set; }
        public string DepotID { get; set; }
        public string DeliveryAssistantID { get; set; }
        public string TerritoryID { get; set; }
        public string TerritoryName { get; set; }
        public string MPOID { get; set; }
        public string MPOName { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public int NoOfInvoice { get; set; }
        public Boolean IsOpen { get; set; }
    }

    public class DepotTransitAllocationDetails
    {
        public string AllocationID { get; set; }
        public string InvoiceID { get; set; }
        public Nullable<DateTime> InvoiceDate { get; set; }
        public string InvoiceType { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public string ChemistID { get; set; }
        public string ChemistName { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
    }
}