using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] matrix;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n][];

            FillMatrix(matrix, n);
            

            var moves = Console.ReadLine().ToCharArray();
            int[] samPosition = new int[2];

            FindSam(matrix, samPosition);
            for (int i = 0; i < moves.Length; i++)
            {
                EnemiesMove(matrix, moves);

                int[] getEnemy = new int[2];

                GetEnemy(getEnemy, matrix, samPosition);
                
                if (samPosition[1] < getEnemy[1] && matrix[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
                {
                    matrix[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    PrintMatrix(matrix);

                    return;
                }
                else if (getEnemy[1] < samPosition[1] && matrix[getEnemy[0]][getEnemy[1]] == 'b' &&
                    getEnemy[0] == samPosition[0])
                {
                    matrix[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    PrintMatrix(matrix);
                    return;
                }

                SamMoves(moves, matrix, i, samPosition);
               
                matrix[samPosition[0]][samPosition[1]] = 'S';

                for (int j = 0; j < matrix[samPosition[0]].Length; j++)
                {
                    if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }
                if (matrix[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    matrix[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    PrintMatrix(matrix);
                    return;
                }
            }
        }

        public static void EnemiesMove(char[][] matrix, char[] moves)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (row >= 0 && row < matrix.Length && col + 1 >= 0 && col + 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (row >= 0 && row < matrix.Length && col - 1 >= 0 && col - 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                        }
                    }
                }
            }

        }

        public static void GetEnemy(int[] getEnemy, char[][] matrix, int[] samPosition)
        {
            for (int j = 0; j < matrix[samPosition[0]].Length; j++)
            {
                if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        public static void SamMoves(char[] moves, char[][] matrix, int i, int[] samPosition)
        {
            matrix[samPosition[0]][samPosition[1]] = '.';
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(matrix[row]);                
            }

            return;
        }

        public static void FindSam(char[][] matrix, int[] samPosition)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        public static void FillMatrix(char[][] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();                
            }
        }
    }
}
