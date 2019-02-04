using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_01_Reverse_Numbers_with_a_Stack
{
    class ReverseNumbersWithAStack
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var stack = new Stack<int>(numbers);

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }

            Console.WriteLine();
        }
    }
}
