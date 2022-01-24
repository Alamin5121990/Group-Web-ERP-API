using System;
using WebERPAPI.DTO.Employee;

namespace WebERPAPI.Data.Repository.HRMS
{
    public interface IEmployeeRepositories
    {
        bool saveManualAttendanceEmployee(string EmployeeCode, string CreatedByID, bool SelectionStatus);

    }
}