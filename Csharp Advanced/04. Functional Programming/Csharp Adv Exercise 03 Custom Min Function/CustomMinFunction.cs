using System;
using System.Collections.Generic;
using System.Linq;


namespace Csharp_Adv_Exercise_03_Custom_Min_Function
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<List<int>, int> minNUmber = x => x.Min();

            Console.WriteLine(minNUmber(numbers));
        }
    }
}
