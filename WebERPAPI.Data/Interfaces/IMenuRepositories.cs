using System.Collections.Generic;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.IT;
using WebERPAPI.DTO.User;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository
{
    public interface IMenuRepositories
    {
        bool deleteExistingFavoriteMenu(int UserID);

        bool deleteMenu(string MenuId, string CreatedbyId);

        bool deleteUserPrivilege(int MenuID, int UserID);

        List<Web_Applications> getApplicationList();

        List<v_WebApplicationMenus> getApplicationMenuList();

        List<v_WebApplicationMenus> getApplicationMenuList(int ApplicationID);

        List<Web_Menus> getMenuList();

        int getNewMenuOrderNo();

        List<Web_Menus> getParentMenuList();

        List<ServerRunningQueries> getServerRunningQueries();

        List<Web_Menus> getSubMenuList(int ParentMenuID);

        List<UserApplication> getUserPrivilegedApplication(string UserCode);

        List<UserMenu> getUserPrivilegedMenuList(string UserCode);

        List<UserPrivilegedMenuList> getUserPrivilegedMenuNameList(int UserID);

        List<MenuPrivilegedUser> getWebMenuPrivilegedUser(int MenuID);

        List<WebMenu> getWebMenus();

        List<WebMenuAndRequest> getWebMenusWithRequest();

        UserMenuPrivilegeDetails HasUserThisMenuPrivilege(UserRequestPrivilege details);

        bool saveApplicationMenu(string ApplicationId, string MenuId, bool saveNew);

        bool saveMenu(WebMenu menu, string CreatedbyId);

        bool saveUserFavoriteMenu(int MenuID, int UserID);

        bool updateMenu(WebMenu menu, string CreatedbyId);
    }
}