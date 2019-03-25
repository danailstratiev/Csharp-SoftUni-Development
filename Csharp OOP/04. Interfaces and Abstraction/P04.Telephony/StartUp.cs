using System;
using System.Linq;
using System.Collections.Generic;


namespace P04.Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").ToArray();
            var smartphone = new Smartphone();

            foreach (var number in numbers)
            {
                Console.WriteLine(smartphone.Call(number));
            }

            var urls = Console.ReadLine().Split(" ").ToArray();

            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
