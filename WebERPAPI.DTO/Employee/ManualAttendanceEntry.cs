using System;

namespace WebERPAPI.DTO.Employee
{
    public class ManualAttendanceEntry
    {
        public string EmployeeID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public Boolean IsAbsent { get; set; }
        public string Reason { get; set; }
        public string LogIn { get; set; }
        public string LogOut { get; set; }

        public string CreatedByID { get; set; }
    }
}