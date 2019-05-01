using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var matrixRows = dimensions[0];
            var matrixCols = dimensions[1];
            var matrix = new string[matrixRows][];
            var counter = 1;

            for (long i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[matrixCols];

                for (long j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = counter.ToString();
                    counter++;
                }
            }

            var listMatrix = new List<List<string>>();

            var input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                var nukeProperties = input.Split(" ").Select(long.Parse).ToArray();

                NukeTime(matrix, nukeProperties, matrixRows, matrixCols);

                ClearUpMatrix(matrix);

                input = Console.ReadLine();
            }

            Change(matrix, listMatrix);
            PrintMatrix(listMatrix);
        }

        public static void ClearUpMatrix(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length - 1; j++)
                {
                    if (matrix[i][j] == " ")
                    {
                        matrix[i][j] = matrix[i][j + 1];
                        matrix[i][j + 1] = " ";
                    }
                }
            }
        }

        private static void PrintMatrix(List<List<string>> listMatrix)
        {
            for (int i = 0; i < listMatrix.Count; i++)
            {
                Console.WriteLine(string.Join(" ", listMatrix[i]));
            }
        }

        public static void Change(string[][] matrix, List<List<string>> listMatrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                var line = matrix[i].Where(x => x != " ").ToList();

                if (line.Count > 0)
                {
                    listMatrix.Add(line);
                }
            }
        }

        public static void NukeTime(string[][] matrix, long[] nukeProperties, long matrixRows, long matrixCols)
        {
            var nukeRow = nukeProperties[0];
            var nukeCol = nukeProperties[1];
            var nukeRadius = nukeProperties[2];

            for (long i = 0; i < matrix.Length; i++)
            {
                for (long j = 0; j < matrix[i].Length; j++)
                {
                    var inRowRange = IsInRangeRows(i, j, nukeRow, nukeCol, nukeRadius, matrixCols);
                    var inColRange = IsInRangeCols(i, j, nukeRow, nukeCol, nukeRadius, matrixRows);

                    if (inRowRange == true || inColRange == true)
                    {
                        matrix[i][j] = " ";
                    }
                }
            }
        }

        public static bool IsInRangeCols(long i, long j, long nukeRow, long nukeCol, long nukeRadius, long matrixRows)
        {
            var isInCol = false;

            if (j == nukeCol)
            {
                var start = nukeRow - nukeRadius;
                if (start < 0)
                {
                    start = 0;
                }

                var end = nukeRow + nukeRadius;
                if (end >= matrixRows)
                {
                    end = matrixRows - 1;
                }
                for (long k = start; k <= end; k++)
                {
                    if (k == i)
                    {
                        isInCol = true;
                    }
                }
            }

            return isInCol;
        }

        public static bool IsInRangeRows(long i, long j, long nukeRow, long nukeCol, long nukeRadius, long matrixCols)
        {
            var isInRow = false;

            if (i == nukeRow)
            {
                var start = nukeCol - nukeRadius;
                if (start < 0)
                {
                    start = 0;
                }

                var end = nukeCol + nukeRadius;
                if (end >= matrixCols)
                {
                    end = matrixCols - 1;
                }
                for (long k = start; k <= end; k++)
                {
                    if (k == j)
                    {
                        isInRow = true;
                    }
                }
            }

            return isInRow;
        }

        public static void PrintMatrix(string[][] matrix)
        {
            for (long i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }
    }
}
