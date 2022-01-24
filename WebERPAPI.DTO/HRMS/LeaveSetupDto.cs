using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    public class LeaveSetupDto
    {
        public string EmployeeID { get; set; }

        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public Nullable<DateTime> DOJ { get; set; }
        public Nullable<int> WorkingDays { get; set; }

        public Nullable<int> WorkedDays { get; set; }
        public Nullable<int> LeaveYear { get; set; }
        public string LeaveRuleID { get; set; }
        public string LeaveTypeID { get; set; }
        public Nullable<decimal> AllocatedDays { get; set; }

        public Nullable<decimal> Availed { get; set; }
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public string PurposeOfLeave { get; set; }
    }
}