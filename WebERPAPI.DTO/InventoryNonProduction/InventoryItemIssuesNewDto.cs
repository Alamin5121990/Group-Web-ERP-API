using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemIssuesNewDto : BaseEntityNew
    {
        public string IssueCode { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> MainGroupID { get; set; }
        public string IssueToID { get; set; }
    }
}