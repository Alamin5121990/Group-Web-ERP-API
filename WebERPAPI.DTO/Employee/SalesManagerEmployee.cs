using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.Employee
{
    public class SalesManagerEmployee
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> ParentLocationID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> JoinningDate { get; set; }
        public string Designation { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public int OrderNo { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public Boolean IsOpen { get; set; }
    }

    public class SalesManagerEmployeeReport
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public List<SalesManagerEmployee> Employees { get; set; }
        public Boolean IsOpen { get; set; }
    }

    public class EmployeesImage
    {
        public string EmployeeID { get; set; }
        public Byte[] EmployeeImage { get; set; }
    }

    public class SalesManagerOrganizationalChart
    {
        public Nullable<int> LocationID { get; set; }
        public Nullable<int> ParentLocationID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> JoinningDate { get; set; }
        public string Designation { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public string ProfileImagename { get; set; }
        public string SignatureFilename { get; set; }
        public Boolean IsOpen { get; set; }

        public List<EmployeesLastThreeMonthSales> Sales { get; set; }
    }

    public class EmployeesLastThreeMonthSales
    {
        public string EmployeeID { get; set; }
        public int YearNo { get; set; }
        public int MonthNo { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}