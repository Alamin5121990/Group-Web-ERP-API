using System;

namespace WebERPAPI.DTO.Inventory.Procurement.Quotation
{
    public class QuotationItemsNP
    {
        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string UOM { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public string RequisitionCode { get; set; }

        public Nullable<DateTime> DeliveryDate { get; set; }
        public Nullable<int> SubGroupId { get; set; }
        public string SubGroupName { get; set; }
        public string MainGroupName { get; set; }
        public Nullable<int> RequisitionItemID { get; set; }
    }
}