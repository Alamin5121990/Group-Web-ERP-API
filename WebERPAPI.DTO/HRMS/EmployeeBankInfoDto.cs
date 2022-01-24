using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
	public class EmployeeEvaluationDto
	{
		public string EmployeeID { get; set; }

		public string EmployeeName { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public Nullable<DateTime> DOJ { get; set; }
		public string ServiceLength { get; set; }
		public string Location { get; set; }
		public Nullable<decimal> Gross { get; set; }
		public string GradeCode { get; set; }
		public Nullable<DateTime> EffectDate { get; set; }
		public string PaymentType { get; set; }
		public string BankID { get; set; }

		public string BankName { get; set; }
		public string BranchID { get; set; }
		public string BranchName { get; set; }
		public string BranchAddress { get; set; }
		public string AccountNo { get; set; }
		public string ReportLevel { get; set; }

		public string Mobile { get; set; }
		public string Email { get; set; }
		public bool IsEligible { get; set; }
		public string ConfirmationStatus { get; set; }
		public string EmployeeStatus { get; set; }
		public string EmployeeType { get; set; }
		public Nullable<Boolean> IsConfirmationEligible { get; set; }

	}
	public class EmployeeBankInfoDto
    {
		public string EmployeeID { get; set; }

		public string EmployeeName { get; set; }
		public string Designation { get; set; }
		public string Department { get; set; }
		public Nullable<DateTime> DOJ { get; set; }
		public string ServiceLength { get; set; }
        public string Location { get; set; }
        public Nullable<decimal> Gross { get; set; }
		public string GradeCode { get; set; }
		public Nullable<DateTime> EffectDate { get; set; }
		public string PaymentType { get; set; }
		public string BankID { get; set; }

		public string BankName { get; set; }
		public string BranchID { get; set; }
		public string BranchName { get; set; }
		public string BranchAddress { get; set; }
		public string AccountNo { get; set; }

		public string Mobile { get; set; }
		public string Email { get; set; }


	}
}
