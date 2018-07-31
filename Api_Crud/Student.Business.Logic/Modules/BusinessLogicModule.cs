using Student.Common.Logic;
using Student.DataAcces.Dao;
using Autofac;

namespace Student.Business.Logic
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<RepositoryStudent>()
                .As<IRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();


            // Cada module, se encarga de inyectar las clases de su capa
            builder.RegisterModule(new DataAccessDaoModule());

            base.Load(builder);
        }
    }
}
