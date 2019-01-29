using System;
using System.Collections.Generic;


namespace Lab_1_Reverse_Strings
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            Stack<char> stringReverser = new Stack<char>();

            string input = Console.ReadLine();

            foreach (var symbol in input)
            {
                stringReverser.Push(symbol);
            }

            while (stringReverser.Count > 0)
            {
                Console.Write(stringReverser.Pop());
            }

            Console.WriteLine();
        }
    }
}
