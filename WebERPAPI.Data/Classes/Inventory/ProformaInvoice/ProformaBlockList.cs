using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class ProformaBlockList
    {
        public Nullable<int> ID { get; set; }
        public string BlockListCode { get; set; }
        public string ReferenceCode { get; set; }

        public string ApprovedReferenceNumber { get; set; }
        public Nullable<DateTime> ApprovedOn { get; set; }

        public Nullable<DateTime> SubmissionDate { get; set; }
        public Nullable<DateTime> FinancialYearStart { get; set; }
        public Nullable<DateTime> FinancialYearEnd { get; set; }
        public string ProductExecutiveID { get; set; }
        public string ProductExecutive { get; set; }
    }
}