using System.Web.Mvc;
using Kata4.Core.Contract.Infrastructure.LogContract;
using Kata4.WebApp.Container;
using Kata4.WebApp.Handler;

namespace Kata4.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionHandler(IocContainer.Get().Resolve<ILogger>()));
        }
    }
}
