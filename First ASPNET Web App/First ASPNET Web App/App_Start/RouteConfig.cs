using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace First_ASPNET_Web_App
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Order matters: from most specific to most generic or else a more generic route will be applied to a URL
            routes.MapMvcAttributeRoutes(); // enable attribute routing
            routes.MapRoute(
                "MoviesByReleaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate"}, // "ByReleaseDate" is a magic string that doesn't get updated 
                // new { year = @"\d{4}", month = @"\d{2}" } // contraints
                new { year = @"2015|2016", month = @"\d{2}" } // limit route parameters to a few specific values
            );
            // Default route
            routes.MapRoute( 
                name: "Default",
                url: "{controller}/{action}/{id}", //(ie. movies/2 for page 2)
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
