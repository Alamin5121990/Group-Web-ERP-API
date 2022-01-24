using System;

namespace WebERPAPI.DTO.HRMS
{
    public class DepartmentDto
    {
        public Nullable<int> DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string ShortName { get; set; }
    }
}