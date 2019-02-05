using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_Symbol_in_Matrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var symbol = Console.ReadLine();
                var symbols = symbol.ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = symbols[j];
                }
            }

            var specialSymbol = char.Parse(Console.ReadLine());
            var isFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == specialSymbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isFound = true;
                        return;
                    }
                }
            }

            if (isFound == false)
            {
                Console.WriteLine($"{specialSymbol} does not occur in the matrix");
            }
        }
    }
}
