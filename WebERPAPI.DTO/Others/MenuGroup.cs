using System;
using System.Collections.Generic;

namespace WebERPAPI.DTO
{
    public class MenuGroup
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int ParentMenuId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string Route { get; set; }
        public string CreatedBy { get; set; }
        public List<WebMenu> SubMenu { get; set; }
    }

    public class MenuGroupDto
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int ParentMenuId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string Route { get; set; }
        public string CreatedBy { get; set; }
        public List<WebMenuDto> SubMenu { get; set; }
        public Nullable<int> GroupID { get; set; }
    }
}