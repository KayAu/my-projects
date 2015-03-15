using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GreatSavings
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
                //defaults: new { controller = "ProductSubmission", action = "ProductList", id = UrlParameter.Optional }
               // defaults: new { controller = "ProductSubmission", action = "Promotion", id = UrlParameter.Optional }
            );
        }
    }
}