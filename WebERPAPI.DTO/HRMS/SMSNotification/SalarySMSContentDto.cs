using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS.SMSNotification
{
   public class SalarySMSContentDto
    {
        public int ID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
		public string Department { get; set; }
		public string Mobile { get; set; }
		public string Location { get; set; }
		public string SMSContent { get; set; }
	}

	public class SMSNotificationMasterDto
	{
		public Nullable<int> ID { get; set; }

		public Nullable<int> YearNo { get; set; }
		public Nullable<int> MonthNo { get; set; }
		public string Title { get; set; }
		public Nullable<int> NotificationCategoryID { get; set; }
		public string CategoryName { get; set; }

		public Nullable<int> CreatedByID { get; set; }
		public Nullable<DateTime> CreatedOn { get; set; }
		public string EmployeeID { get; set; }
		public string EmployeeName { get; set; }
		public string Designation { get; set; }

		public string Department { get; set; }
		public Nullable<int> IsSMSSent { get; set; }
	}

}
