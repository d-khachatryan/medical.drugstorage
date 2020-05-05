using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Medicaldrugstore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Telerik.Reporting.Services.WebApi.ReportsControllerConfiguration.RegisterRoutes(System.Web.Http.GlobalConfiguration.Configuration);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies["_culture"];
            var name = cookie != null ? cookie.Value : null;

            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            var culture = new CultureInfo(name);
            culture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
            culture.DateTimeFormat.DateSeparator = "/";
            culture.DateTimeFormat.ShortTimePattern = String.Empty;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(name);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }
    }
}
