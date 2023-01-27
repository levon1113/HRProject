using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    public static class Helper
    {
        public static void ShowMenu()
        {
            Console.WriteLine();

            MenuItems[] menu = Enum.GetValues<MenuItems>();
            foreach (MenuItems item in menu)
            {
                Console.WriteLine($"{(int)item}) {item.ToString().AddSpaceBetween()}");
            }
            Console.WriteLine();
            Console.Write("Choose an operation -> ");
        }
     
        public static int CheckedInput(int length)
        {
            int res;
            while (!int.TryParse(Console.ReadLine(),out res) || res > length || res<0)
            {
                Console.WriteLine("Wrong command!");
            }
            return res;
        }

        public static string CheckedInput()
        {
            string res = Console.ReadLine();
            while (res.Length==0)
            {
                Console.WriteLine("Wrong input!");
                res = Console.ReadLine();
            }
            return res;
        }

        public static void Next()
        {
            Console.WriteLine();
            Console.Write("Next");
            Console.ReadLine();
            Console.Clear();
        }


    }
}
