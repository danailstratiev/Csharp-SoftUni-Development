using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_04_Maximal_Sum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];
            var startRow = -1;
            var endRow = -1;
            var startCol = -1;
            var endCol = -1;
            var maxSum = int.MinValue;

            var matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            for (int i = 1; i < matrix.GetLength(0) - 1; i++)
            {
                var sum = 0;

                for (int j = 1; j < matrix.GetLength(1) - 1; j++)
                {
                    sum += matrix[i - 1, j - 1] + matrix[i - 1, j] + matrix[i - 1, j + 1]
                        + matrix[i, j - 1] + matrix[i, j] + matrix[i, j + 1]
                        + matrix[i + 1, j - 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = i - 1;
                        endRow = i + 1;
                        startCol = j - 1;
                        endCol = j + 1;
                    }

                    sum = 0;
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
