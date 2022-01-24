using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.SystemManager
{
   public class WebMenuPrivilegeGroupDTO
    {
        public int ID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public string DesignationName { get; set; }
        public Nullable<int> MenuID { get; set; }
        public string MenuName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedByID { get; set; }
    }
}
