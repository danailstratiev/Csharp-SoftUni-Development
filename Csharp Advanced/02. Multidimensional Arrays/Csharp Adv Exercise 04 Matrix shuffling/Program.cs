using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_04_Matrix_shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = new string[parameters[0], parameters[1]];

            for (int i = 0; i < parameters[0]; i++)
            {
                var columns = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < parameters[1]; j++)
                {
                    matrix[i, j] = columns[j];
                }
            }

            var input = Console.ReadLine();


            while (input != "END")
            {
                var commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (commands[0] != "swap" || commands.Length != 5)
                {                    
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    var row1 = int.Parse(commands[1]);
                    var col1 = int.Parse(commands[2]);
                    var row2 = int.Parse(commands[3]);
                    var col2 = int.Parse(commands[4]);

                    if (row1 >= parameters[0] || row2 >= parameters[0] ||
                        col1 >= parameters[1] || col2 >= parameters[1])
                    {
                        Console.WriteLine("Invalid input!");
                        input = Console.ReadLine();
                        continue;
                    }

                    Swap(matrix, row1, col1, row2, col2);
                    Print(matrix);
                }
                input = Console.ReadLine();
            }

        }

        private static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void Swap(string[,] matrix, int row1, int col1, int row2, int col2)
        {
            var value1 = "";
            var value2 = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == row1 && j == col1)
                    {
                        value1 = matrix[i, j];
                    }
                    else if (i == row2 && j == col2)
                    {
                        value2 = matrix[i, j];
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == row1 && j == col1)
                    {
                        matrix[i, j] = value2;
                    }
                    else if (i == row2 && j == col2)
                    {
                        matrix[i, j] = value1;
                    }
                }
            }
        }
    }
}
