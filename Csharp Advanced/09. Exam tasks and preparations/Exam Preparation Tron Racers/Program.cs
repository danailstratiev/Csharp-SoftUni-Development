using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam_Preparation_Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];
            var playerOneCoords = new int[2];
            var playerTwoCoords = new int[2];

            FillMatrix(matrix, n);
            FindPlayerStartPositions(matrix, playerOneCoords, playerTwoCoords);

            GetDirections(matrix, playerOneCoords, playerTwoCoords);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static void GetDirections(char[][] matrix, int[] playerOneCoords, int[] playerTwoCoords)
        {
            while (true)
            {
                var input = Console.ReadLine();

                var directions = input.Split();
                var firstPlayerDirection = directions[0];
                var secondPlayerDirection = directions[1];

                FirstPlayerMove(matrix, playerOneCoords, firstPlayerDirection);
                SecondPlayerMove(matrix, playerTwoCoords, secondPlayerDirection);
            }
        }

        private static void SecondPlayerMove(char[][] matrix, int[] playerTwoCoords, string secondPlayerDirection)
        {
            var secondPlayerRow = playerTwoCoords[0];
            var secondPlayerCol = playerTwoCoords[1];

            switch (secondPlayerDirection)
            {
                case "up":
                    if (secondPlayerRow - 1 < 0)
                    {
                        var newPosition = matrix[matrix.Length - 1][secondPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[matrix.Length - 1][secondPlayerCol] = 's';
                            playerTwoCoords[0] = matrix.Length - 1;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[matrix.Length - 1][secondPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[secondPlayerRow - 1][secondPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[secondPlayerRow - 1][secondPlayerCol] = 's';
                            playerTwoCoords[0] = secondPlayerRow - 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[secondPlayerRow - 1][secondPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "down":
                    if (secondPlayerRow + 1 == matrix.Length)
                    {
                        var newPosition = matrix[0][secondPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[0][secondPlayerCol] = 's';
                            playerTwoCoords[0] = 0;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[0][secondPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[secondPlayerRow + 1][secondPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[secondPlayerRow + 1][secondPlayerCol] = 's';
                            playerTwoCoords[0] = secondPlayerRow + 1;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[secondPlayerRow + 1][secondPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "left":
                    if (secondPlayerCol - 1 < 0)
                    {
                        var newPosition = matrix[secondPlayerRow][matrix[secondPlayerRow].Length - 1];

                        if (newPosition == '*')
                        {
                            matrix[secondPlayerRow][matrix[secondPlayerRow].Length - 1] = 's';
                            playerTwoCoords[1] = matrix[secondPlayerRow].Length - 1;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[secondPlayerRow][matrix[secondPlayerRow].Length - 1] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[secondPlayerRow][secondPlayerCol - 1];

                        if (newPosition == '*')
                        {
                            matrix[secondPlayerRow][secondPlayerCol - 1] = 's';
                            playerTwoCoords[1] = secondPlayerCol - 1;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[secondPlayerRow][secondPlayerCol - 1] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "right":
                    if (secondPlayerCol + 1 == matrix[secondPlayerRow].Length)
                    {
                        var newPosition = matrix[secondPlayerRow][0];

                        if (newPosition == '*')
                        {
                            matrix[secondPlayerRow][0] = 's';
                            playerTwoCoords[1] = 0;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[secondPlayerRow][0] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[secondPlayerRow][secondPlayerCol + 1];

                        if (newPosition == '*')
                        {
                            matrix[secondPlayerRow][secondPlayerCol + 1] = 's';
                            playerTwoCoords[1] = secondPlayerCol + 1;
                        }
                        else if (newPosition == 'f')
                        {
                            matrix[secondPlayerRow][secondPlayerCol + 1] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
            }
        }

        private static void FirstPlayerMove(char[][] matrix, int[] playerOneCoords, string firstPlayerDirection)
        {
            var firstPlayerRow = playerOneCoords[0];
            var firstPlayerCol = playerOneCoords[1];

            switch (firstPlayerDirection)
            {
                case "up":
                    if (firstPlayerRow - 1 < 0)
                    {
                        var newPosition = matrix[matrix.Length - 1][firstPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[matrix.Length - 1][firstPlayerCol] = 'f';
                            playerOneCoords[0] = matrix.Length - 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[matrix.Length - 1][firstPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[firstPlayerRow - 1][firstPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[firstPlayerRow- 1 ][firstPlayerCol] = 'f';
                            playerOneCoords[0] = firstPlayerRow - 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[firstPlayerRow - 1][firstPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "down":
                    if (firstPlayerRow + 1 == matrix.Length)
                    {
                        var newPosition = matrix[0][firstPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[0][firstPlayerCol] = 'f';
                            playerOneCoords[0] = 0;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[0][firstPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[firstPlayerRow+1][firstPlayerCol];

                        if (newPosition == '*')
                        {
                            matrix[firstPlayerRow + 1][firstPlayerCol] = 'f';
                            playerOneCoords[0] = firstPlayerRow + 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[firstPlayerRow + 1][firstPlayerCol] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "left":
                    if (firstPlayerCol - 1 < 0)
                    {
                        var newPosition = matrix[firstPlayerRow][matrix[firstPlayerRow].Length - 1];

                        if (newPosition == '*')
                        {
                            matrix[firstPlayerRow][matrix[firstPlayerRow].Length - 1] = 'f';
                            playerOneCoords[1] = matrix[firstPlayerRow].Length - 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[firstPlayerRow][matrix[firstPlayerRow].Length - 1] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[firstPlayerRow][firstPlayerCol - 1];

                        if (newPosition == '*')
                        {
                            matrix[firstPlayerRow][firstPlayerCol - 1] = 'f';
                            playerOneCoords[1] = firstPlayerCol - 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[firstPlayerRow][firstPlayerCol - 1] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
                case "right":
                    if (firstPlayerCol + 1 == matrix[firstPlayerRow].Length)
                    {
                        var newPosition = matrix[firstPlayerRow][0];

                        if (newPosition == '*')
                        {
                            matrix[firstPlayerRow][0] = 'f';
                            playerOneCoords[1] = 0;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[firstPlayerRow][0] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        var newPosition = matrix[firstPlayerRow][firstPlayerCol + 1];

                        if (newPosition == '*')
                        {
                            matrix[firstPlayerRow][firstPlayerCol + 1] = 'f';
                            playerOneCoords[1] = firstPlayerCol + 1;
                        }
                        else if (newPosition == 's')
                        {
                            matrix[firstPlayerRow][firstPlayerCol + 1] = 'x';
                            PrintMatrix(matrix);
                            Environment.Exit(0);
                        }
                    }
                    break;
            }
        }

        private static void FindPlayerStartPositions(char[][] matrix, int[] playerOneCoords, int[] playerTwoCoords)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'f')
                    {
                        playerOneCoords[0] = i;
                        playerOneCoords[1] = j;
                    }
                    else if (matrix[i][j] == 's')
                    {
                        playerTwoCoords[0] = i;
                        playerTwoCoords[1] = j;
                    }
                }
            }
        }

        private static void FillMatrix(char[][] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
