using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_07_Lego_Blocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var firstMatrix = new int[n][];
            var secondMatrix = new int[n][];

            for (int i = 0; i < firstMatrix.Length; i++)
            {
                firstMatrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            for (int i = 0; i < secondMatrix.Length; i++)
            {
                secondMatrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            ReverseMatrix(secondMatrix);
            var firstSum = 0;
            var secondSum = 0;

            var doesFit = true;

            for (int i = 1; i < firstMatrix.Length; i++)
            {
                if (firstMatrix[0].Length + secondMatrix[0].Length != firstMatrix[i].Length + secondMatrix[i].Length)
                {
                    doesFit = false;
                    break;
                }
            }

            if (doesFit == true)
            {
                PrintMatrix(firstMatrix, secondMatrix);
            }
            else
            {
                CountElements(firstMatrix, secondMatrix, firstSum, secondSum, n);
            }
        }

        private static void PrintMatrix(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int i = 0; i < firstMatrix.Length; i++)
            {
                Console.Write("[");
                for (int j = 0; j < firstMatrix[i].Length; j++)
                {
                    Console.Write($"{firstMatrix[i][j]}, ");
                }
                for (int j = 0; j < secondMatrix[i].Length; j++)
                {
                    if (j == secondMatrix[i].Length - 1)
                    {
                        Console.WriteLine($"{secondMatrix[i][j]}]");
                    }
                    else
                    {
                        Console.Write($"{secondMatrix[i][j]}, ");
                    }
                }
            }
        }

        private static void CountElements(int[][] firstMatrix, int[][] secondMatrix, int firstSum, int secondSum, int n)
        {
            for (int i = 0; i < n; i++)
            {
                firstSum += firstMatrix[i].Length;
                secondSum += secondMatrix[i].Length;
            }

            Console.WriteLine($"The total number of cells is: {firstSum + secondSum}");
        }

        private static void ReverseMatrix(int[][] secondMatrix)
        {
            for (int i = 0; i < secondMatrix.Length; i++)
            {
                secondMatrix[i] = secondMatrix[i].Reverse().ToArray();
            }
        }
    }
}
