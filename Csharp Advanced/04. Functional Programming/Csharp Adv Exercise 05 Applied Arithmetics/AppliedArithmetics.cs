using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_05_Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => x + 1).ToList();
                        break;
                    case "multipy":
                        numbers = numbers.Select(x => x * 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x - 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
