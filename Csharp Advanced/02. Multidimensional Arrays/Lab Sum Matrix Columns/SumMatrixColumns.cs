using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Sum_Matrix_Columns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            var matrixParameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rows = matrixParameters[0];
            var cols = matrixParameters[1];

            var calculatingArray = new int[cols];
            var matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                    calculatingArray[j] += elements[j];
                }
            }

            foreach (var sum in calculatingArray)
            {
                Console.WriteLine(sum);
            }
        }
    }
}
