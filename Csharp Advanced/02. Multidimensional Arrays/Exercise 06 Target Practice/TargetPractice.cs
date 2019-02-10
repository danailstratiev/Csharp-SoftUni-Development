using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_06_Target_Practice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];

            var snakeName = Console.ReadLine();
            var shotParameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stairsMatrix = new char[rows][];

            FillMatrix(stairsMatrix, cols, snakeName);

            Shoot(stairsMatrix, shotParameters);

            Collapse(stairsMatrix);

            Print(stairsMatrix);

        }

        private static void Collapse(char[][] stairsMatrix)
        {
            var elements = new Queue<char>();

            for (int col = 0; col < stairsMatrix[0].Length; col++)
            {
                var counter = 0;

                for (int row = 0; row < stairsMatrix.Length; row++)
                {
                    if (stairsMatrix[row][col] != ' ')
                    {
                        elements.Enqueue(stairsMatrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    stairsMatrix[row][col] = ' ';
                }

                for (int row = counter; row < stairsMatrix.Length; row++)
                {
                    stairsMatrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] stairsMatrix, int[] shotParameters)
        {
            var targetRow = shotParameters[0];
            var targetCol = shotParameters[1];
            var targetDamage = shotParameters[2];

            for (int i = 0; i < stairsMatrix.Length; i++)
            {
                for (int j = 0; j < stairsMatrix[i].Length; j++)
                {
                    bool isInside = Math.Pow((targetRow - i), 2) + Math.Pow((targetCol - j), 2) <= Math.Pow(targetDamage, 2);

                    if (isInside)
                    {
                        stairsMatrix[i][j] = ' ';
                    }
                }
            }
        }

        private static void Print(char[][] stairsMatrix)
        {
            foreach (var item in stairsMatrix)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void FillMatrix(char[][] stairsMatrix, int cols, string snakeName)
        {
            var counter = 0;
            bool isLeft = true;

            for (int i = stairsMatrix.Length - 1; i >= 0 ; i--)
            {
                stairsMatrix[i] = new char[cols];

                if (isLeft)
                {
                    for (int j = stairsMatrix[i].Length - 1; j >= 0; j--)
                    {
                        stairsMatrix[i][j] = snakeName[counter];
                        counter++;

                        if (counter >= snakeName.Length)
                        {
                            counter = 0;
                        }
                    }

                    isLeft = false;
                }
                else
                {
                    for (int j = 0; j < stairsMatrix[i].Length; j++)
                    {
                        stairsMatrix[i][j] = snakeName[counter];
                        counter++;

                        if (counter >= snakeName.Length)
                        {
                            counter = 0;
                        }
                    }

                    isLeft = true;
                }
            }
        }
    }
}
