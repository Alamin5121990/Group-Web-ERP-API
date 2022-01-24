using System;

namespace WebERPAPI.DTO.Employee
{
    public class SalesEmployeeHasNoUserAccount
    {
        public Nullable<int> UserId { get; set; }
        public string UserCode { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeCode { get; set; }
        public string ProfileImageName { get; set; }
        public string Mobile { get; set; }
    }
}