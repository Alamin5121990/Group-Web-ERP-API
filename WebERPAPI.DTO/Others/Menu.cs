namespace WebERPAPI.DTO
{
    public class UserMenu
    {
        public int ApplicationID { get; set; }
        public int MenuID { get; set; }
        public string DisplayMember { get; set; }
        public int ParentID { get; set; }
        public string MenuType { get; set; }
        public string Route { get; set; }
    }

    public class UserRequestPrivilege
    {
        public int UserID { get; set; }
        public string Route { get; set; }
        public string AppVersion { get; set; }
    }

    public class UserPrivilegedMenuList
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
    }

    public class UserFavoriteMenuList
    {
        public int MenuID { get; set; }
        public int UserID { get; set; }
    }

    public class UserFavoriteMenuData
    {
        public string Data { get; set; }
    }
}