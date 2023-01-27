using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    public static class Blocknot
    {
        private static List<Employee> allEmployees = new List<Employee>();

        public static void Add(Employee emp)
        {
            if (Contains(emp.Name))
            {
                throw new ArgumentException();
            }
            allEmployees.Add(emp);
        }

        public static void Remove(Employee emp)
        {
            if (!Contains(emp.Name))
            {
                throw new ArgumentException();
            }
            allEmployees.Remove(emp);
        }

        public static bool Contains(string name)
        {
            if (allEmployees.Contains(new Employee(name,"",0)))
            {
                return true;
            }
            return false;
        }

        public static Employee FindEmployee(string name)
        {
            foreach (Employee item in allEmployees)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            throw new ArgumentException();
        }

        public static void ShowAll()
        {
            foreach (Employee item in allEmployees)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<Employee> ShowByDepartment(int dep)
        {
            foreach (Employee item in allEmployees)
            {
                if (item.IsFromDepartment(dep-1))
                {
                    yield return item;
                }
            }
        }

        public static void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter("Employees.txt"))
            {
                foreach (Employee item in allEmployees)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        public static void LoadFromFile()
        {
            using (StreamReader reader = new StreamReader("Employees.txt"))
            {
                while (reader.Peek() != -1)
                {
                    allEmployees.Add(Employee.Parse(reader.ReadLine()));
                }
            }
        }
    }
}
