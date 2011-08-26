using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace BuzzyGo.Web.Utilities
{
    public class RouteUtilities
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Clear();

            // Turns off the unnecessary file exists check
            routes.RouteExistingFiles = true;

            // Ignore text, html, files.
            routes.IgnoreRoute("{file}.txt");
            routes.IgnoreRoute("{file}.htm");
            routes.IgnoreRoute("{file}.html");
            routes.IgnoreRoute("Services/{*pathInfo}");

            // Ignore axd files such as assets, image, sitemap etc
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Ignore the content directory which contains images, js, css & html
            routes.IgnoreRoute("content/{*pathInfo}");

            // Ignore the error directory which contains error pages
            routes.IgnoreRoute("error/{*pathInfo}");

            //Exclude favicon (google toolbar request gif file as fav icon which is weird)
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.([iI][cC][oO]|[gG][iI][fF])(/.*)?" });

            //Actual routes of my application

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

    }
}
