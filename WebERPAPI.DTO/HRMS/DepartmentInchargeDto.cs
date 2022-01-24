using System;

namespace WebERPAPI.DTO.HRMS
{
    public class DepartmentInchargeDto
    {
        public Nullable<int> DepartmentID { get; set; }
        public string InchargeEmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
    }
}