using System;

namespace WebERPAPI.DTO.Inventory.PurchaseOrdersNP
{
    public class ComparativeStudyItemsForPurchaseOrderNP
    {
        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> CSQuantity { get; set; }

        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public string CSCode { get; set; }
        public string RequisitionCode { get; set; }
        public Nullable<decimal> PODoneQuantity { get; set; }
        public Nullable<int> ID { get; set; }

        public Nullable<int> BillPaymentTypeID { get; set; }
        public Nullable<int> CreditDays { get; set; }
        public string VendorRemarks { get; set; }
    }
}