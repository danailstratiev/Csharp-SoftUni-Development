using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_09_List_of_Predicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            var boundary = int.Parse(Console.ReadLine());
            var divisibleNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = new HashSet<int>();

            for (int i = 1 ; i <= boundary; i++)
            {
                bool isDivisible = true;

                foreach (var divisible in divisibleNums)
                {
                    if (i % divisible != 0)
                    {
                        isDivisible = false;
                    }
                }

                if (isDivisible)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
