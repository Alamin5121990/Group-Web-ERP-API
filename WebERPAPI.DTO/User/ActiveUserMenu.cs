using System;

namespace WebERPAPI.DTO.User
{
    public class ActiveUserMenu
    {
        public Nullable<int> UserID { get; set; }
        public string EmployeeName { get; set; }
        public string MenuName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string EmployeeID { get; set; }
    }
}