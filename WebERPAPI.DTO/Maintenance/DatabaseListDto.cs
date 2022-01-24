using System;

namespace WebERPAPI.DTO.Maintenance
{
    public class DatabaseListDto
    {
        public Nullable<int> ID { get; set; }
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
    }
}