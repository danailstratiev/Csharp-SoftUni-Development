using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Pascal_Triangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rowCount][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new int[i + 1];
                jaggedArray[i][0] = 1;
                jaggedArray[i][i] = 1;

            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i].Length > 2)
                {
                    for (int j = 1; j < jaggedArray[i].Length - 1; j++)
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j] + jaggedArray[i - 1][j - 1];
                    }
                }
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
