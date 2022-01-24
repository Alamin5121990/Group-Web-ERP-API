using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemIssueDetailsDto //: BaseEntityDTO
    {
        public Nullable<int> IssueID { get; set; }

        public Nullable<int> ItemID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public string ItemCode { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string UOM { get; set; }
        public Nullable<decimal> RequisitionQuantity { get; set; }
        public Nullable<decimal> IssueQuantity { get; set; }
        public Nullable<decimal> CurrentStockQuantity { get; set; }
    }
}