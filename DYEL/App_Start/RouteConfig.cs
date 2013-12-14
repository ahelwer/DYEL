using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DYEL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                routeName: "DyelApp",
                routeUrl: "",
                physicalFile: "~/index.aspx"
            );

            routes.MapPageRoute(
                routeName: "Home",
                routeUrl: "home",
                physicalFile: "~/index.aspx"
            );

            routes.MapPageRoute(
                routeName: "Login",
                routeUrl: "login",
                physicalFile: "~/index.aspx"
            );

            routes.MapPageRoute(
                routeName: "Feed",
                routeUrl: "feed",
                physicalFile: "~/index.aspx"
            );

            routes.MapPageRoute(
                routeName: "Locations",
                routeUrl: "locations",
                physicalFile: "~/index.aspx"
            );

            routes.MapPageRoute(
                routeName: "Focus",
                routeUrl: "focus",
                physicalFile: "~/index.aspx"
            );

            routes.MapPageRoute(
                routeName: "Follows",
                routeUrl: "follows",
                physicalFile: "~/index.aspx"
            );
        }
    }
}
