using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_08_Radioactive_Mutant_Vampire_Bunnies
{
    class Bunny
    {
        public Bunny(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }
    class Bunnicula
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrixLength = parameters[0];
            var matrix = new char[matrixLength][];
            var player = new int[2];
            var bunnies = new Queue<Bunny>();

            FillMatrix(matrix, player, bunnies);

            var directions = Console.ReadLine().ToCharArray();

            PlayTime(matrix, bunnies, player, directions);
        }

        private static void PlayTime(char[][] matrix, Queue<Bunny> bunnies, int[] player, char[] directions)
        {
            var playerIsDead = false;
            var playerHasWon = false;

            for (int i = 0; i < directions.Length; i++)
            {
                if (playerIsDead == true)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {player[0]} {player[1]}");
                    return;
                }

                if (playerHasWon == true)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {player[0]} {player[1]}");
                    return;
                }

                var currentDirection = directions[i];
                var playerRow = player[0];
                var playerCol = player[1];

                switch (currentDirection)
                {
                    case 'U':
                        if (playerRow - 1 < 0)
                        {
                            playerHasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow - 1][playerCol] == '.')
                            {
                                matrix[playerRow - 1][playerCol] = 'P';
                                matrix[playerRow][playerCol] = '.';
                                player[0]--;
                            }
                            else if (matrix[playerRow - 1][playerCol] == 'B')
                            {
                                matrix[playerRow][playerCol] = '.';
                                player[0]--;
                                playerIsDead = true;
                            }
                        }
                        break;
                    case 'D':
                        if (playerRow + 1 == matrix.Length)
                        {
                            playerHasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow + 1][playerCol] == '.')
                            {
                                matrix[playerRow + 1][playerCol] = 'P';
                                matrix[playerRow][playerCol] = '.';
                                player[0]++;
                            }
                            else if (matrix[playerRow + 1][playerCol] == 'B')
                            {
                                matrix[playerRow][playerCol] = '.';
                                player[0]++;
                                playerIsDead = true;
                            }
                        }
                        break;
                    case 'L':
                        if (playerCol - 1 < 0)
                        {
                            playerHasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow][playerCol - 1] == '.')
                            {
                                matrix[playerRow][playerCol - 1] = 'P';
                                matrix[playerRow][playerCol] = '.';
                                player[1]--;
                            }
                            else if (matrix[playerRow][playerCol - 1] == 'B')
                            {
                                matrix[playerRow][playerCol] = '.';
                                player[1]--;
                                playerIsDead = true;
                            }
                        }
                        break;
                    case 'R':
                        if (playerCol + 1 == matrix[i].Length)
                        {
                            playerHasWon = true;
                            matrix[playerRow][playerCol] = '.';
                        }
                        else
                        {
                            if (matrix[playerRow][playerCol + 1] == '.')
                            {
                                matrix[playerRow][playerCol + 1] = 'P';
                                matrix[playerRow][playerCol] = '.';
                                player[1]++;
                            }
                            else if (matrix[playerRow][playerCol + 1] == 'B')
                            {
                                matrix[playerRow][playerCol] = '.';
                                player[1]++;
                                playerIsDead = true;
                            }
                        }
                        break;
                }

                EnqueueBunnies(matrix, bunnies);

                playerIsDead = DequeueBunnies(matrix, bunnies, playerIsDead);
            }

            if (playerIsDead == true)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"dead: {player[0]} {player[1]}");
                return;
            }

            if (playerHasWon == true)
            {
                PrintMatrix(matrix);
                Console.WriteLine($"won: {player[0]} {player[1]}");
                return;
            }
        }

        private static bool DequeueBunnies(char[][] matrix, Queue<Bunny> bunnies, bool playerIsDead)
        {
            while (bunnies.Count > 0)
            {
                var currentBunny = bunnies.Dequeue();

                var bunnyRow = currentBunny.Row;
                var bunnyCol = currentBunny.Col;

                if (bunnyRow - 1 >= 0)
                {
                    if (matrix[bunnyRow - 1][bunnyCol] == 'P')
                    {
                        playerIsDead = true;
                    }

                    matrix[bunnyRow - 1][bunnyCol] = 'B';
                }

                if (bunnyRow + 1 < matrix.Length)
                {
                    if (matrix[bunnyRow + 1][bunnyCol] == 'P')
                    {
                        playerIsDead = true;
                    }

                    matrix[bunnyRow + 1][bunnyCol] = 'B';
                }

                if (bunnyCol - 1 >= 0)
                {
                    if (matrix[bunnyRow][bunnyCol - 1] == 'P')
                    {
                        playerIsDead = true;
                    }

                    matrix[bunnyRow][bunnyCol - 1] = 'B';
                }

                if (bunnyCol + 1 < matrix[bunnyRow].Length)
                {
                    if (matrix[bunnyRow][bunnyCol + 1] == 'P')
                    {
                        playerIsDead = true;
                    }

                    matrix[bunnyRow][bunnyCol + 1] = 'B';
                }
            }

            return playerIsDead;
        }

        private static void EnqueueBunnies(char[][] matrix, Queue<Bunny> bunnies)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'B')
                    {
                        var bunny = new Bunny(i, j);
                        bunnies.Enqueue(bunny);
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static void FillMatrix(char[][] matrix, int[] player, Queue<Bunny> bunnies)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

                if (matrix[i].Contains('P'))
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 'P')
                        {
                            player[0] = i;
                            player[1] = j;
                            break;
                        }
                    }
                }
            }
        }
    }
}
