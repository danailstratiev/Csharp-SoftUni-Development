using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Group_Numbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[3][];

            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            jaggedArray[0] = input
                .Where(x => Math.Abs(x) % 3 == 0)
                .ToArray();

            jaggedArray[1] = input
                .Where(x => Math.Abs(x) % 3 == 1)
                .ToArray();

            jaggedArray[2] = input
                .Where(x => Math.Abs(x) % 3 == 2)
                .ToArray();

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}
