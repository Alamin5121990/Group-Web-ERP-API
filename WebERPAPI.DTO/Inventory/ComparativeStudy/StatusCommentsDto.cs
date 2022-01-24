using System;

namespace WebERPAPI.DTO.Inventory.ComparativeStudy
{
    public class StatusCommentsDto : BaseEntityDTO
    {
        public string LCID { get; set; }
        public Nullable<int> CSID { get; set; }
        public string Comment { get; set; }
    }
}