using System.Web.Http;
using WebActivatorEx;
using WebERPAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebERPAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            //System.Environment.UserDomainName

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebERPAPI");
                    })
                .EnableSwaggerUi(c => { });
        }
    }
}