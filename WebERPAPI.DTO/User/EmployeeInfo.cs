using System;

namespace WebERPAPI.DTO.User
{
    public class EmployeeInfo
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserCode { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeID { get; set; }
        public string ProfileImageName { get; set; }
        public string Mobile { get; set; }
        public string UserSystem { get; set; }
        public string ShowPassword { get; set; }
        public Nullable<DateTime> JoinningDate { get; set; }
    }
}