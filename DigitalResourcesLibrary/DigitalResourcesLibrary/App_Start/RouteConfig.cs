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
                name: "HomePage",
                url: "Search/",
                defaults: new { controller = "Search", action = "Index" }
            );

            routes.MapRoute(
                name: "SearchByCategory",
                url: "Search/Category/{searchValue}",
                defaults: new { controller = "Search", action = "SearchByCategory", page = 1 }
            );

            routes.MapRoute(
                name: "SearchByCategoryWithPage",
                url: "Search/Category/{searchValue}/page{page}",
                defaults: new { controller = "Search", action = "SearchByCategory" }
            );

            /*routes.MapRoute(
                name: "SearchByDate",
                url: "Search/Date/{searchValue}",
                defaults: new { controller = "Search", action = "SearchByDate", page = 1 }
            );

            routes.MapRoute(
                name: "SearchByDateWithPage",
                url: "Search/Date/{searchValue}/{page}",
                defaults: new { controller = "Search", action = "SearchByDate" }
            );*/
            /*
            routes.MapRoute(
                name: "SearchByText",
                url: "Search/Text/{searchValue}",
                defaults: new { controller = "Search", action = "SearchByText", page = 1 }
            );

            routes.MapRoute(
                name: "SearchByTextWithPage",
                url: "Search/Text/{searchValue}/page{page}",
                defaults: new { controller = "Search", action = "SearchByText" }
            );*/

            routes.MapRoute(
                name: "About",
                url: "About/",
                defaults: new { controller = "Home", action = "About" }
            );

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}