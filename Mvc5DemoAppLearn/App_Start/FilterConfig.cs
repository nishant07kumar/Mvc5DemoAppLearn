using System.Web;
using System.Web.Mvc;

namespace Mvc5DemoAppLearn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
