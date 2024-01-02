using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public static class Extensions
    {
        public static string ToLowerCase(this string str)
        {
            return str.ToLower();
        }

        public static int CountHigherCases(this string str)
        {
            int higherCasesCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    higherCasesCount++;
                }
            }
            return higherCasesCount;
        }
    }
}
