using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    public static class Departments
    {
        private static List<string> AllDepartments = new List<string>();
        
        public static int Count()
        {
            return AllDepartments.Count;
        }
        public static List<string> GetDepartments()
        {
            return AllDepartments;
        }

        public static void Add(string s)
        {
            if (AllDepartments.Contains(s))
            {
                throw new ArgumentException();
            }
            AllDepartments.Add(s);
        }

        public static void Remove(int i)
        {
            AllDepartments.Remove(AllDepartments[i]);
        }

        public static void ShowAll()
        {
            Console.WriteLine();
            if (AllDepartments.Count !=0)
            {
                foreach (string item in AllDepartments)
                {
                    Console.WriteLine($"{AllDepartments.IndexOf(item) + 1}) {item}");

                }
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("There are no departments");
            }


        }

        public static void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter("Departments.txt"))
            {
                foreach (string item in AllDepartments)
                {
                    writer.WriteLine(item);
                }
            }
        }

        public static void LoadFromFile()
        {
            using (StreamReader reader = new StreamReader("Departments.txt"))
            {
                while (reader.Peek()!=-1)
                {
                    AllDepartments.Add(reader.ReadLine());
                }
            }
        }
    }
}
