using System;

namespace LabaidMIS.Data.Classes.IT
{
    public class MISDatabaseInfo
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public Nullable<decimal> DataFileSizeMB { get; set; }
        public Nullable<decimal> LogFileSizeMB { get; set; }
    }
}