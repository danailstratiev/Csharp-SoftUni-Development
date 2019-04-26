using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_Bombs
{
    public class Bomb
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Damage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            BombMatrix(matrix, bombs);

            var aliveCells = new int[2];

            CheckForSurvivedCells(matrix, aliveCells);

            Console.WriteLine($"Alive cells: {aliveCells[0]}");
            Console.WriteLine($"Sum: {aliveCells[1]}");

            Print(matrix);

        }

        public static void CheckForSurvivedCells(int[][] matrix, int[] aliveCells)
        {
            var countOfAliveCells = aliveCells[0];
            var sum = aliveCells[1];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > 0)
                    {
                        countOfAliveCells++;
                        sum += matrix[i][j];
                    }
                }
            }

            aliveCells[0] = countOfAliveCells;
            aliveCells[1] = sum;
        }

        private static void BombMatrix(int[][] matrix, List<string> bombs)
        {
            var bombsWithDamage = new List<Bomb>();

            GetBombs(matrix, bombs, bombsWithDamage);

            var bombQueue = new Queue<Bomb>(bombsWithDamage);

            while (bombQueue.Count > 0)
            {
                var bombToExplode = bombQueue.Dequeue();


                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        var isInBombArea = IsInBombArea(i, j, bombToExplode);

                        if (isInBombArea == true && matrix[i][j] > 0)
                        {
                            matrix[i][j] -= bombToExplode.Damage;
                        }

                        if (i == bombToExplode.Row && j == bombToExplode.Col)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }

            }
        }

        public static bool IsInBombArea(int row, int col, Bomb bombToExplode)
        {
            var bombRow = bombToExplode.Row;
            var bombCol = bombToExplode.Col;
            var willExplode = false;

            for (int i = bombRow - 1; i <= bombRow + 1; i++)
            {
                for (int j = bombCol - 1; j <= bombCol + 1; j++)
                {
                    if (row == i && col == j)
                    {
                        willExplode = true;
                    }
                }
            }

            return willExplode;
        }

        public static void GetBombs(int[][] matrix, List<string> bombs, List<Bomb> bombsWithDamage)
        {

            foreach (var bomb in bombs)
            {
                var parameters = bomb.Split(",").Select(int.Parse).ToArray();
                var currentBomb = new Bomb()
                {
                    Row = parameters[0],
                    Col = parameters[1]
                };

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (i == currentBomb.Row && j == currentBomb.Col)
                        {
                            currentBomb.Damage = matrix[i][j];
                        }
                    }
                }

                bombsWithDamage.Add(currentBomb);
            }

        }

        public static void Print(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
