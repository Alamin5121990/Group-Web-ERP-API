using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
  public  class EmployeeEvaluationReportDto
    {
		public string EmployeeID { get; set; }

		public string EmployeeName { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public string Location { get; set; }
		public Nullable<DateTime> DOJ { get; set; }

		public string ServiceLength { get; set; }
		public Nullable<decimal> Gross { get; set; }
		public string GradeCode { get; set; }
		public string ReportLevel { get; set; }

		public Nullable<DateTime> LastIncrementDate { get; set; }
		public string LastIncrementType { get; set; }
		public Nullable<decimal> LastIncrementAmount { get; set; }
		public Nullable<DateTime> ConfirmationDueDate { get; set; }
        public bool IsEligible { get; set; }
		public Nullable<Boolean> IsConfirmationEligible { get; set; }
	}
}
