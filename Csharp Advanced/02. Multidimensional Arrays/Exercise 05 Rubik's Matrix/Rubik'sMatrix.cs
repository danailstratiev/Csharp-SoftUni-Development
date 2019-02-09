using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_05_Rubik_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];

            var rubikMatrix = new int[rows][];
            var counter = 1;

            for (int i = 0; i < rubikMatrix.Length; i++)
            {
                rubikMatrix[i] = new int[cols];

                for (int j = 0; j < rubikMatrix[i].Length; j++)
                {
                    rubikMatrix[i][j] = counter++;
                }
            }

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var rowColIndex = int.Parse(commands[0]);
                var direction = commands[1];
                var moves = int.Parse(commands[2]);

                if (direction == "down")
                {
                    MoveDown(rubikMatrix, moves % rubikMatrix.Length, rowColIndex);
                }
                else if (direction == "left")
                {
                    MoveLeft(rubikMatrix, moves % rubikMatrix[rowColIndex].Length, rowColIndex);
                }
                else if (direction == "right")
                {
                    MoveRight(rubikMatrix, moves % rubikMatrix[rowColIndex].Length, rowColIndex);
                }
                else if (direction == "up")
                {
                    MoveUp(rubikMatrix, moves % rubikMatrix.Length, rowColIndex);
                }
            }
            
            var someCounter = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    if (rubikMatrix[row][col] == someCounter)
                    {
                        Console.WriteLine("No swap required");
                        someCounter++;
                    }
                    else
                    {
                        Rearrange(rubikMatrix, row, col, someCounter);
                        someCounter++;
                    }
                }
            }
        }

        private static void Rearrange(int[][] rubikMatrix, int row, int col, int someCounter)
        {
            for (int i = 0; i < rubikMatrix.Length; i++)
            {
                for (int j = 0; j < rubikMatrix[i].Length; j++)
                {
                    if (rubikMatrix[i][j] == someCounter)
                    {
                        rubikMatrix[i][j] = rubikMatrix[row][col];
                        rubikMatrix[row][col] = someCounter;

                        Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                        return;
                    }
                }
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int moves, int col)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstNumber = rubikMatrix[0][col];

                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row + 1][col];
                }

                rubikMatrix[rubikMatrix.Length - 1][col] = firstNumber;
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int moves, int rows)
        {
            for (int i = 0; i < moves; i++)
            {
                var lastElement = rubikMatrix[rows][rubikMatrix[rows].Length - 1];

                for (int col = rubikMatrix.Length - 1; col > 0; col--)
                {
                    rubikMatrix[rows][col] = rubikMatrix[rows][col - 1];
                }

                rubikMatrix[rows][0] = lastElement;
            }
        }

        private static void MoveLeft(int[][] rubikMatrix, int moves, int row)
        {
            for (int i = 0; i < moves; i++)
            {
                var firstElement = rubikMatrix[row][0];

                for (int col = 0; col < rubikMatrix[row].Length - 1; col++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col + 1];
                }

                rubikMatrix[row][rubikMatrix[row].Length - 1] = firstElement;
            }            
        }

        private static void MoveDown(int[][] rubikMatrix, int moves, int col)
        {
            for (int i = 0; i < moves; i++)
            {
                var lastElement = rubikMatrix[rubikMatrix.Length - 1][col];

                for (int j = rubikMatrix.Length - 1; j > 0; j--)
                {
                    rubikMatrix[j][col] = rubikMatrix[j - 1][col];
                }

                rubikMatrix[0][col] = lastElement;
            }
        }

        public static void Print (int[][] rubikMatrix)
        {
            foreach (var item in rubikMatrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
