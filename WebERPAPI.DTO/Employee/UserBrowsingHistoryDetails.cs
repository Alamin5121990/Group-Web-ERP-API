using System;

namespace WebERPAPI.DTO.Employee
{
    public class UserMenuBrowsingHistory
    {
        public Nullable<int> MenuID { get; set; }
        public string MenuName { get; set; }
        public string Route { get; set; }
        public Nullable<int> TotalRequest { get; set; }
        public Nullable<DateTime> LastRequestOn { get; set; }
    }
}