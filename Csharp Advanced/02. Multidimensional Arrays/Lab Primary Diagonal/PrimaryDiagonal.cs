using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_Primary_Diagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sumOfDiagonal = 0;

            var matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];

                    if (i == j)
                    {
                        sumOfDiagonal += matrix[i, j];
                    }
                }
            }

            Console.WriteLine(sumOfDiagonal);
        }
    }
}
