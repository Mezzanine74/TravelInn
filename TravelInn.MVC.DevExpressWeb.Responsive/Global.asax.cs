using DevExpress.Web;
using System;
using System.Globalization;
using System.Threading;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelInn.MVC.DevExpressWeb.Responsive
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new global::DevExpress.Web.Mvc.DevExpressEditorsBinder();

            // Grid API si bound olmayan kolonlari da almak icin buna ihtiyac duyar. 18.1 den sonra yapilmis bir degisiklik.
            ASPxWebControl.BackwardCompatibility.DataControlAllowReadUnlistedFieldsFromClientApiDefaultValue = true;

            global::DevExpress.Web.ASPxWebControl.CallbackError += Application_Error;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = System.Web.HttpContext.Current.Server.GetLastError();
            //TODO: Handle Exception
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            CultureInfo TempCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();

            TempCulture.DateTimeFormat.ShortDatePattern = @"dd/MM/yyyy";

            TempCulture.NumberFormat.NumberDecimalSeparator = ".";
            TempCulture.NumberFormat.NumberGroupSeparator = ",";

            Thread.CurrentThread.CurrentCulture = TempCulture;

        }
    }
}