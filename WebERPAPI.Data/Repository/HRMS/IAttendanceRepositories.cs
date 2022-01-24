using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;

namespace WebERPAPI.Data.Repository
{
    public interface IAttendanceRepositories
    {
        List<EmployeeAttendanceReport> getAttendanceEmployeeDetails(string EmployeeID, string FromDate, string ToDate);

        List<AttendanceEmployee> getAttendanceEmployeeList(string UserCode, string AttendanceDate);

        List<EmployeeMonthlyAttendance> getEmployeeMonthlyAttendance(string EmployeeID, string DateFrom, string DateTo);

        List<EmployeesDayAttendance> getEmployeesAttendance(string FromDate);

        List<AttendanceEmployee> getOfficeAttendanceEmployeeList(string LocationID, string AttendanceDate);

        List<OfficeEmployeeAttendanceData> getOfficeEmployeeMonthlyAttendance(string LocationID, string EmployeeID, string DateFrom, string DateTo);

        bool saveEmployeeManualAttendance(ManualAttendanceEntry attendance);

        bool saveManualAttendance(ManualAttendance attendance, string createdby);
    }
}