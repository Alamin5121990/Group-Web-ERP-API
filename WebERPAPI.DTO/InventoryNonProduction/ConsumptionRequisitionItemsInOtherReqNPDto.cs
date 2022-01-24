using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ConsumptionRequisitionItemsInOtherReqNPDto
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> ItemID { get; set; }
        public string Purpose { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<DateTime> RequireDate { get; set; }
        public string RequisitionCode { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> CurrentStockQuantity { get; set; }
    }
}