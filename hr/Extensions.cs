using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject
{
    public static class Extensions
    {
        public static bool IsFromDepartment(this Employee emp, int dep)
        {
            if (emp.Department == dep)
            {
                return true;
            }
            return false;
        }

        public static string AddSpaceBetween(this string s)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsUpper(s[i]))
                {
                    result.Append(" ");
                }
                result.Append(s[i]);
            }
            return result.ToString().Trim();
        }
    }
}
