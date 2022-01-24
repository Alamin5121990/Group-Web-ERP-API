using System;

namespace WebERPAPI.DTO.User
{
    public class LoggedUserDetails
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> UserId { get; set; }
        public string UserCode { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string EmployeeName { get; set; }

        public string Email { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }

        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public string DepotCode { get; set; }
        public string LocationCode { get; set; }
        public string LocationLevel { get; set; }
        public Nullable<int> OfficeLocationID { get; set; }
        public Nullable<int> ApplicationID { get; set; }
        public string AppName { get; set; }
        public string DashboardRoute { get; set; }
        public string LocationName { get; set; }
    }
}