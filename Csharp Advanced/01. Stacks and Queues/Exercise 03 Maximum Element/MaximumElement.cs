using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_03_Maximum_Element
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var properties = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                var command = properties[0];

                switch (command)
                {
                     case 1:
                        stack.Push(properties[1]);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        Console.WriteLine($"{stack.Max()}");
                        break;
                }
            }
        }
    }
}
