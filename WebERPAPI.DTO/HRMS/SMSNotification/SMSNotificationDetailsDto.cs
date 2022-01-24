using System;

namespace WebERPAPI.DTO.HRMS.SMSNotification
{
    public class SMSNotificationDetailsDto
    {
		public Nullable<int> ID { get; set; }

		public Nullable<int> SMSNotificationID { get; set; }
		public Nullable<int> BatchNo { get; set; }
		public Nullable<int> EmployeeID { get; set; }
		public string EmployeeName { get; set; }
		public string SMSContent { get; set; }
		public string Mobile { get; set; }
		public Nullable<DateTime> ScheduleDate { get; set; }
		public Nullable<Boolean> IsSent { get; set; }
		public Nullable<int> CreatedByID { get; set; }
		public string CreatedByName { get; set; }
	}
}
