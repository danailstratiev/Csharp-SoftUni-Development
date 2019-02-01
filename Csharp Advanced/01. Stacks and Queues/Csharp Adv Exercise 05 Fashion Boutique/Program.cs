using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_05_Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(clothes);
            var sum = 0;
            var counter = 1;

            while (true)
            {
                if (stack.Count == 0)
                {
                    break;
                }                

                if (sum + stack.Peek() <= rackCapacity)
                {
                  sum += stack.Pop();
                }
                else
                {
                    sum = 0;
                    counter++;
                }                              
            }

            Console.WriteLine(counter);

        }
    }
}
