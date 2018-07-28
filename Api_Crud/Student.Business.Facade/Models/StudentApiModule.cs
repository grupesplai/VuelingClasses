using Autofac;
using Autofac.Integration.WebApi;
using Student.Business.Logic;
using Student.Common.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Student.Business.Facade.Models
{
    public class StudentApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder
                .RegisterType<StudentBL>()
                .As<IBusiness>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();


            // Cada module, se encarga de inyectar las clases de su capa
            builder.RegisterModule(new BusinessLogicModule());

            base.Load(builder);
        }
    }
}