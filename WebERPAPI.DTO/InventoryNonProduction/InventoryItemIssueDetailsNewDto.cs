using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class InventoryItemIssueDetailsNewDto : BaseEntityNew
    {
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> ItemID { get; set; }
    }
}