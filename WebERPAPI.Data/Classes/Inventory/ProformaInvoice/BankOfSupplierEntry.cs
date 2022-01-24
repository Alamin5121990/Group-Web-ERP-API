using System;

namespace LabaidMIS.Data.Classes.Inventory.ProformaInvoice
{
    public class BankOfSupplierEntry
    {
        public Nullable<int> ID { get; set; }
        public string ShortName { get; set; }
        public string BankName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Remarks { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string CreatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string UpdatedByID { get; set; }
    }
}