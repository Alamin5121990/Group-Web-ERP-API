using System;

namespace LabaidMIS.Data.Classes
{
    public class AttendanceEmployee
    {
        public string Department { get; set; }
        public string Designation { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime AttendanceDate { get; set; }
        public Nullable<Boolean> IsAbsent { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string Reason { get; set; }
        public string Profileimagename { get; set; }
    }

    public class EmployeeMonthlyAttendance
    {
        public string LogDate { get; set; }
        public Nullable<DateTime> LogInTime { get; set; }
        public Nullable<DateTime> LogOutTime { get; set; }
        public Nullable<int> Duration { get; set; }
    }
}