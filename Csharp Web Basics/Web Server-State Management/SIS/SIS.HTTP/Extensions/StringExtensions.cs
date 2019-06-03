using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public class StringExtensions
    {
        public static string Capitalize(string someString)
        {
            var result = char.ToUpper(someString[0]) + someString.Substring(1);

            return result;
        }
    }
}
