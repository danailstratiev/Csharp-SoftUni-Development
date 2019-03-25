using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P04.Telephony
{
    public class Smartphone : ICaller, IBrowser
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                string message = "Invalid URL!";
                return message;
            }
            else
            {
                string message = $"Browsing: {url}!";
                return message ;
            }
        }

        public string Call(string number)
        {
            if (number.All(x => char.IsDigit(x)))
            {
                return $"Calling... {number}";
            }
            else
            {
                return "Invalid number!";
            }
        }
    }
}
