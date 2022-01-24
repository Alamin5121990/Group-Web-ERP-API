using System;

namespace WebERPAPI.DTO.Inventory.Purchase_Orders
{
    public class PurchaseOrdersForVerification
    {
        public string POID { get; set; }

        public Nullable<DateTime> PODate { get; set; }
        public string RequisitionCode { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string VersionNo { get; set; }

        public string MaterialGrade { get; set; }
        public string ModeofPayment { get; set; }
        public string Currency { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public Nullable<decimal> POAmount { get; set; }
        public Nullable<int> TotalMaterial { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}