using System;
using System.Linq;
using System.Collections.Generic;


namespace P03.GenericSwapMethodStrings
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                box.Add(line);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            Swap<string>(box.Items, firstIndex, secondIndex);

            Console.WriteLine(box);
        }

        static void Swap<T>(List<T> currentList, int firstIndex, int secondIndex)
        {
            var swap = currentList[firstIndex];
            currentList[firstIndex] = currentList[secondIndex];
            currentList[secondIndex] = swap;
        }
    }
}
