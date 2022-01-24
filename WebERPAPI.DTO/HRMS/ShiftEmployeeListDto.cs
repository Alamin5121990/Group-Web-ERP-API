using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    public class ShiftEmployeeListDto
    {
        public Nullable<int> EmpId { get; set; }

        public string EmployeeID { get; set; }
        public Nullable<int> UserId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> JoinningDate { get; set; }
        public string BloodGroup { get; set; }
        public string EmployeeCode { get; set; }
    }
}