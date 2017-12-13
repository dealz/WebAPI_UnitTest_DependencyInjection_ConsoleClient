using Microsoft.Practices.Unity;
using PersonStore.Models;
using PersonStore.Resolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI_DI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "examapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
