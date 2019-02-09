using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_03_2x2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];
            var sum = 0;

            var matrix = new char[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = elements[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var a = matrix[i, j];
                    var b = matrix[i, j + 1];
                    var c = matrix[i + 1, j];
                    var d = matrix[i + 1, j + 1];

                    if (a == b && a == c && a == d)
                    {
                        sum++;
                    }                    
                }
            }

            Console.WriteLine(sum);
        }
    }
}
