using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_01_Action_Point
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> printName = name => Console.WriteLine(name);

            foreach (var name in names)
            {
                printName(name);
            }
        }
    }
}
