using AutoMapper;
using Cobalco.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Cobalco
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //ejercicio automapper
            //For each Profile, include that profile in the MapperConfiguration
            var configMapper = new MapperConfiguration(c =>
            {
                c.AddProfile(new AlumnoControllerAutomapper());
            });
            //Create a mapper that will be used by the DI container
            var mapper = configMapper.CreateMapper();
            //Register the DI interfaces with their implementation
            //falta registrar...
        }
    }
}
