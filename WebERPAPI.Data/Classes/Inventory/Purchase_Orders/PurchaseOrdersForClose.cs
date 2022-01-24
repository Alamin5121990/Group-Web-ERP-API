using LabaidMIS.Data.Classes.Accounts;
using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class PurchaseOrdersForClose
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string RequisitionID { get; set; }
        public string VersionNo { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }

    public class PurchaseOrdersReport
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public Nullable<decimal> POQuantity { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string RequisitionID { get; set; }
        public string VersionNo { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public Boolean IsReadyToClose { get; set; }

        public List<PurchaseOrderGRNDetails> GRNDetails { get; set; }
    }
}