using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebERPAPI.Data.Repository;

namespace WebERPAPI.Controllers
{
    public class WorkstationController : ApiController
    {
        [HttpGet]
        [Route("~/api/workstation/list")]
        public HttpResponseMessage get()
        {
            try
            {
                string location = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "StaticContent");
                WorkstationRepositories wrepo = new WorkstationRepositories();
                return Request.CreateResponse(HttpStatusCode.OK, wrepo.getWorkstationList(Path.Combine(location, "workstationlist.txt")));
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}