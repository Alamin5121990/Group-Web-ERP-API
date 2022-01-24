using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.IT;
using WebERPAPI.DTO.User;
using WebERPAPI.Data.Models.PROCESSERVER;
using WebERPAPI.Data.GenericRepository;

namespace WebERPAPI.Data.Repository
{
    public class MenuRepositories : IMenuRepositories
    {
        public Exception error = new Exception();
        private SystemManagerGenericRepository<Web_Menus> _menu = null;

        public MenuRepositories()
        {
            _menu = new SystemManagerGenericRepository<Web_Menus>();
        }

        public List<WebMenu> getWebMenus()
        {
            try
            {
                List<WebMenu> apps;
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    apps = db.Database.SqlQuery<WebMenu>("getWebMenus").ToList();
                }

                return apps;
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<WebMenuAndRequest> getWebMenusWithRequest()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<WebMenuAndRequest>("getWebMenusWithRequest").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean saveMenu(WebMenu menu, string CreatedbyId)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var webMenu = new Web_Menus();

                    webMenu.MenuName = menu.MenuName;
                    webMenu.ParentMenuId = menu.ParentMenuId;
                    webMenu.Route = menu.Route;
                    webMenu.ShowingStatus = true;
                    webMenu.OrderId = menu.OrderId;
                    webMenu.CreatedById = int.Parse(CreatedbyId);
                    webMenu.Createdon = DateTime.Now;
                    webMenu.OrderId = getNewMenuOrderNo();
                    db.Web_Menus.Add(webMenu);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public int getNewMenuOrderNo()
        {
            try
            {
                int orderNO = 99;

                return orderNO;
            }
            catch
            {
                return 99;
            }
        }

        public Boolean updateMenu(WebMenu menu, string CreatedbyId)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var webMenu = db.Web_Menus.Find(menu.MenuID);

                    webMenu.MenuName = menu.MenuName;
                    webMenu.ParentMenuId = menu.ParentMenuId;
                    webMenu.Route = menu.Route;
                    webMenu.OrderId = menu.OrderId;
                    webMenu.ShowingStatus = true;
                    webMenu.UpdatedById = int.Parse(CreatedbyId);
                    webMenu.Updatedon = DateTime.Now;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean deleteMenu(string MenuId, string CreatedbyId)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    int menuid = int.Parse(MenuId);
                    var webMenu = db.Web_Menus.Where(m => m.MenuID == menuid).FirstOrDefault();

                    webMenu.ShowingStatus = false;
                    webMenu.UpdatedById = int.Parse(CreatedbyId);
                    webMenu.Updatedon = DateTime.Now;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public bool killServerSession(int SessionID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var sessionID = new SqlParameter("@SessionID", SessionID);
                    db.Database.ExecuteSqlCommand("killServerSession @SessionID", sessionID);
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public List<UserApplication> getUserPrivilegedApplication(string UserCode)
        {
            try
            {
                var usercode = new SqlParameter("@UserCode", UserCode);

                List<UserApplication> apps;
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    apps = db.Database.SqlQuery<UserApplication>("getUserPrivilegedApplication @UserCode", usercode).ToList();
                }

                return apps;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UserMenu> getUserPrivilegedMenuList(string UserCode)
        {
            try
            {
                var usercode = new SqlParameter("@UserCode", UserCode);

                List<UserMenu> apps;
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    apps = db.Database.SqlQuery<UserMenu>("getUserPrivilegedMenu @UserCode", usercode).ToList();
                }

                return apps;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Web_Menus> getMenuList()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Web_Menus.Where(m => m.ShowingStatus == true).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<Web_Menus> getParentMenuList()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Web_Menus.Where(m => m.ParentMenuId == 0 && m.ShowingStatus == true).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<Web_Menus> getSubMenuList(int ParentMenuID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Web_Menus.Where(m => m.ParentMenuId == ParentMenuID && m.ShowingStatus == true).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<Web_Applications> getApplicationList()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Web_Applications.OrderBy(a => a.OrderNo).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<v_WebApplicationMenus> getApplicationMenuList()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<v_WebApplicationMenus>("select * from v_WebApplicationMenus").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<v_WebApplicationMenus> getApplicationMenuList(int ApplicationID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.v_WebApplicationMenus.Where(m => m.ApplicationId == ApplicationID).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean saveApplicationMenu(string ApplicationId, string MenuId, Boolean saveNew)
        {
            try
            {
                var appID = new SqlParameter("@ApplicationId", ApplicationId);
                var menuID = new SqlParameter("@MenuId", MenuId);
                int action = 0;
                if (saveNew) action = 1;

                var actionID = new SqlParameter("@ActionID", action);

                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    db.Database.ExecuteSqlCommand("saveApplicationMenu  @ApplicationId, @MenuId, @ActionID", appID, menuID, actionID);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<MenuPrivilegedUser> getWebMenuPrivilegedUser(int MenuID)
        {
            try
            {
                var menuid = new SqlParameter("@MenuID", MenuID);
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<MenuPrivilegedUser>("getWebMenuPrivilegedUser @MenuID", menuid).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean deleteUserPrivilege(int MenuID, int UserID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var menuPrivilege = db.Web_UserPrivileges.Where(m => m.MenuId == MenuID && m.UserId == UserID).FirstOrDefault();
                    db.Web_UserPrivileges.Remove(menuPrivilege);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public UserMenuPrivilegeDetails HasUserThisMenuPrivilege(UserRequestPrivilege details)
        {
            return new SystemManagerGenericRepository<UserMenuPrivilegeDetails>().FindOneUsingSP("hasUserThisMenuPrivilege @UserID, @Route, @AppVersion",
                   new SqlParameter("@UserID", details.UserID), new SqlParameter("@Route", details.Route), new SqlParameter("@AppVersion", details.AppVersion));
        }

        public List<UserPrivilegedMenuList> getUserPrivilegedMenuNameList(int UserID)
        {
            try
            {
                var userid = new SqlParameter("@UserID", UserID);

                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<UserPrivilegedMenuList>("getUserPrivilegedMenuList @UserID", userid).ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public Boolean saveUserFavoriteMenu(int MenuID, int UserID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var favMenu = db.Web_UserFavoriteMenus.Where(m => m.UserID == UserID && m.MenuID == MenuID).FirstOrDefault();
                    if (favMenu == null)
                    {
                        Web_UserFavoriteMenus fav = new Web_UserFavoriteMenus();
                        fav.MenuID = MenuID;
                        fav.UserID = UserID;
                        fav.UpdatedOn = DateTime.Now;
                        db.Web_UserFavoriteMenus.Add(fav);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public Boolean deleteExistingFavoriteMenu(int UserID)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    var favoriteMenus = db.Web_UserFavoriteMenus.Where(m => m.UserID == UserID);
                    db.Web_UserFavoriteMenus.RemoveRange(favoriteMenus);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false;
            }
        }

        public List<ServerRunningQueries> getServerRunningQueries()
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.Database.SqlQuery<ServerRunningQueries>("getServerRunningQueries").ToList();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public List<UserMenuDto> getUserMenu(int UserID, int ApplicationID)
        {
            int ModuleOnly = 0;
            return new SystemManagerGenericRepository<UserMenuDto>().FindUsingSP("getUserMenu @UserID, @ApplicationID, @ModuleOnly",
                new SqlParameter("@UserID", UserID), new SqlParameter("@ApplicationID", ApplicationID), new SqlParameter("@ModuleOnly", ModuleOnly));
        }

        public List<UserModulesDto> getUserModules(int UserID, int ApplicationID)
        {
            int ModuleOnly = 1;
            return new SystemManagerGenericRepository<UserModulesDto>().FindUsingSP("getUserMenu @UserID, @ApplicationID, @ModuleOnly",
                new SqlParameter("@UserID", UserID), new SqlParameter("@ApplicationID", ApplicationID), new SqlParameter("@ModuleOnly", ModuleOnly));
        }
    }
}