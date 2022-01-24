namespace WebERPAPI.DTO
{
    public class ManualAttendance
    {
        public string Department { get; set; }
        public string Designation { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public System.DateTime AttendanceDate { get; set; }
        public string IsAbsent { get; set; }
        public string Reason { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }
        public string AddedBy { get; set; }
    }
}