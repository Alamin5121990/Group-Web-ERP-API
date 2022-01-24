using System.Collections.Generic;

namespace WebERPAPI.DTO
{
    public class ApplicationMenus
    {
        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public List<MenuGroup> ParentMenu { get; set; }
    }

    public class ApplicationSubMenu
    {
        public int ApplicationId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
    }
}