using System;

namespace WebERPAPI.DTO.Maintenance
{
    public class QueryLibraryTitleDto
    {
        public Nullable<int> ID { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }
}