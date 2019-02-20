using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_02_Knights_of_Honor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Action<string> beKnighted = k => Console.WriteLine($"Sir {k}");

            foreach (var name in names)
            {
                beKnighted(name);
            }
        }
    }
}
