//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace VuelingClasses
//{
//    class ReflectionXmlXpath
//    {
//        static void Main(String[] args)
//        {
//            string pathToDomain = @"C:\Windows\System32\gdi32full.dll";
//            Assembly domainAssembly = Assembly.LoadFrom(pathToDomain);
//            Type customerType = domainAssembly.GetType("ReflectionXmlXpath.Customer");
//            Type[] stringArgumentTypes = new Type[] { typeof(string) };

//            ConstructorInfo stringConstructor = customerType.GetConstructor(stringArgumentTypes);
//            object newStringCustomer = stringConstructor.Invoke(new object[] { "Elvis" });

//            MethodInfo voidMethodInfo = customerType.GetMethod("DoVoidMethod");
//            voidMethodInfo.Invoke(newStringCustomer, new object[] { 3, "hello" });

//            MethodInfo retMethodInfo = customerType.GetMethod("DoRetMethod");
//            int returnValue = Convert.ToInt32(retMethodInfo.Invoke(newStringCustomer, new object[] { 4 }));
//        }
//    }
//    class Customer
//    {
//        private string _name;

//        public Customer() : this("N/A")
//        { }

//        public Customer(string name)
//        {
//            _name = name;
//        }

//        public void DoVoidMethod(int intParameter, string stringParameter)
//        {
//            Console.WriteLine("Within Customer.DoVoidMethod. Parameters: {0}, {1}", intParameter, stringParameter);
//        }

//        public int DoRetMethod(int intParameter)
//        {
//            return intParameter + 1;
//        }
//    }
//}
