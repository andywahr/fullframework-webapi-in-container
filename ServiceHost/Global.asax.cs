using Autofac;
using System.Web.Http;

namespace fullframework_webapi_in_container
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IContainer Container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure((config) => 
                {
                    IoC.Setup(config);
                    WebApiConfig.Register(config);
                }
            );
        }
    }
}
