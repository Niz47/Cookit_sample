using System.Web;
using System.Web.Mvc;

namespace Cookit_Testing_zmh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
