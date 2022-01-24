using System;

namespace WebERPAPI.DTO.Employee
{
    public class EmployeeManualAttendanceDetails
    {
        public Nullable<DateTime> AttendanceDate { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<Boolean> IsAbsent { get; set; }
        public string Reason { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string AddedBy { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}