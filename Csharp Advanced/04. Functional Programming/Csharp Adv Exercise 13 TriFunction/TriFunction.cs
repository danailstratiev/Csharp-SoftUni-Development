using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_13_TriFunction
{
    class Person
    {
        public string Name { get; set; }

        public int Value { get; set; }
    }
    class TriFunction
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(Console.ReadLine().Split().
                FirstOrDefault(x => x.ToCharArray()
                .Select(y => (int)y)
                .Sum() >= n));                
        }
    }
}
