using System;

namespace WebERPAPI.DTO.User
{
    public class UserModulesDto
    {
        public Nullable<int> ID { get; set; }

        public string ModuleName { get; set; }
        public string ShortName { get; set; }
        public Nullable<int> OrderNo { get; set; }
    }
}