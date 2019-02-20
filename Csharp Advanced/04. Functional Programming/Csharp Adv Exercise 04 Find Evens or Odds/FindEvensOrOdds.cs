using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_04_Find_Evens_or_Odds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            var boundaries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var startIndex = boundaries[0];
            var endIndex = boundaries[1];

            var type = Console.ReadLine();
            var numbers = new HashSet<int>();
            
            for (int i = startIndex; i <= endIndex; i++)
            {
                numbers.Add(i);
            }

            if (type == "even")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 == 0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", numbers.Where(x => x % 2 != 0)));
            }

        }
    }
}
