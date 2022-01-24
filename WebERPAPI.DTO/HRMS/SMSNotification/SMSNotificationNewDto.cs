using System;

namespace WebERPAPI.DTO.HRMS.SMSNotification
{
    public class SMSNotificationNewDto : BaseEntityNew
	{
		public Nullable<int> YearNo { get; set; }
		public Nullable<int> MonthNo { get; set; }
		public string Title { get; set; }
		public Nullable<int> NotificationCategoryID { get; set; }
        public string NotificationDetailsNewDto { get; set; }
    }

}
