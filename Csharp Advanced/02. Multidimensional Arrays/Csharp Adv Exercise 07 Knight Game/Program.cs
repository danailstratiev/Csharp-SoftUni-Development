using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_07_Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var matrix = new char[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }

            var counter = 0;


            while (true)
            {
                var knightRow = -1;
                var knightCol = -1;
                var maxAttacked = 0;


                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (matrix[i][j] == 'K')
                        {
                            var tempAttack = CountAttack(matrix, i, j);

                            if (tempAttack > maxAttacked)
                            {
                                maxAttacked = tempAttack;
                                knightRow = i;
                                knightCol = j;
                            }
                        }                        
                    }
                }

                if (maxAttacked > 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    counter++;
                }
                else
                {
                    break;
                }

            }

            Console.WriteLine(counter);
        }

        private static int CountAttack(char[][] matrix, int i, int j)
        {
            var attack = 0;

            if (IsInMatrix(i - 1,j - 2, matrix.Length) && matrix[i-1][j - 2] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i - 1, j + 2, matrix.Length) && matrix[i - 1][j + 2] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i + 1, j - 2, matrix.Length) && matrix[i + 1][j - 2] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i + 1, j + 2, matrix.Length) && matrix[i + 1][j + 2] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i - 2, j - 1, matrix.Length) && matrix[i - 2][j - 1] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i - 2, j + 1, matrix.Length) && matrix[i - 2][j + 1] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i + 2, j + 1, matrix.Length) && matrix[i + 2][j + 1] == 'K')
            {
                attack++;
            }
            if (IsInMatrix(i + 2, j - 1, matrix.Length) && matrix[i + 2][j - 1] == 'K')
            {
                attack++;
            }

            return attack;

        }

        private static bool IsInMatrix(int i, int j, int length)
        {
            return i >= 0 && i < length && j >= 0 && j < length;

        }
    }
}
