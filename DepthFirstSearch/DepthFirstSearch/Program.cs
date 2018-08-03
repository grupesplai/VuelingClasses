using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            DepthFirstAlgorithm bfA = new DepthFirstAlgorithm();
            Employee root = bfA.BuildEmployeeGraph();
            Console.WriteLine("Travers Graph\n----");
            bfA.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n-----");
            Employee e = bfA.Search(root,"Eva");
            Console.WriteLine(e == null ? "Employee not found": e.name);
            e = bfA.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            e = bfA.Search(root, "Soni");
            Console.WriteLine(e == null ? "Employee not found" : e.name);
            Console.ReadLine();
        }
    }
    public class Employee
    {
        List<Employee> EmployeeList = new List<Employee>();

        public string name { get; set; }
        public Employee (string name)
        {
            this.name = name;
        }
        public List<Employee> Employees
        {
            get { return EmployeeList; }
        }
        public void isEmployeeOf(Employee e)
        {
            EmployeeList.Add(e);
        }

        public override string ToString()
        {
            return name;
        }
    }
    public class DepthFirstAlgorithm
    {
        public Employee BuildEmployeeGraph()
        {
            Employee Eva = new Employee("Eva");
            Employee Sophia = new Employee("Sophia");
            Employee Brian = new Employee("Brian");
            Eva.isEmployeeOf(Sophia);
            Eva.isEmployeeOf(Brian);
            
            Employee Lisa = new Employee("Lisa");
            Employee Tina = new Employee("Tina");
            Employee John = new Employee("John");
            Employee Mike = new Employee("Mike");
            Sophia.isEmployeeOf(Lisa);
            Sophia.isEmployeeOf(John);
            Brian.isEmployeeOf(Tina);
            Brian.isEmployeeOf(Mike);

            return Eva;
        }
        public Employee Search(Employee root, string nameToSearchFor)
        {
            if (nameToSearchFor == root.name)
                return root;

            Employee personFound = null;
            for (int i = 0; i < root.Employees.Count; i++)
            {
                personFound = Search(root.Employees[i], nameToSearchFor);
                if (personFound != null)
                    break;
            }
            return personFound;
        }
        public void Traverse(Employee root)
        {
            Console.WriteLine(root.name);
            for (int i = 0; i < root.Employees.Count; i++)
            {
                Traverse(root.Employees[0]);
            }
        }
    }
}
