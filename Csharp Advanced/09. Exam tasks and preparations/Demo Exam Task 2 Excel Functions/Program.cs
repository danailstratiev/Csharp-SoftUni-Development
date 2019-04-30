using System;
using System.Linq;
using System.Collections.Generic;


namespace Demo_Exam_Task_2_Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

                matrix.Add(input);
            }

            var finalCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = finalCommand[0];

            switch (command)
            {
                case "sort":
                    var sortParameter = finalCommand[1];
                    Sort(sortParameter, matrix);
                    break;
                case "hide":
                    var hideParameter = finalCommand[1];
                    Hide(hideParameter, matrix);
                    break;
                case "filter":
                    var filterParameter = finalCommand[1];
                    var filterValue = finalCommand[2];
                    Filter(filterParameter, filterValue, matrix);
                    break;
            }
        }

        public static void Sort(string sortParameter, List<List<string>> matrix)
        {
            var sortIndex = 0;
            var zeroLineMatrix = matrix[0];

            for (int i = 0; i < zeroLineMatrix.Count; i++)
            {
                if (zeroLineMatrix[i] == sortParameter)
                {
                    sortIndex = i;
                }
            }

            var sortList = new List<string>();

            for (int i = 1; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (j == sortIndex)
                    {
                        sortList.Add(matrix[i][j]);
                    }
                }
            }

            sortList.Sort();

            Console.WriteLine(string.Join(" | ", matrix[0]));
            for (int i = 1; i < matrix.Count; i++)
            {
                var currentSortValue = sortList[i-1];

                foreach (var list in matrix.Where(x => x[sortIndex] == currentSortValue))
                {
                    Console.WriteLine(string.Join(" | ", list));
                }
            }
        }

        public static void Filter(string filterParameter, string filterValue, List<List<string>> matrix)
        {
            var filterIndex = 0;
            var zeroLineMatrix = matrix[0];


            for (int i = 0; i < zeroLineMatrix.Count; i++)
            {
                if (zeroLineMatrix[i] == filterParameter)
                {
                    filterIndex = i;
                }
            }

            Console.WriteLine(string.Join(" | ", matrix[0]));
            for (int i = 1; i < matrix.Count; i++)
            {
                var currentMatrixLine = matrix[i];

                if (currentMatrixLine[filterIndex] == filterValue)
                {
                    Console.WriteLine(string.Join(" | ", currentMatrixLine));
                }
            }
        }

        public static void Hide(string hideParameter, List<List<string>> matrix)
        {
            var hideIndex = 0;
            var zeroLineMatrix = matrix[0];

            for (int i = 0; i < zeroLineMatrix.Count; i++)
            {
                if (zeroLineMatrix[i] == hideParameter)
                {
                    hideIndex = i;
                    break;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i].RemoveAt(hideIndex);
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                Console.WriteLine(string.Join(" | ", matrix[i]));
            }
        }
    }
}
