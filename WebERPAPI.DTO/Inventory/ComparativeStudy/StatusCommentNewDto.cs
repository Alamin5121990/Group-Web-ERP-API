using System;

namespace WebERPAPI.DTO.Inventory.ComparativeStudy
{
    public class StatusCommentNewDto
    {
        public Nullable<int> ID { get; set; }
        public string LCID { get; set; }
        public Nullable<int> CSID { get; set; }
        public Nullable<Boolean> IsLocalCS { get; set; }
        public string Comment { get; set; }
        public Nullable<int> CreatedByID { get; set; }
    }
}