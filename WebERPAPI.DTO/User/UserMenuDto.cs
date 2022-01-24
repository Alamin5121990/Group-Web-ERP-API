using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO.User
{
    public class UserMenuDto
    {
        public Nullable<int> MenuID { get; set; }

        public string MenuName { get; set; }
        public string Route { get; set; }
        public Nullable<int> ModuleID { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public string ParentMenuName { get; set; }

        public Nullable<int> ParentOrderNo { get; set; }
        public Nullable<int> MenuOrderNo { get; set; }
    }

    public class UserModulesAndMenus
    {
        public Nullable<int> ID { get; set; }

        public string ModuleName { get; set; }
        public string ShortName { get; set; }
        public Nullable<int> OrderNo { get; set; }

        public List<UserParentMenuDto> ParentMenus { get; set; }
    }

    public class UserParentMenuDto
    {
        public Nullable<int> ParentMenuId { get; set; }
        public string ParentMenuName { get; set; }
        public Nullable<int> ParentOrderNo { get; set; }

        public List<UserMenuDto> Menus { get; set; }
    }
}