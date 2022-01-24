using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaBlockListEntry
    {
        public string ReferenceCode { get; set; }
        public Nullable<DateTime> SubmissionDate { get; set; }
        public Nullable<DateTime> FinancialYearStart { get; set; }
        public Nullable<DateTime> FinancialYearEnd { get; set; }
        public string ProductExecutiveID { get; set; }

        public string EmployeeID { get; set; }
    }

    public class ProformaBlockListUpdate
    {
        public string BlockListCode { get; set; }
        public string ApprovedReferenceNumber { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }
        public string EmployeeID { get; set; }
    }

    public class ProformaBlockDetailsEntry
    {
        public string Data { get; set; }
        public string CreatedByID { get; set; }
    }
}