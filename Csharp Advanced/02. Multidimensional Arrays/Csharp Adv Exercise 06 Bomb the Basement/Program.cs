using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_06_Bomb_the_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var bomb = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new int[parameters[0], parameters[1]];
            var bombRow = bomb[0];
            var bombCol = bomb[1];
            var bombDamage = bomb[2];

            FillMatrix(matrix);
            BombMatrix(matrix, bombRow, bombCol, bombDamage);
            AdjustMatrix(matrix);
            Print(matrix);
        }

        private static void AdjustMatrix(int[,] matrix)
        {
            var queue = new Queue<int>();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] == 1)
                    {
                        queue.Enqueue(1);
                        matrix[j, i] = 0;
                    }
                }

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (queue.Count > 0)
                    {
                        matrix[j, i] = queue.Dequeue();
                    }
                }
            }
        }

        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void BombMatrix(int[,] matrix, int bombRow, int bombCol, int bombDamage)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == bombRow && j == bombCol)
                    {
                        matrix[i, j] = 1;
                    }
                    if (Math.Pow(bombRow - i , 2) + Math.Pow(bombCol - j, 2) <= Math.Pow(bombDamage, 2))
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
    }
}
