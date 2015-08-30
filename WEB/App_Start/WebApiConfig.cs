using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WEB.Controllers;

namespace WEB
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{*wildcard}", new {Controllers = "Values"});

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiLookup",
            //    routeTemplate: "lookup/{*wildcard}",
            //    defaults: new { Controllers="Values" }
            //);

        }
    }
}
