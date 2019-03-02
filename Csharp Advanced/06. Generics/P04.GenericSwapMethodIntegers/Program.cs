using System;
using System.Linq;
using System.Collections.Generic;


namespace P04.GenericSwapMethodIntegers
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                box.Add(currentNumber);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            Swap(box.Items, firstIndex, secondIndex);

        }
        public static void Swap(List<int> elements, int first, int second)
        {
            var value = elements[first];
            elements[first] = elements[second];
            elements[second] = value;
        }
    }
}
