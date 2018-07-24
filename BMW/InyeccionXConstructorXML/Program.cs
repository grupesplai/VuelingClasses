using Autofac;
using Autofac.Configuration;
using BMW;
using Microsoft.Extensions.Configuration;
using System;
using System.Xml;


namespace InyeccionXConstructorXML
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            RegisterInConteiner();
            Resolution();

        }
        private static void RegisterInConteiner()
        {
            var config = new ConfigurationBuilder();
            config.AddXmlFile("autofac.xml");

            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            Container = builder.Build();
        }
        public static void Resolution()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var bmw = scope.Resolve<BMWAutoService>(); //aqui se esta injectando (DI)
                var ford = scope.Resolve<FordAutoService>();
                var honda = scope.Resolve<HondaAutoService>();
                AutoServiceCallerImp serviceCaller = new AutoServiceCallerImp(bmw, ford, honda);
                serviceCaller.callAutoService();
            }
        }
    }
}
