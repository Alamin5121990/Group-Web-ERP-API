using System;

namespace WebERPAPI.DTO.Employee
{
    public class SalesLocationEmployees
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }

        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<decimal> STPercent { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }

        public string Department { get; set; }
        public string Designation { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
    }
}