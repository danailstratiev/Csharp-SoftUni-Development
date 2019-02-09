using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_02_Diagonal_DIfference
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize, matrixSize];
            var antiMatrix = new int[matrixSize, matrixSize];

            var sumOfPrimaryDiagonal = 0;
            var sumOfSecondaryDiagonal = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }

                var reversedElements = elements.Reverse().ToArray();

                for (int k = 0; k < antiMatrix.GetLength(1); k++)
                {
                    antiMatrix[i,k] = reversedElements[k];
                }
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (i == j)
                    {
                        sumOfPrimaryDiagonal += matrix[i, j];
                        break;
                    }
                }
            }

            for (int i = antiMatrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < antiMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sumOfSecondaryDiagonal += antiMatrix[i,j];
                        break;
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal));
        }
    }
}
