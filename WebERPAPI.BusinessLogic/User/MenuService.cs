using System;
using System.Collections.Generic;
using System.Linq;
using WebERPAPI.Data.Repository;
using WebERPAPI.DTO;
using WebERPAPI.DTO.User;

namespace WebERPAPI.BusinessLogic.User
{
    public class MenuService
    {
        public Exception Error = new Exception();
        private MenuRepositories repo = new MenuRepositories();

        public List<UserModulesAndMenus> getUserMenu(int UserID, int ApplicationID)
        {
            try
            {
                List<UserModulesAndMenus> report = new List<UserModulesAndMenus>();

                List<UserMenuDto> menus = repo.getUserMenu(UserID, ApplicationID);
                List<UserModulesDto> modules = repo.getUserModules(UserID, ApplicationID);

                // APPLICATION MODULES
                foreach (UserModulesDto module in modules)
                {
                    UserModulesAndMenus rpt = new UserModulesAndMenus();

                    rpt.ID = module.ID;
                    rpt.ModuleName = module.ModuleName;
                    rpt.ShortName = module.ShortName;
                    rpt.OrderNo = module.OrderNo;

                    // MODULE PARENT MENUS
                    List<UserParentMenuDto> parentMenus = menus.Where(m => m.ModuleID == module.ID).GroupBy(m => m.ParentMenuId).Select(m => new UserParentMenuDto
                    {
                        ParentMenuId = m.FirstOrDefault().ParentMenuId,
                        ParentMenuName = m.FirstOrDefault().ParentMenuName,
                        ParentOrderNo = m.FirstOrDefault().ParentOrderNo
                    }).ToList();

                    rpt.ParentMenus = new List<UserParentMenuDto>();

                    // MENUS
                    foreach (UserParentMenuDto parentmenu in parentMenus)
                    {
                        parentmenu.Menus = new List<UserMenuDto>();

                        var pmenus = menus.Where(m => m.ModuleID == module.ID && m.ParentMenuId == parentmenu.ParentMenuId);
                        parentmenu.Menus.AddRange(pmenus);
                    }

                    rpt.ParentMenus.AddRange(parentMenus);

                    report.Add(rpt);
                }

                return report;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }

        public UserMenuPrivilegeDetails HasUserThisMenuPrivilege(UserRequestPrivilege details)
        {
            try
            {
                if (details == null)
                {
                    Error = new Exception("Not found user and menu data. Details is empty");
                    return null;
                }

                var privileges = repo.HasUserThisMenuPrivilege(details);

                if (privileges != null)
                {
                    if (privileges.HasCheck.GetValueOrDefault()
                        || privileges.HasInsert.GetValueOrDefault()
                        || privileges.HasDelete.GetValueOrDefault()
                        || privileges.HasUpdate.GetValueOrDefault()
                        || privileges.HasReview.GetValueOrDefault()
                        || privileges.HasVerify.GetValueOrDefault()
                        || privileges.HasAudit.GetValueOrDefault()
                        || privileges.HasRecommendation.GetValueOrDefault()
                        || privileges.HasApprove.GetValueOrDefault()
                        || privileges.HasFullAccess.GetValueOrDefault()) privileges.HasView = true;
                }

                return privileges;
            }
            catch (Exception ex)
            {
                Error = ex;
                return null;
            }
        }
    }
}