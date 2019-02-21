using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_06_Reverse_and_Exclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var disibleNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(" ", numbers.Where(x => x % disibleNumber != 0).Reverse().ToList()));
        }
    }
}
