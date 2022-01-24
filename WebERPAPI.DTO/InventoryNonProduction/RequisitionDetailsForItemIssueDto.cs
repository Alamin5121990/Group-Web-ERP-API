using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class RequisitionDetailsForItemIssueDto
    {
        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> ApprovedQuantity { get; set; }
        public Nullable<decimal> StockQuantity { get; set; }

        public Nullable<decimal> AlreadyIssuedQuantity { get; set; }
    }
}