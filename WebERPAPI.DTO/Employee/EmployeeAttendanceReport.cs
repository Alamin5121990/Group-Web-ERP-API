using System;

namespace WebERPAPI.DTO.Employee
{
    public class EmployeeAttendanceReport
    {
        public string CompanyID { get; set; }
        public Nullable<System.DateTime> ATTDate { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> INTIME { get; set; }
        public Nullable<System.DateTime> OUTTIME { get; set; }
        public string AttStatus { get; set; }
        public string DTime { get; set; }
        public string Remark { get; set; }
    }

    public class EmployeesDayAttendance
    {
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public System.DateTime LogIn { get; set; }
        public System.DateTime LogOut { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<int> MachineUserID { get; set; }
        public string BadgeNumber { get; set; }
    }

    public class EmployeesAttendanceReport
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ProfileImagename { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public Boolean IsAbsent { get; set; }
        public Nullable<DateTime> AttendanceDate { get; set; }
        public string LogIn { get; set; }
        public string LogOut { get; set; }
    }

    public class OfficeAttendanceReport
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ProfileImagename { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalPresent { get; set; }
    }

    public class OfficeEmployeeAttendanceData
    {
        public string EmployeeID { get; set; }
        public Nullable<DateTime> AttendanceDate { get; set; }
        public Nullable<Boolean> IsAbsent { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string Reason { get; set; }
    }
}