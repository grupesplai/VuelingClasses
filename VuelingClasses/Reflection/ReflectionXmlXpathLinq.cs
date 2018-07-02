using System;
using System.Collections.Generic;
using System.Linq;
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
            XmlNodeList nodeList = doc.SelectNodes("/Customers");

            foreach (XmlNode node in nodeList)
                customerList.Add(node["Customer"].InnerText);
            Console.WriteLine("To read Xml file with Xpath");
            foreach (string cl in customerList)
                Console.WriteLine(cl);

            //USING LINQ-TO-XML
            XDocument xDoc = XDocument.Load(xmlPath);
            var result = from q in xDoc.Descendants("Customers")
                         select q.Element("Customer").Value;
            Console.WriteLine("\nTo read Xml file using LinqToXml");
            foreach (var re in result)
                Console.WriteLine(re);
        }

    }

}
