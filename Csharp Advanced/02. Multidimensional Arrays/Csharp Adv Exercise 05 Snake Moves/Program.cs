using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_05_Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new char[rows, cols];
            var snakeName = Console.ReadLine();

            FillMatrix(matrix, snakeName);
            Print(matrix);
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(char[,] matrix, string snakeName)
        {
            var counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = snakeName[counter];
                    counter++;

                    if (counter >= snakeName.Length)
                    {
                        counter = 0;
                    }
                }
            }
        }
    }
}
