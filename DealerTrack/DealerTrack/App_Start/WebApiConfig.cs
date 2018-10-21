using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TranscriptiorServices.App_Start;
using TranscriptiorServices.DataServices;
using Unity;
using Unity.AspNet.Mvc;

namespace TranscriptiorServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var container = new UnityContainer();
            container.RegisterType<IUserRepository, UserRepository>();
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}
