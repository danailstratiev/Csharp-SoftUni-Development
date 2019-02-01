using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Exercise_03_Max_and_Min_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var command = input[0];

                switch (command)
                {
                    case 1:
                        var number = input[1];
                        stack.Push(number);
                        break;
                    case 2:
                        if (stack.Count != 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count != 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Count != 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
