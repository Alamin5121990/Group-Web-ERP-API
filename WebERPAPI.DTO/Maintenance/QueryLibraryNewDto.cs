using System;

namespace WebERPAPI.DTO.Maintenance
{
    public class QueryLibraryNewDto : BaseEntityNew
    {
        public Nullable<int> DatabaseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SqlQuery { get; set; }
        public string OldQuery { get; set; }
        public int QueryTypeID { get; set; }
    }
}