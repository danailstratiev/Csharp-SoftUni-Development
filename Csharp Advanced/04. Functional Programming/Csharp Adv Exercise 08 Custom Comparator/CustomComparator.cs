using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_08_Custom_Comparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var oddNums = numbers.Where(x => x % 2 != 0).ToList();
            oddNums.Sort();
            var evenNums = numbers.Where(x => x % 2 == 0).ToList();
            evenNums.Sort();

            foreach (var odd in oddNums)
            {
                evenNums.Add(odd);
            }
            Console.WriteLine(string.Join(" ", evenNums));

        }
    }
}
