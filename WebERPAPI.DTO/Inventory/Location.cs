using System;

namespace WebERPAPI.DTO.Inventory
{
    public class Locations
    {
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
    }

    public class DepotAndSalesLocationMappingList
    {
        public Nullable<int> DepotLocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string EmployeeID { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string ProfileImagename { get; set; }
        public string Mobile { get; set; }
        public Nullable<DateTime> JoinningDate { get; set; }
    }

    public class SalesLocations
    {
        public Nullable<int> RegionID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string ParentLocationCode { get; set; }
        public string ParentLocationName { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public Nullable<decimal> STPercent { get; set; }
        public Boolean IsSelected { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public Nullable<DateTime> JoiningDate { get; set; }
        public Nullable<int> EmpID { get; set; }
    }

    public class DailyTargetForecastDto
    {
        public Nullable<int> ID { get; set; }

        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string EmployeeID { get; set; }
        public string RM { get; set; }
        public string Mobile { get; set; }

        public Nullable<DateTime> InvoiceDate { get; set; }
        public Nullable<decimal> InLac { get; set; }
        public Nullable<decimal> TargetValue { get; set; }
        public Nullable<decimal> SalesValue { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<DateTime> UpdatedOn { get; set; }
    }

    public class DepotAndSalesLocationMappingData
    {
        public string Data { get; set; }
    }
}