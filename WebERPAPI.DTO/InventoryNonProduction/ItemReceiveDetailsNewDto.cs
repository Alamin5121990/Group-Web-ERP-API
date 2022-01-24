using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemReceiveDetailsNewDto : BaseEntityNew
    {
        public Nullable<int> ItemReceiveID { get; set; }
        public Nullable<int> IssueID { get; set; }
        public Nullable<int> RequisitionID { get; set; }
        public Nullable<int> ItemID { get; set; }
    }
}