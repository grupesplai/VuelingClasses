using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace VuelingClasses.Reflection
{
    class ReflectionXmlXpath
    {
        static void Main(String[] args)
        {
            string xmlPath = @"C:\Users\G1\source\repos\VuelingClasses\VuelingClasses\ReflectionFile.xml";
            //XPATH PART
            List<string> customerList = new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList nodeList = doc.SelectNodes("//Customer");

            foreach (XmlNode node in nodeList)
                customerList.Add(node["Name"].InnerText + " "+ node["LastName"].InnerText +" " + node["Birthday"].InnerText);

            Console.WriteLine("To read Xml file with Xpath");

            foreach (string cl in customerList)
                Console.WriteLine(cl);

            Assembly assembly = typeof(ReflectionXmlXpath).Assembly;
            Type customerType = assembly.GetType("VuelingClasses.Reflection.Customer");
            //Customer customerObject = (Customer)Activator.CreateInstance(customerType, customerList[0]);
            //ahora los datos parametrizados estan en la ram

            Type[] stringArgumentTypes = new Type[] { typeof(string) };
            ConstructorInfo stringConstructor = customerType.GetConstructor(stringArgumentTypes);
            int i = 0;
            foreach (string cl in customerList) { 
            object newStringCustomer = stringConstructor.Invoke(new object[] { cl[i].ToString() });
                Console.WriteLine("The customer object in ram is: " + newStringCustomer.ToString());
                i++;
            }



            //USING LINQ-TO-XML
            XDocument xDoc = XDocument.Load(xmlPath);
            var result = from q in xDoc.Descendants("Customers")
                         select q.Element("Customer").Value;
            Console.WriteLine("\nTo read Xml file using LinqToXml");
            foreach (var re in result)
                Console.WriteLine(re);

            
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
        public string LastName { get; set; }
        public string Birthday { get; set; }

    }
}
