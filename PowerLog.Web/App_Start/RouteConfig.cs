using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PowerLog.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "LogDetails",
                url: "dashboard/{year}-{month}-{day}/{title}",
                defaults: new { controller = "Dashboard", action = "Details" },
                constraints: new { year = @"\d{4}", month = @"\d{1,2}", day = @"\d{1,2}" }
            );
            routes.MapRoute(
                name: "LogProgress",
                url: "progress/{id}/{year}-{month}-{day}",
                defaults: new { controller = "Dashboard", action = "Progress" },
                constraints: new { id = @"\d+", year = @"\d+", month = @"\d+", day = @"\d+" }
            );
            routes.MapRoute(
                name: "SharedSession",
                url: "{title}-s.{key}",
                defaults: new { controller = "Share", action = "Shared" },
                constraints: new { key = @"\w{10}" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}