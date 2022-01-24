using System;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebERPAPI.Controllers
{
    [Authorize]
    public class FileUploaderController : ApiController
    {
        [HttpPost]
        [Route("~/api/attachment/{id}")]
        public HttpResponseMessage Post(string id)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    int count = 0;
                    foreach (string filename in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[count];
                        var uploadFilePath = HttpContext.Current.Server.MapPath("~/attachment/" + postedFile.FileName);

                        postedFile.SaveAs(uploadFilePath);
                        count++;
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }
    }
}