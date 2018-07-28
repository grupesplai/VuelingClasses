using Autofac;
using Autofac.Integration.WebApi;
using Student.Business.Facade.Models;
using System.Web.Http;

namespace Student.Business.Facade.App_Start
{
    public class AutofacConfigure
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new StudentApiModule());

            var container = builder.Build();

            // El que resuelve todas las clases registradas -> AutofacWebApiDependencyResolver
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}