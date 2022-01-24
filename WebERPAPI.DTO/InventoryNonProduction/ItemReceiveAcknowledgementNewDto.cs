using System;

namespace WebERPAPI.DTO.InventoryNonProduction
{
    public class ItemReceiveAcknowledgementNewDto : BaseEntityNew
    {
        public Nullable<int> IssueID { get; set; }
    }
}