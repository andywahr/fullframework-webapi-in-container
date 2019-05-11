using System.Web.Http;

namespace fullframework_webapi_in_container
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new EllieMae.Encompass.Runtime.RuntimeServices().Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
