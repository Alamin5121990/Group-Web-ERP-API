using System;

namespace WebERPAPI.DTO.Employee
{
    public class EmployeesExamMarkDto
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> ExamID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string EmployeeID { get; set; }
        public Nullable<decimal> PKETMarks { get; set; }
        public Nullable<decimal> DetailingScore { get; set; }
        public Nullable<int> CreatedByID { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
        public string EmployeeName { get; set; }

        public string Designation { get; set; }
        public string Mobile { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
    }

    public class Employee_ExamDto
    {
        public int ExamID { get; set; }
        public int EmpID { get; set; }
        public string Details { get; set; }
    }
}