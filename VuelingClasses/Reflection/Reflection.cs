using System;
using System.Reflection;

namespace VuelingClasses
{
    class Reflection
    {
        static void Main(string[] args)
        {
            //Customer customer;

            Console.WriteLine("Introduce a name for a customer.");
            string nameCostumer = Console.ReadLine();

            Assembly assembly = typeof(Reflection).Assembly;
            //cualquier clase de la asembly me dará la asembly, ya está en la ram
            //type es la representacion de los objetos, el asembly esta en memoria
            //la 1era vez k se instancia la clase, 1ero se crea la clase para la instanciación
            //a partir de la 2da vez se crea en la RAM
            //en una app consola se borra la clase, se borra de la ram cuando se cierra la app
            // en app web: esta en e IIS(Internet Information Server, servidor web local de windows)
            // solo se para parando el servicio IIS, servidor web, y parando el dominio de la app web
            Type customerType = assembly.GetType("VuelingClasses.Customer");//clase en la ram, runtime

            //Type type = nameCostumer.GetType();


            try
            {
                //customer = (Customer)Activator.CreateInstance(typeof(Customer));
                Customer customerObject = (Customer)Activator.CreateInstance(customerType, nameCostumer);//ahora los datos parametrizados estan en la ram
                Console.WriteLine("The customer name is: " + (customerObject).Name);
            }
            catch (Exception e)
            {
                Console.WriteLine("It hasn't been possible to create it.");
                Console.WriteLine(e.Message);
            }
        }
    }
    class Customer
    {
        public Customer() { }
        public Customer(string name)
        {
            Name = name;
        }
        //public int Id {  get; set;  }
        public string Name { get; set; }

    }
}
