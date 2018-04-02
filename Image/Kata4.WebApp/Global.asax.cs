using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Kata4.WebApp.Container;

namespace Kata4.WebApp
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IocContainer.Setup();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}