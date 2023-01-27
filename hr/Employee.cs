using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    public class Employee
    {
        public string Name { get;}
        public string Phone { get; set; }
        public int Department { get; set; }

        public Employee()
        {

        }

        public Employee(string name,string phone,int dep)
        {
            this.Name = name;
            this.Phone = phone;
            this.Department = dep;
        }

        public override string ToString()
        {
            return $"{Name}, {Phone}, {Departments.GetDepartments()[Department]}";
        }

        public static Employee Parse(string input)
        {
            string[] s = input.Split(',');
            return new Employee(s[0].Trim(), s[1].Trim(), Departments.GetDepartments().IndexOf( s[2].Trim()));
        }

        public override bool Equals(object emp)
        {
            return this.Name == ((Employee)emp).Name;
        }
    }
}
