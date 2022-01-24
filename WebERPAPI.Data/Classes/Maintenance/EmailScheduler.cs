using System;

namespace LabaidMIS.Data.Classes.Maintenance
{
    public class EmailSchedulerNew
    {
        public int ScheduleID { get; set; }
        public string ScheduleName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public string URL { get; set; }
        public string TagName { get; set; }
        public string AttachmentFilename { get; set; }

        public string EmailRecipients { get; set; }

        public Boolean IsDaily { get; set; }
        public Boolean IsWeekly { get; set; }
        public Boolean IsMonthly { get; set; }
        public Boolean Satureday { get; set; }
        public Boolean Sunday { get; set; }
        public Boolean Monday { get; set; }
        public Boolean Tuesday { get; set; }
        public Boolean Wednesday { get; set; }
        public Boolean Thursday { get; set; }
        public Boolean Friday { get; set; }
        public Byte Hour1 { get; set; }
        public Byte Hour2 { get; set; }
        public Byte Hour3 { get; set; }

        public string CreatedByID { get; set; }
    }

    public class EmailSchedulerReport
    {
        public Nullable<int> ID { get; set; }
        public string ScheduleName { get; set; }
        public string EmailSubject { get; set; }
        public string EmailContent { get; set; }
        public string URL { get; set; }
        public string TagName { get; set; }
        public string AttachmentFilename { get; set; }

        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
    }
}