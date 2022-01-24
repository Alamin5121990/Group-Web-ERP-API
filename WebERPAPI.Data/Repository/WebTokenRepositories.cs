using System;
using System.Linq;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.Repository
{
    public class WebTokenRepositories
    {
        public Exception error = new Exception();

        public WebTokenManager getWebTokenDetails(string Token)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    return db.WebTokenManagers.Where(t => t.Token == Token).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return null;
            }
        }

        public string generateNewWebToken(WebTokenManager webToken)
        {
            try
            {
                using (SystemManagerEntities db = new SystemManagerEntities())
                {
                    webToken.Token = getWebToken();
                    db.WebTokenManagers.Add(webToken);
                    db.SaveChanges();

                    return webToken.Token;
                }
            }
            catch (Exception ex)
            {
                error = ex;
                return "";
            }
        }

        private string getWebToken()
        {
            try
            {
                return Scripting.RandomString(8);
            }
            catch { return ""; }
        }
    }
}