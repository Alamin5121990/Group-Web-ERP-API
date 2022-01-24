using System;

namespace WebERPAPI.DTO.Maintenance
{
    public class DataValidationProduct
    {
        public Nullable<decimal> SuccessPercent { get; set; }
    }

    public class DataValidation
    {
        public string Item { get; set; }
        public Nullable<decimal> SuccessPercent { get; set; }
    }

    public class UserMenuBrowsingHistory
    {
        public Nullable<int> UserID { get; set; }
        public string EmployeeName { get; set; }
        public string MenuName { get; set; }
        public string AppName { get; set; }
        public string Route { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string EmployeeId { get; set; }
        public Nullable<int> TotalRequest { get; set; }
        public Nullable<DateTime> LastRequestOn { get; set; }
        public string DeviceDetails { get; set; }
        public string LocationDetails { get; set; }
        public Nullable<int> TotalDevice { get; set; }

        public string AppVersion { get; set; }
        public Nullable<Boolean> IsUserOnline { get; set; }
    }
}