using System;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace VuelingClasses
{
    class ReflectionXML
    {

        static public void Main(string[] args)
        {
            //Console.WriteLine("Introduce a name for a customer.");
            //string nameCostumer = Console.ReadLine();

            Assembly assembly = typeof(ReflectionXML).Assembly;
            Type customerType = assembly.GetType("VuelingClasses.Customer");
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
                StreamReader sr = new StreamReader(@"C:\Users\G1\source\repos\VuelingClasses\VuelingClasses\XMLFile1.xml");
                CustomerXml customer = (CustomerXml)xmlSerializer.Deserialize(sr);
                //Console.WriteLine("Customer information: \nID: " + customer.IdCustomer + "\nCustomer Name"
                //    + customer.Name);

                var customerObject = Activator.CreateInstance(customerType, customer.IdCustomer, customer.Name);//ahora los datos parametrizados estan en la ram
                Console.WriteLine("Customer information: \nID: " + customer.IdCustomer + "\nCustomer name: " + customer.Name);
            }
            catch (XmlException e)
            {
                Console.WriteLine("It hasn't been possible to create it.");
                Console.WriteLine("XmlError: " + e.Message);
            }

            //To serialize and save as a xml file in bin\debug
            try
            {
                CustomerXml customer = new CustomerXml
                {
                    IdCustomer = "C1",
                    Name = "Albert"
                };
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Customer));
                StreamWriter sw = new StreamWriter(@".\CustomerXml.xml");
                xmlSerializer.Serialize(sw, customer);
                sw.Close();
                Console.WriteLine("Serialize's succesfull");
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    [XmlRoot("Customer")]
    public class CustomerXml
    {
        [XmlAttribute("id")]
        public string IdCustomer { get; set; }

        [XmlElement("NameCostumer")]
        public string Name { get; set; }
        public CustomerXml(string id, string name)
        {
            IdCustomer = id;
            Name = name;
        }
        public CustomerXml() { }
    }
}

