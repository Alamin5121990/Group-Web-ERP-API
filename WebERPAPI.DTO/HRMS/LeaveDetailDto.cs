using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
   public class LeaveDetailDto
    {
		public string LeaveTranID { get; set; }

		public Nullable<int> LeaveYear { get; set; }
		public string EmployeeID { get; set; }
		public Nullable<DateTime> ApplicationDate { get; set; }
		public string PurposeOfLeave { get; set; }
		public string LeaveAddress { get; set; }

		public string ApprovalStatus { get; set; }
		public string Comments { get; set; }
		public Nullable<Boolean> Transfered { get; set; }
		public string AddedBy { get; set; }
		public Nullable<DateTime> DateAdded { get; set; }

		public string UpdatedBy { get; set; }
		public Nullable<DateTime> DateUpdated { get; set; }
		public string LeaveTypeID { get; set; }

		public Nullable<DateTime> FromDate { get; set; }
		public Nullable<DateTime> ToDate { get; set; }
		public Nullable<Boolean> ManualCalculation { get; set; }
		public Nullable<decimal> Duration { get; set; }
		public string Remark { get; set; }
	}
}
