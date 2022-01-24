using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    public class EmployeeGrossSalaryDto
    {
        public string employeeid { get; set; }

        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string DOJ { get; set; }
        public string JobLocation { get; set; }
        public string RegionName { get; set; }

        public Nullable<decimal> GrossSalary { get; set; }
    }
}