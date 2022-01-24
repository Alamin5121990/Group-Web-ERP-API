using System;

namespace LabaidMIS.Data.Classes.IT
{
    public class ServerRunningQueries
    {
        public Nullable<Int16> SessionID { get; set; }
        public Nullable<DateTime> StartTime { get; set; }
        public string Status { get; set; }
        public string CommandType { get; set; }
        public Nullable<Int16> DatabaseID { get; set; }
        public Nullable<int> TotalElapsedTime { get; set; }
        public Nullable<int> CPUTime { get; set; }
        public string SQLQuery { get; set; }
        public int BatchDuration { get; set; }
        public string HostName { get; set; }
        public string LoginName { get; set; }
        public string ProgramName { get; set; }
    }
}