using System;

namespace LabaidMIS.Data.Classes.Employee
{
    public class EmployeeExam
    {
        public Nullable<int> ExamID { get; set; }
        public string ExamName { get; set; }
        public Nullable<int> ExamType { get; set; }
        public Nullable<DateTime> ExamDate { get; set; }
        public Nullable<int> ExamVenueID { get; set; }
        public Nullable<decimal> TotalMarks { get; set; }
        public Nullable<decimal> PassMark { get; set; }
        public string EmployeeID { get; set; }
    }

    public class EmployeeExamMarks
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
    }

    public class EmployeeExamData
    {
        public int ExamID { get; set; }
        public string EmployeeID { get; set; }
        public string Data { get; set; }
    }
}