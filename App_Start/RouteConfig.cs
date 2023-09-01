using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MarketVerse
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ViewProductsBasedOnSubCategory",
                url: "ViewProductsBasedOnSubCategory/{id}",
                defaults: new {controller = "Products", action = "ViewProductsBasedOnSubCategory" }
            );
            routes.MapRoute(
                name: "ShowProduct",
                url: "ShowProduct/{id}",
                defaults: new { controller = "Products", action = "ShowProduct" }
            );
        }
    }
}
