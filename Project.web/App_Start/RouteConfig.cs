using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "home",
              url: "home",
              defaults: new { controller = "Home", action = "Dashboard", id = UrlParameter.Optional }
          );


            routes.MapRoute(
              name: "forgotpassword",
              url: "acc/password-reset/",
              defaults: new { controller = "Authentication", action = "ForgotPassword", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "registration",
               url: "signup/start",
               defaults: new { controller = "Authentication", action = "Registration", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "login",
              url: "acc/login",
              defaults: new { controller = "Authentication", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
