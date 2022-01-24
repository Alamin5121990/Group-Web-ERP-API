using System.Collections.Generic;

namespace WebERPAPI.DTO.HRMS
{
    public class DepartmentAndMenuMapDto
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public List<DepartmentInchargeDto> Inchange { get; set; }
        public List<DepartmentMenuDto> Menus { get; set; }
    }
}