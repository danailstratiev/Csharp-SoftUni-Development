using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_01_Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var conditions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var stackLength = conditions[0];
            var elementsToPop = conditions[1];
            var numberToFind = conditions[2];
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < stackLength; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
