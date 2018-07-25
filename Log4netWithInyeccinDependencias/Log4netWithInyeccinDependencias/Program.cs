using Autofac;
using System;

namespace Log4netWithInyeccinDependencias
{
    public class Program 
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            RegisterComponents();
            Calculate(2323,0);
        }
        
        private static void RegisterComponents()
        {
            var builder = new ContainerBuilder();//deberia ir en app_star de la web api
            builder.RegisterType<CalculadoraController>().SingleInstance();
            builder.RegisterModule(new LoggingModule());// cada nivel(capa) tiene que tener su Module y registrar solo de lo ese nivel
            Container = builder.Build();
        }

        public static void Calculate(int num1, int num2)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var res = scope.Resolve<CalculadoraController>().Divide(num1, num2); //aqui se esta injectando (DI)
                Console.WriteLine(res);
            }
        }
    }
}
