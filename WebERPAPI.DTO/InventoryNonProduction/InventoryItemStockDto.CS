using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class InventoryItemStockDto
    {
        public Nullable<int> ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }

        public string SubGroupName { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string ItemUsageType { get; set; }

        public Nullable<decimal> LastStockQuantity { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> OpeningQuantity { get; set; }
        public Nullable<decimal> AllStoreQuantity { get; set; }
        public Nullable<decimal> PendingIssueQuantity { get; set; }

        public string StoreName { get; set; }

        public string LastUpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }

        public int ItemUsageTypeID { get; set; }
        public int MainGroupID { get; set; }
        public string MainGroupName { get; set; }
    }

    public class InventoryItemStockTransferDto
    {
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> TransferQty { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }

        public string SubGroupName { get; set; }

        public string UOM { get; set; }
        public Nullable<decimal> MOQ { get; set; }
        public string ItemUsageType { get; set; }

        public Nullable<decimal> LastStockQuantity { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> OpeningQuantity { get; set; }
        public Nullable<decimal> AllStoreQuantity { get; set; }
        public Nullable<decimal> PendingIssueQuantity { get; set; }

        public string StoreName { get; set; }

        public string LastUpdatedBy { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }

        public Nullable<int> SourceStoreId { get; set; }
        public Nullable<int> DestinationStoreId { get; set; }
        public string CreatedById { get; set; }
        public Nullable<decimal> TransferPending { get; set; }
    }

    public class TransitItemListDto
    {
        public int ID { get; set; }
        public Nullable<int> SourceStoreID { get; set; }
        public Nullable<int> DestinationStoreID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<decimal> TransferQty { get; set; }
        public Nullable<bool> IsReceived { get; set; }
        public string CreatedById { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ReceivedById { get; set; }
        public string ReceivedBy { get; set; }
        public Nullable<System.DateTime> ReceivedOn { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameWithSpec { get; set; }
        public string SourceStoreName { get; set; }
        public string DestinationStoreName { get; set; }

        public string CreatedBy { get; set; }
    }
}