using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Jx.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Video", action = "VideoPage", name = "自动化测试介绍" }
            );

            routes.MapRoute(
                name: "Video",
                url: "{controller}/{name}",
                defaults: new { controller = "Video", action = "VideoPage", name = "自动化测试介绍" }
            );
        }
    }
}
