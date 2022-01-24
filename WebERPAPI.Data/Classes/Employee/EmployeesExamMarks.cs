using System;

namespace LabaidMIS.Data.Classes.Employee
{
    public class EmployeesExamMarks
    {
        public Nullable<int> ID { get; set; }
        public Nullable<int> ExamID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<decimal> PKETMarks { get; set; }
        public Nullable<decimal> DetailingScore { get; set; }
        public string AddedBy { get; set; }
        public Nullable<DateTime> DateAdded { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<DateTime> DateUpdated { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
    }
}