using System;

namespace WebERPAPI.DTO.Maintenance
{
    public class UserActivitiesDetails
    {
        public Nullable<DateTime> CreatedOn { get; set; }

        public string ActivityDescription { get; set; }
        public string ModuleCode { get; set; }
        public string MaterialCode { get; set; }
        public string ProductCode { get; set; }
        public string SupplierCode { get; set; }

        public string MaterialName { get; set; }
        public string SupplierName { get; set; }
        public string ProductName { get; set; }
        public string URL { get; set; }
        public string EmployeeID { get; set; }

        public string EmployeeName { get; set; }
    }
}