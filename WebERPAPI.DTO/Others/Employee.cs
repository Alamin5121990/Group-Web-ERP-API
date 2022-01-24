using System;

namespace WebERPAPI.DTO
{
    public class EmployeeDetails
    {
        public Nullable<int> ID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string BloodGroup { get; set; }
        public string Location { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public Nullable<DateTime> JoinningDate { get; set; }
        public Nullable<DateTime> DOB { get; set; }

        public string SalesLocation { get; set; }
        public string TerritoryID { get; set; }
        public string TerritoryName { get; set; }
        public string AreaID { get; set; }
        public string AreaName { get; set; }

        public string ProposedLocation { get; set; }
        public string EffectFrom { get; set; }
        public string Remark { get; set; }
        public string UserSystem { get; set; }
    }

    public class EmployeesByLocationCode
    {
        public string LocationID { get; set; }
        public string LocationName { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public System.DateTime JoinningDate { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public string Location { get; set; }
        public string SalesLocation { get; set; }
    }
}