using OnlineCalculator.Web.App_Start;
using System.Web.Http;

namespace OnlineCalculator.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            AutofacWebapiConfig.Initialize(config);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
