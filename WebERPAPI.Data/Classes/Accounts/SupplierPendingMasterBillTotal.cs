using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Accounts
{
    public class SupplierPendingMasterBillTotal
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
    }

    public class SupplierPendingMasterBillReport
    {
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> TotalBillAmount { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<decimal> TotalDue { get; set; }

        public List<SupplierMasterBills> BillDetails { get; set; }
    }
}