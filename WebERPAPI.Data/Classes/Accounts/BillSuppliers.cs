using System;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class BillSuppliers
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> AdvancePaid { get; set; }
    }
}