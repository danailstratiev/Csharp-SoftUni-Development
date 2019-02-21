using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_07_Predicate_for_Names
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            var allowedNameLength = int.Parse(Console.ReadLine());
            var validNames = Console.ReadLine().Split().Where(x => x.Length <= allowedNameLength).
                ToList();

            foreach (var name in validNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
