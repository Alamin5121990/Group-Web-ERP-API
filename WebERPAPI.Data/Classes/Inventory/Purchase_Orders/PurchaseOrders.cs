using System;
using System.Collections.Generic;

namespace LabaidMIS.Data.Classes.Inventory
{
    public class PurchaseOrders
    {
        public string POID { get; set; }
        public Nullable<DateTime> PODate { get; set; }
        public string Subject { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<DateTime> RequiredDate { get; set; }
        public Nullable<DateTime> DeliveryDate { get; set; }
        public string ModeofPayment { get; set; }
        public string TermsConditions { get; set; }
        public string Currency { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> POAmount { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
        public Boolean IsApproved { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public List<PurchaseOrderDetails> Materials { get; set; }
    }

    public class PurchaseOrderReport
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> TotalPOAmount { get; set; }
        public Nullable<int> TotalPO { get; set; }
        public List<PurchaseOrders> SupplierPurchaseOrders { get; set; }
    }
}