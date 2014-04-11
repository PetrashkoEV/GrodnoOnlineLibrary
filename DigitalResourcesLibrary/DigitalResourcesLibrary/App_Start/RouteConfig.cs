using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DigitalResourcesLibrary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SearchByCategoryWithPage",
                url: "Search/page={page}",
                defaults: new { controller = "Search", action = "Search" }
            );

            routes.MapRoute(
                name: "SearchByCategoryDefaultPage",
                url: "Search/page={page}",
                defaults: new { controller = "Search", action = "Search", page = 1 }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = 1 }
            );

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );*/
        }
    }
}