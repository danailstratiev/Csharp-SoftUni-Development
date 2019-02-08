using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Exercise_01_Matrix_of_Palindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var parameters = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var rows = parameters[0];
            var cols = parameters[1];

            var matrix = new string[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var sb = new StringBuilder();
                    sb.Append(alphabet[i]);
                    sb.Append(alphabet[i + j]);
                    sb.Append(alphabet[i]);

                    matrix[i, j] = sb.ToString();

                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
