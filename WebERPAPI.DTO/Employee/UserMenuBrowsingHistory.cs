using System;

namespace WebERPAPI.DTO.Employee
{
    public class UserBrowsingHistory
    {
        public string MenuName { get; set; }
        public Nullable<DateTime> RequestedOn { get; set; }
    }
}