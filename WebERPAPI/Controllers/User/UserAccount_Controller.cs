using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebERPAPI.BusinessLogic.User;
using WebERPAPI.DTO;
using WebERPAPI.DTO.Employee;
using WebERPAPI.DTO.User;
using WebERPAPI.Data.Repository;
using WebERPAPI.BusinessLogic.HRMS;
using WebERPAPI.Data.Repository.HRMS;
using System;
using WebERPAPI.Data.Models.PROCESSERVER;
using System.Linq;

namespace WebERPAPI.Controllers
{
    [Authorize]
    [EnableCors("*", "*", "*")]
    public class UserAccount_Controller : ApiController
    {
        private UserRepositories repo = new UserRepositories();
        private UserAccountService service = new UserAccountService();

        [Authorize]
        [HttpGet]
        [Route("~/api/user/session/validate")]
        public HttpResponseMessage validateUserSession()
        {
            return MISResponse.Return("success", service.error, Request);
        }


        [HttpGet]
        [Route("~/api/office/location/list")]
        public HttpResponseMessage getOfficeLocations()
        {
            return MISResponse.Return(service.getOfficeLocations(), service.error, Request);
        }

        [HttpGet]
        [Route("~/api/employee/department/list")]
        public HttpResponseMessage getDepartmentList()
        {
            try
            {
              return MISResponse.Return(service.getDepartment(), service.error, Request);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpPost]
        [Route("~/api/user/create/new")]
        public HttpResponseMessage createUserAccount([FromBody] NewUserDetails NewUser)
        {
            return MISResponse.Return(service.createUserAccount(NewUser), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/hrms/employee/save")]
        public HttpResponseMessage updateEmployeeContact([FromBody] EmployeeDetails employee)
        {
            return MISResponse.Return(service.updateUserContact(employee), service.error, Request);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/employee/list/{locationid}")]
        public HttpResponseMessage getActiveEmployees(string locationid)
        {
            return MISResponse.Return(service.getOfficeEmployees(locationid), service.error, Request);
        }


        [Authorize]
        [HttpGet]
        [Route("~/api/employee/images/list/{locationid}")]
        public HttpResponseMessage getOfficeActiveEmployeesWithImages(string locationid)
        {
            return MISResponse.Return(service.getOfficeEmployees(locationid), service.error, Request);
        }

        [Authorize]
        [HttpGet]
        [Route("~/api/employee/details/{employeeid}")]
        public HttpResponseMessage getEmployeeDetails(string employeeid)
        {
            return MISResponse.Return(service.getEmployeeDetails(employeeid), service.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/privilege/list/{userid}")]
        public HttpResponseMessage getUserPrivileges(int userid)
        {
            return MISResponse.Return(service.getUserPrivileges(userid), service.error, Request);
        }

        [HttpPost]
        [Route("~/api/user/privilege/create")]
        public HttpResponseMessage updateUserPrivilege([FromBody] CommonDataEntryClass Privilege)
        {
            return MISResponse.Return(service.updateUserPrivilege(Privilege), service.error, Request);
        }

        [HttpPost]
        [Route("~/api/user/privilege/create/multiple")]
        public HttpResponseMessage setMultipleUserPrivilege([FromBody] MulitpleUserPrivilege data)
        {
            return MISResponse.Return(service.setMultipleUserPrivilege(data), service.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/info/active/{searchtype}/{searchvalue}")]
        public HttpResponseMessage getActiveUserInfo(string searchtype, string searchvalue)
        {
            return MISResponse.Return(service.getActiveUserInfo(searchtype, searchvalue), service.error, Request);
        }

        

        [HttpPost]
        [Route("~/api/user/password/change/{userid}/{currentpassword}/{newpassword}")]
        public HttpResponseMessage updateUserPassword(int userid, string currentPassword, string newpassword)
        {
            return MISResponse.Return(repo.updateUserPassword(userid, currentPassword, newpassword), repo.error, Request, "Successfully updated");
        }

        [HttpPost]
        [Route("~/api/user/email/password/change/{userid}")]
        public HttpResponseMessage updateUserEmailPassword([FromBody] UserOfficeEmailDetails user, int userid)
        {
            return MISResponse.Return(repo.updateUserEmailPassword(userid, user.EmailPassword), repo.error, Request, "Successfully updated");
        }

        [HttpGet]
        [Route("~/api/user/favorite/menu/{userid}")]
        public HttpResponseMessage getUserFavoriteMenus(string userid)
        {
            return MISResponse.Return(repo.getUserFavoriteMenus(userid), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/privileged/menu/{userid}")]
        public HttpResponseMessage getUserPrivilegedMenu(string userid)
        {
            return MISResponse.Return(repo.getUserFavoriteMenus(userid), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/it/login/{employeecode}")]
        public HttpResponseMessage setITLoging(string employeecode)
        {
            return MISResponse.Return(repo.setITLoging(employeecode), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/short/details/{employeecode}")]
        public HttpResponseMessage getUserShortDetails(string employeecode)
        {
            return MISResponse.Return(repo.getUserShortDetails(employeecode), repo.error, Request);
        }

      
        [HttpGet]
        [Route("~/api/user/menu/browsing/history/details/{userid}")]
        public HttpResponseMessage getUserMenuBrowsingHistory(string userid)
        {
            return MISResponse.Return(repo.getUserMenuBrowsingHistory(userid), repo.error, Request);
        }

        // Don't Use MISResponse for this API
        [HttpGet]
        [Route("~/api/user/last/notification/{userid}/{notificationid}/{route}")]
        public HttpResponseMessage getLastNotification(string userid, string notificationid, string route)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repo.getLastNotification(userid, notificationid, Library.JSONSerialize.DecodeBase64(route)));
            //return MISResponse.Return(, repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/menu/browsing/history/{userid}")]
        public HttpResponseMessage getUserBrowsingHistory(string userid)
        {
            return MISResponse.Return(repo.getUserBrowsingHistory(userid), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/sales/employee/has/nouseraccount")]
        public HttpResponseMessage getSalesEmployeeHasNoUserAccount()
        {
            return MISResponse.Return(repo.getSalesEmployeeHasNoUserAccount(), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/active/total")]
        public HttpResponseMessage getActiveUserTotal()
        {
            return MISResponse.Return(repo.getActiveUserTotal(), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/user/active/menu/list")]
        public HttpResponseMessage getActiveUserList()
        {
            return MISResponse.Return(repo.getActiveUserList(), repo.error, Request);
        }

        [HttpPost]
        [Route("~/api/update/client/details")]
        public HttpResponseMessage updateLogDetails([FromBody] ClientDetails info)
        {
            return MISResponse.Return(service.updateLogDetails(info), service.error, Request);
        }

        [HttpGet]
        [Route("~/api/application/current/version/{appname}")]
        public HttpResponseMessage getApplicationCurrentVersion(string appname)
        {
            return MISResponse.Return(repo.getApplicationCurrentVersion(appname), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/application/version/list/")]
        public HttpResponseMessage getApplicationVersionList()
        {
            return MISResponse.Return(repo.getApplicationVersionList(), repo.error, Request);
        }

        [HttpGet]
        [Route("~/api/application/version/update/{AppID}/{NextVersion}/{CreatedBy}")]
        public HttpResponseMessage saveUpdateApplicationVersion(int AppID, string NextVersion, string CreatedBy)
        {
            return MISResponse.Return(repo.updateVersion(AppID, NextVersion, CreatedBy), repo.error, Request);
        }
    }
}