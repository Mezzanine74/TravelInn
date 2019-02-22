using System.Web.Mvc;

namespace TravelInn.MVC.DevExpressWeb.Responsive
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}