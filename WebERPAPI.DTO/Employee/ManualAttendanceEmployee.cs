using System;

namespace WebERPAPI.DTO.Employee
{
    public class ManualAttendanceEmployee
    {
        public string EmployeeCode { get; set; }
        public Boolean SelectionStatus { get; set; }
    }

    public class ManualAttendanceEmployeeData
    {
        public string Data { get; set; }
        public string CreatedBy { get; set; }
    }
}