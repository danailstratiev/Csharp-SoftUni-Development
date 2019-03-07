using System;
using System.Linq;
using System.Collections.Generic;


namespace P03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (input.Contains("Push"))
                {
                    var elementsToPush = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    for (int i = 1; i < elementsToPush.Length; i++)
                    {
                        stack.Push(elementsToPush[i]);
                    }
                }
                else if (input == "Pop")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                    }
                }

                input = Console.ReadLine();
            }

            var helper = new List<string>();
            var stackCount = stack.Count();

            for (int i = 0; i < stackCount; i++)
            {
                var poppedNumber = stack.Pop();
                helper.Add(poppedNumber);
                Console.WriteLine(poppedNumber);
            }

            for (int i = 0; i < stackCount; i++)
            {
                Console.WriteLine(helper[i]);
            }

            
        }
    }
}
