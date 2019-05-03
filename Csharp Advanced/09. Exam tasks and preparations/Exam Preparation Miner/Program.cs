using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];
            var directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var directionsQueue = new Queue<string>(directions);

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            var minerStats = new int[3];
            FindMiner(matrix, minerStats);
            var allCoals = 0;
            allCoals = CountCrystals(matrix);

            var minerRow = minerStats[0];
            var minerCol = minerStats[1];
            var coalsCollected = minerStats[2];

            while (directionsQueue.Count > 0)
            {
                var currentDirection = directionsQueue.Dequeue();

                switch (currentDirection)
                {
                    case "up":
                        if (minerRow - 1 >= 0)
                        {
                            var symbol = matrix[minerRow - 1][minerCol];
                            switch (symbol)
                            {
                                case '*':
                                    matrix[minerRow - 1][minerCol] = 's';
                                    matrix[minerRow][minerCol] = '*';
                                    minerRow--;
                                    break;
                                case 'e':
                                    GameOver(minerRow - 1, minerCol);
                                    return;
                                case 'c':
                                    coalsCollected++;

                                    if (coalsCollected == allCoals)
                                    {
                                        Victory(minerRow - 1, minerCol);
                                        return;
                                    }
                                    else
                                    {
                                        matrix[minerRow - 1][minerCol] = 's';
                                        matrix[minerRow][minerCol] = '*';
                                        minerRow--;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "right":
                        if (minerCol + 1 < n)
                        {
                            var symbol = matrix[minerRow][minerCol + 1];
                            switch (symbol)
                            {
                                case '*':
                                    matrix[minerRow][minerCol + 1] = 's';
                                    matrix[minerRow][minerCol] = '*';
                                    minerCol++;
                                    break;
                                case 'e':
                                    GameOver(minerRow, minerCol + 1);
                                    return;
                                case 'c':
                                    coalsCollected++;

                                    if (coalsCollected == allCoals)
                                    {
                                        Victory(minerRow, minerCol + 1);
                                        return;
                                    }
                                    else
                                    {
                                        matrix[minerRow][minerCol + 1] = 's';
                                        matrix[minerRow][minerCol] = '*';
                                        minerCol++;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "down":
                        if (minerRow + 1 < n)
                        {
                            var symbol = matrix[minerRow + 1][minerCol];
                            switch (symbol)
                            {
                                case '*':
                                    matrix[minerRow + 1][minerCol] = 's';
                                    matrix[minerRow][minerCol] = '*';
                                    minerRow++;
                                    break;
                                case 'e':
                                    GameOver(minerRow + 1, minerCol);
                                    return;
                                case 'c':
                                    coalsCollected++;

                                    if (coalsCollected == allCoals)
                                    {
                                        Victory(minerRow + 1, minerCol);
                                        return;
                                    }
                                    else
                                    {
                                        matrix[minerRow + 1][minerCol] = 's';
                                        matrix[minerRow][minerCol] = '*';
                                        minerRow++;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "left":
                        if (minerCol - 1 >= 0)
                        {
                            var symbol = matrix[minerRow][minerCol - 1];
                            switch (symbol)
                            {
                                case '*':
                                    matrix[minerRow][minerCol - 1] = 's';
                                    matrix[minerRow][minerCol] = '*';
                                    minerCol--;
                                    break;
                                case 'e':
                                    GameOver(minerRow, minerCol - 1);
                                    return;
                                case 'c':
                                    coalsCollected++;

                                    if (coalsCollected == allCoals)
                                    {
                                        Victory(minerRow, minerCol - 1);
                                        return;
                                    }
                                    else
                                    {
                                        matrix[minerRow][minerCol - 1] = 's';
                                        matrix[minerRow][minerCol] = '*';
                                        minerCol--;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }
            }

            Console.WriteLine($"{allCoals - coalsCollected} coals left. ({minerRow}, {minerCol})");
        }
        private static void Victory(int minerRow, int minerCol)
        {
            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
        }

        public static void GameOver(int minerRow, int minerCol)
        {
            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
        }

        private static int CountCrystals(char[][] matrix)
        {
            int allCoals = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            return allCoals;
        }

        public static void FindMiner(char[][] matrix, int[] minerStats)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 's')
                    {
                        minerStats[0] = i;
                        minerStats[1] = j;
                        minerStats[2] = 0;
                    }
                }
            }
        }

        public static void Print(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(matrix[i]);
            }
        }
    }
}
