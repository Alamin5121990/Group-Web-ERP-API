using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.DTO.User
{
    public class MenuListByDeptIDAndDesigIDDto
    {
        public Nullable<int> ID { get; set; }

        public Nullable<int> DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<int> DesignationID { get; set; }
        public string DesignationName { get; set; }
        public Nullable<int> MenuID { get; set; }

        public string MenuName { get; set; }
        public Nullable<int> ParentMenuId { get; set; }

        public Nullable<bool> HasView { get; set; }
        public Nullable<bool> HasInsert { get; set; }
        public Nullable<bool> HasUpdate { get; set; }
        public Nullable<bool> HasDelete { get; set; }
        public Nullable<bool> HasPrint { get; set; }
        public Nullable<bool> HasReview { get; set; }
        public Nullable<bool> HasVerify { get; set; }
        public Nullable<bool> HasRecommendation { get; set; }
        public Nullable<bool> HasApprove { get; set; }
        public Nullable<bool> HasFullAccess { get; set; }
    }

}
