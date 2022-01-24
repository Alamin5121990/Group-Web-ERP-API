using System;

namespace WebERPAPI.DTO.IT
{
    public class ErrorLogs
    {
        public string Route { get; set; }
        public string ExceptionTitle { get; set; }
        public string ExceptionDetails { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<Boolean> IsSolved { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }

        public string AppName { get; set; }
    }
}