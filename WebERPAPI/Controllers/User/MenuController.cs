using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebERPAPI.DTO;
using WebERPAPI.DTO.IT;
using WebERPAPI.Data.Repository;
using WebERPAPI.BusinessLogic.User;

namespace WebERPAPI.Controllers
{
    [Authorize]
    public class MenuController : ApiController
    {
        private MenuRepositories repo = new MenuRepositories();
        private MenuService service = new MenuService();

        [HttpGet]
        [Route("~/api/user/menu/list")]
        public HttpResponseMessage GetWebMenu()
        {
            try
            {
                var result = repo.getWebMenus();

                List<MenuGroup> menuList = new List<MenuGroup>();

                if (result != null)
                {
                    var groups = result.Where(m => m.ParentMenuId == 0);

                    foreach (var group in groups)
                    {
                        MenuGroup mg = new MenuGroup();

                        mg.MenuID = group.MenuID;
                        mg.MenuName = group.MenuName;
                        //mg.ParentMenuId = group.ParentMenuId;
                        mg.OrderId = group.OrderId;
                        mg.Route = group.Route;
                        mg.CreatedBy = group.CreatedBy;

                        mg.SubMenu = result.Where(m => m.ParentMenuId == mg.MenuID).OrderBy(M => M.MenuName).ToList();

                        menuList.Add(mg);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, menuList);
                }
                else return Request.CreateResponse(HttpStatusCode.OK, repo.error);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpPost]
        [Route("~/api/menu/create/{createdbyid}")]
        public HttpResponseMessage saveMenu([FromBody] WebMenu webmenu, string createdbyid)
        {
            return MISResponse.Return(repo.saveMenu(webmenu, createdbyid), repo.error, Request);
        }

        [HttpPut]
        [Route("~/api/menu/update/{createdbyid}")]
        public HttpResponseMessage updateMenu([FromBody] WebMenu webmenu, string createdbyid)
        {
            return MISResponse.Return(repo.updateMenu(webmenu, createdbyid), repo.error, Request);
        }

        [HttpDelete]
        [Route("~/api/menu/delete/{menuid}/{createdbyid}")]
        public HttpResponseMessage deleteMenu(string menuid, string createdbyid)
        {
            return MISResponse.Return(repo.deleteMenu(menuid, createdbyid), repo.error, Request, "Successfully deleted");
        }

        [HttpGet]
        [Route("~/api/application/menu/list")]
        public HttpResponseMessage GetAppMenuList()
        {
            try
            {
                List<ApplicationMenus> appMenus = new List<ApplicationMenus>();

                var menus = repo.getApplicationMenuList();

                var parentMenus = repo.getParentMenuList();
                var apps = repo.getApplicationList();

                foreach (var app in apps)
                {
                    ApplicationMenus appMenu = new ApplicationMenus();
                    appMenu.ApplicationId = app.ID;
                    appMenu.ApplicationName = app.ApplicationDescription;

                    List<MenuGroup> menuList = new List<MenuGroup>();

                    foreach (var pmenu in parentMenus)
                    {
                        MenuGroup p = new MenuGroup();
                        p.MenuID = pmenu.MenuID;
                        p.MenuName = pmenu.MenuName;
                        p.OrderId = pmenu.OrderId;

                        var submenus = menus.Where(m => m.ParentMenuId == p.MenuID).ToList();
                        List<WebMenu> subMenuList = new List<WebMenu>();

                        foreach (var submenu in submenus)
                        {
                            WebMenu sub = new WebMenu();
                            sub.MenuID = submenu.MenuID;
                            sub.MenuName = submenu.MenuName;
                            sub.ParentMenuId = submenu.ParentMenuId;
                            sub.OrderId = submenu.OrderId;
                            sub.Route = submenu.Route;

                            subMenuList.Add(sub);
                        }

                        p.SubMenu = subMenuList;
                        menuList.Add(p);
                    }

                    appMenu.ParentMenu = menuList;
                    appMenus.Add(appMenu);
                }

                return Request.CreateResponse(HttpStatusCode.OK, appMenus);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/application/menu/list/{appid}")]
        public HttpResponseMessage GetAppMenuList(string appid)
        {
            try
            {
                int AppID = int.Parse(appid);
                var menus = repo.getApplicationMenuList(AppID);
                var parentMenus = repo.getParentMenuList();

                List<MenuGroup> menuList = new List<MenuGroup>();

                foreach (var pmenu in parentMenus)
                {
                    MenuGroup p = new MenuGroup();
                    p.MenuID = pmenu.MenuID;
                    p.MenuName = pmenu.MenuName;
                    p.OrderId = pmenu.OrderId;

                    var submenus = menus.Where(m => m.ParentMenuId == p.MenuID).ToList();
                    List<WebMenu> subMenuList = new List<WebMenu>();

                    foreach (var submenu in submenus)
                    {
                        WebMenu sub = new WebMenu();
                        sub.MenuID = submenu.MenuID;
                        sub.MenuName = submenu.MenuName;
                        sub.ParentMenuId = submenu.ParentMenuId;
                        sub.OrderId = submenu.OrderId;
                        sub.Route = submenu.Route;

                        subMenuList.Add(sub);
                    }

                    p.SubMenu = subMenuList;
                    menuList.Add(p);
                }

                return Request.CreateResponse(HttpStatusCode.OK, menuList);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/user/application/list")]
        public HttpResponseMessage GetApplication()
        {
            return MISResponse.Return(repo.getApplicationList(), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/menu/application/{usercode}")]
        public HttpResponseMessage GetApplication(string UserCode)
        {
            try
            {
                MenuRepositories menurep = new MenuRepositories();
                return Request.CreateResponse(HttpStatusCode.OK, menurep.getUserPrivilegedApplication(UserCode));
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/menu/sub/list/{appid}/{parentmenuid}")]
        public HttpResponseMessage GetSubMenuList(string appid, string parentmenuid)
        {
            try
            {
                MenuRepositories menuRep = new MenuRepositories();
                int ParentMenuId = int.Parse(parentmenuid);
                int AppId = int.Parse(appid);

                List<ApplicationSubMenu> appSub = new List<ApplicationSubMenu>();
                var menus = menuRep.getSubMenuList(ParentMenuId);
                var appMenus = menuRep.getApplicationMenuList(AppId);

                foreach (var menu in menus)
                {
                    ApplicationSubMenu sub = new ApplicationSubMenu();

                    if (appMenus.Where(m => m.MenuID == menu.MenuID).Count() > 0)
                    {
                        sub.ApplicationId = AppId;
                    }
                    else sub.ApplicationId = 0;

                    sub.MenuId = menu.MenuID;
                    sub.MenuName = menu.MenuName;

                    appSub.Add(sub);
                }

                return Request.CreateResponse(HttpStatusCode.OK, appSub);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/menu/list/{userid}")]
        public HttpResponseMessage GetMenuList(string userid)
        {
            try
            {
                int UserID = int.Parse(userid);

                List<ApplicationMenus> appMenus = new List<ApplicationMenus>();

                var menus = repo.getApplicationMenuList();

                var parentMenus = repo.getParentMenuList().OrderBy(p => p.OrderId).ToList();
                var apps = repo.getApplicationList();

                UserRepositories user = new UserRepositories();
                var privileges = user.getUserPrivileges(UserID);

                foreach (var app in apps)
                {
                    // Ignoring application if it has no menu
                    if (privileges.Where(ap => ap.ApplicationID == app.ID).ToList().Count == 0)
                    {
                        continue;
                    }

                    ApplicationMenus appMenu = new ApplicationMenus();
                    appMenu.ApplicationId = app.ID;
                    appMenu.ApplicationName = app.ApplicationName; // app.ApplicationDescription.Replace("Management","").Trim();

                    List<MenuGroup> menuList = new List<MenuGroup>();

                    foreach (var pmenu in parentMenus)
                    {
                        MenuGroup p = new MenuGroup();
                        p.MenuID = pmenu.MenuID;
                        p.MenuName = pmenu.MenuName;
                        p.OrderId = pmenu.OrderId;

                        var submenus = menus.Where(m => m.ApplicationId == app.ID && m.ParentMenuId == p.MenuID).OrderBy(m => m.OrderId).ToList();
                        List<WebMenu> subMenuList = new List<WebMenu>();

                        // Ignoring application if it has no menu
                        if (submenus.Where(m => m.ParentMenuId == p.MenuID).ToList().Count == 0)
                        {
                            continue;
                        }

                        foreach (var submenu in submenus)
                        {
                            var prv = privileges.Where(priv => priv.ApplicationID == app.ID && priv.UserID == UserID && priv.MenuID == submenu.MenuID).FirstOrDefault();
                            var hasPrivilege = false;
                            if (prv != null)
                            {
                                if (
                                    (prv.HasView != null && prv.HasView == true) ||
                                    (prv.HasInsert != null && prv.HasInsert == true) ||
                                    (prv.HasUpdate != null && prv.HasUpdate == true) ||
                                    (prv.HasDelete != null && prv.HasDelete == true) ||
                                    (prv.HasPrint != null && prv.HasPrint == true) ||
                                    (prv.HasFullAccess != null && prv.HasFullAccess == true) || submenu.IsNonPrivilegedMenu == true) hasPrivilege = true;
                            }

                            if (hasPrivilege)
                            {
                                WebMenu sub = new WebMenu();
                                sub.MenuID = submenu.MenuID;
                                sub.MenuName = submenu.MenuName;
                                sub.ParentMenuId = submenu.ParentMenuId;
                                sub.OrderId = submenu.OrderId;
                                sub.Route = submenu.Route;

                                subMenuList.Add(sub);
                            }
                        }

                        p.SubMenu = subMenuList.OrderBy(m => m.OrderId).ToList();
                        menuList.Add(p);
                    }

                    appMenu.ParentMenu = menuList;
                    appMenus.Add(appMenu);
                }

                return Request.CreateResponse(HttpStatusCode.OK, appMenus);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/user/menu/{userid}/{applicationid}")]
        public HttpResponseMessage GetMenuList(int userid, int applicationid)
        {
            return MISResponse.Return(service.getUserMenu(userid, applicationid), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/application/menu/create")]
        public HttpResponseMessage Post([FromBody] ApplicationMenu menus)
        {
            try
            {
                string[] ids = menus.MenuIds.Split(';');
                MenuRepositories menuRepo = new MenuRepositories();

                foreach (string id in ids)
                {
                    if (string.IsNullOrEmpty(id)) continue;

                    string[] st = id.Split(',');
                    if (st[1].CompareTo("1") == 0) menuRepo.saveApplicationMenu(menus.AppId, st[0], true);
                    else menuRepo.saveApplicationMenu(menus.AppId, st[0], false);
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Successfully saved");
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/menu/privileged/user/{menuid}")]
        public HttpResponseMessage getWebMenuPrivilegedUser(int menuid)
        {
            return MISResponse.Return(repo.getWebMenuPrivilegedUser(menuid), repo.error, Request);
        }

        [HttpDelete]
        [Route("~/api/delete/user/privilege/{menuid}/{userid}")]
        public HttpResponseMessage getWebMenuPrivilegedUser(int menuid, int userid)
        {
            return MISResponse.Return(repo.deleteUserPrivilege(menuid, userid), repo.error, Request, "Successfully deleted privilege");
        }

        [HttpPost]
        [Route("~/api/user/privilege/check")]
        public HttpResponseMessage getWebMenuPrivilegedUser([FromBody] UserRequestPrivilege urp)
        {
            //System.Threading.Thread.Sleep(5000);
            return MISResponse.Return(service.HasUserThisMenuPrivilege(urp), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/privilege/menu/list/{userid}")]
        public HttpResponseMessage getUserPrivilegedMenuList(int userid)
        {
            return MISResponse.Return(repo.getUserPrivilegedMenuNameList(userid), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/menu/favorite/update")]
        public HttpResponseMessage saveUserFavoriteMenu([FromBody] UserFavoriteMenuData menus)
        {
            try
            {
                string jsonString = Library.JSONSerialize.DecodeBase64(menus.Data);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<UserFavoriteMenuList> logs = ser.Deserialize<List<UserFavoriteMenuList>>(jsonString);

                int x = 0;

                foreach (UserFavoriteMenuList menu in logs)
                {
                    MenuRepositories emps = new MenuRepositories();
                    if (x == 0) emps.deleteExistingFavoriteMenu(menu.UserID);
                    emps.saveUserFavoriteMenu(menu.MenuID, menu.UserID);
                    x++;
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Successfully saved");
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/user/new/privilege/list/{userid}")]
        public HttpResponseMessage getUserPrivilegeNewList(string userid)
        {
            try
            {
                UserRepositories repo = new UserRepositories();
                return MISResponse.Return(repo.getUserPrivilegeNewList(userid), repo.error, Request);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }
    }
}