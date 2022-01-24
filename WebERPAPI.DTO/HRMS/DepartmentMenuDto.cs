using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.HRMS
{
    public class DepartmentMenuDto
    {
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> MenuID { get; set; }

        public string MenuName { get; set; }
        public string Route { get; set; }
        public Nullable<int> OrderId { get; set; }
    }
}