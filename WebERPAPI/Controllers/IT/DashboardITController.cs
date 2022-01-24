using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebERPAPI.Data.Models.MIS;

namespace WebERPAPI.Controllers
{
    [Authorize]
    public class DashboardITController : ApiController
    {
        [HttpGet]
        [Route("~/api/sync/event/list")]
        public HttpResponseMessage getSyncEventList()
        {
            try
            {
                using (MISEntities db = new MISEntities())
                {
                    var con = DateTime.Now.AddHours(-18);
                    return Request.CreateResponse(HttpStatusCode.OK, db.SyncEventLogs.Where(s => s.CreatedOn > con).OrderByDescending(o => o.CreatedOn).ToList());
                }
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }
    }
}