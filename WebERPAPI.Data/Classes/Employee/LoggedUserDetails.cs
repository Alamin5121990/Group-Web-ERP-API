using System;

namespace LabaidMIS.Data.Classes.Employee
{
    public class LoggedUserDetails
    {
        public Nullable<int> UserID { get; set; }
        public string UserCode { get; set; }
        public string EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string LocationName { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public string DepotCode { get; set; }
        public string LocationCode { get; set; }
        public string LocationLevel { get; set; }
        public Boolean IsITLogin { get; set; }
        public Nullable<DateTime> DOB { get; set; }
    }

    public class LoggedUserDetails2
    {
        public Nullable<int> userid { get; set; }
        public string usercode { get; set; }
        public string employeeid { get; set; }
        public string firstname { get; set; }
        public string employeename { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string locationname { get; set; }
        public string profileimagename { get; set; }
        public string signaturefilename { get; set; }
        public string depotcode { get; set; }
        public string locationcode { get; set; }
        public string locationlevel { get; set; }
        public Boolean isitlogin { get; set; }
        public Nullable<DateTime> DOB { get; set; }
    }

    public class UserPrivilegeNew
    {
        public Nullable<int> MenuID { get; set; }
        public string MenuName { get; set; }
        public string Route { get; set; }
    }
}