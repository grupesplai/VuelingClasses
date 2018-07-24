using Autofac;
using Concesionario;

namespace InyeccionXContructor
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
            var builder = new ContainerBuilder();
            builder.RegisterType<BMWAutoService>().SingleInstance();
            builder.RegisterType<FordAutoService>().SingleInstance();
            builder.RegisterType<HondaAutoService>().SingleInstance();
            Container = builder.Build();
        }
        public static void Resolution()
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var bmw = scope.Resolve<BMWAutoService>(); //aqui se esta injectando (DI)
                var ford = scope.Resolve<FordAutoService>();
                var honda = scope.Resolve<HondaAutoService>();
                AutoServiceCallerImp serviceCaller = new AutoServiceCallerImp(bmw,ford,honda);
                serviceCaller.callAutoService();
            }
        }
    }
} 
