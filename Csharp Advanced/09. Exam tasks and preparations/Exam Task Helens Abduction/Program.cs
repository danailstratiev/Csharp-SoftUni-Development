using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamTask.HelensAbduction
{
    class Paris
    {
        public Paris(int energy)
        {
            Energy = energy;
        }

        public int Energy { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var energyOfParis = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var coordsOfHelen = new int[2];
            var paris = new Paris(energyOfParis);

            var matrix = new char[n][];

            FillMatrix(matrix, n);
            FindHelenAndParis(matrix, coordsOfHelen, paris);

            AbductionTime(matrix, coordsOfHelen, paris);
        }

        //TO DO Try with initial energy decrease
        private static void AbductionTime(char[][] matrix, int[] coordsOfHelen, Paris paris)
        {
            var parisIsDead = false;
            var parisGotHelen = false;

            while (true)
            {
                if (parisIsDead == true)
                {
                    Console.WriteLine($"Paris died at {paris.Row};{paris.Col}.");
                    PrintMatrix(matrix);
                    return;
                }

                if (parisGotHelen == true)
                {
                    if (paris.Energy < 0)
                    {
                        paris.Energy = 0;
                    }
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {paris.Energy}");
                    PrintMatrix(matrix);
                    return;
                }

                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var direction = input[0];
                var enemyRow = int.Parse(input[1]);
                var enemyCol = int.Parse(input[2]);

                matrix[enemyRow][enemyCol] = 'S';
               
                switch (direction)
                {
                    case "up":
                        if (paris.Row - 1 < 0)
                        {
                            paris.Energy--;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                continue;
                            }

                            continue;
                        }
                        if (paris.Row - 1 >= 0)
                        {
                            paris.Row--;                            
                        }
                        if (matrix[paris.Row][paris.Col] == 'H')
                        {
                            parisGotHelen = true;
                            matrix[paris.Row + 1][paris.Col] = '-';
                            matrix[paris.Row][paris.Col] = '-';
                            paris.Energy--;
                        }
                        else if (matrix[paris.Row][paris.Col] == 'S')
                        {
                            paris.Energy--;
                            paris.Energy -= 2;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row + 1][paris.Col] = '-';
                                continue;
                            }
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        else if (matrix[paris.Row][paris.Col] == '-')
                        {
                            paris.Energy--;

                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row + 1][paris.Col] = '-';
                                continue;
                            }

                            matrix[paris.Row + 1][paris.Col] = '-';
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        
                        break;
                    case "down":
                        if (paris.Row + 1 >= matrix.Length)
                        {
                            paris.Energy--;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                continue;
                            }

                            continue;
                        }
                        if (paris.Row + 1 < matrix.Length)
                        {
                            paris.Row++;
                        }
                        if (matrix[paris.Row][paris.Col] == 'H')
                        {
                            parisGotHelen = true;
                            matrix[paris.Row - 1][paris.Col] = '-';
                            matrix[paris.Row][paris.Col] = '-';
                            paris.Energy--;
                            continue;
                        }
                        else if (matrix[paris.Row][paris.Col] == 'S')
                        {
                            paris.Energy--;
                            paris.Energy -= 2;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row - 1][paris.Col] = '-';

                                continue;
                            }
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        else if (matrix[paris.Row][paris.Col] == '-')
                        {
                            paris.Energy--;

                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row - 1][paris.Col] = '-';

                                continue;
                            }

                            matrix[paris.Row - 1][paris.Col] = '-';
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        
                        break;
                    case "left":
                        if (paris.Col - 1 < 0)
                        {
                            paris.Energy--;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                continue;
                            }
                            continue;
                        }
                        if (paris.Col - 1 >= 0)
                        {
                            paris.Col--;
                        }
                        if (matrix[paris.Row][paris.Col] == 'H')
                        {
                            parisGotHelen = true;
                            matrix[paris.Row][paris.Col + 1] = '-';
                            matrix[paris.Row][paris.Col] = '-';
                            paris.Energy--;
                        }
                        else if (matrix[paris.Row][paris.Col] == 'S')
                        {
                            paris.Energy--;
                            paris.Energy -= 2;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row][paris.Col + 1] = '-';

                                continue;
                            }
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        else if (matrix[paris.Row][paris.Col] == '-')
                        {
                            paris.Energy--;

                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row][paris.Col + 1] = '-';

                                continue;
                            }

                            matrix[paris.Row][paris.Col + 1] = '-';
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        
                        break;
                    case "right":
                        if (paris.Col + 1 >= matrix[paris.Row].Length)
                        {
                            paris.Energy--;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                continue;
                            }

                            continue;
                        }
                        if (paris.Col + 1 < matrix[paris.Row].Length)
                        {
                            paris.Col++;
                        }
                        if (matrix[paris.Row][paris.Col] == 'H')
                        {
                            parisGotHelen = true;
                            matrix[paris.Row][paris.Col - 1] = '-';
                            matrix[paris.Row][paris.Col] = '-';
                            paris.Energy--;
                        }
                        else if (matrix[paris.Row][paris.Col] == 'S')
                        {
                            paris.Energy--;
                            paris.Energy -= 2;
                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row][paris.Col - 1] = '-';

                                continue;
                            }
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        else if (matrix[paris.Row][paris.Col] == '-')
                        {
                            paris.Energy--;

                            if (paris.Energy <= 0)
                            {
                                parisIsDead = true;
                                matrix[paris.Row][paris.Col] = 'X';
                                matrix[paris.Row][paris.Col - 1] = '-';

                                continue;
                            }

                            matrix[paris.Row][paris.Col - 1] = '-';
                            matrix[paris.Row][paris.Col] = 'P';
                        }
                        
                        break;
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

        private static void FindHelenAndParis(char[][] matrix, int[] coordsOfHelen, Paris paris)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'H')
                    {
                        coordsOfHelen[0] = i;
                        coordsOfHelen[1] = j;
                    }
                    else if (matrix[i][j] == 'P')
                    {
                        paris.Row = i;
                        paris.Col = j;
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
