using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using Microsoft.Practices.Unity;
using WebApiServiceEndpoints.DI;

namespace WebApiServiceEndpoints
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var container = new UnityContainer();
            container.RegisterType<IFileServer, FileServer>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityIoC(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
