using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebERPAPI.Data.Repository.IT;

namespace WebERPAPI.Controllers.IT
{
    [Authorize]
    public class UtilityController : ApiController
    {
        [HttpGet]
        [Route("~/api/IT/utility/password/{password}/{encrypt}")]
        public HttpResponseMessage getPassword(string password, int encrypt)
        {
            try
            {
                string Password = "";
                if (encrypt == 1)
                {
                    Password = new LPLERP.Common.Encryption().EncryptWord(password);
                }
                else Password = new LPLERP.Common.Encryption().DecryptWord(password);

                return Request.CreateResponse(HttpStatusCode.OK, Password);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/IT/utility/strong/password")]
        public HttpResponseMessage getStrongPassword()
        {
            try
            {
                UtilityRepositories repo = new UtilityRepositories();
                string password = repo.getStrongPassword();

                if (password != null) return Request.CreateResponse(HttpStatusCode.OK, password);
                else return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, repo.error);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }

        [HttpGet]
        [Route("~/api/IT/utility/strong/password/multiple")]
        public HttpResponseMessage getStrongPasswords()
        {
            try
            {
                UtilityRepositories repo = new UtilityRepositories();
                var password = repo.getStrongPasswords();

                if (password != null) return Request.CreateResponse(HttpStatusCode.OK, password);
                else return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, repo.error);
            }
            catch (Exception ex)
            {
                return MISResponse.Error(ex, Request);
            }
        }
    }
}