using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_String_Matrix_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var matrix = new List<List<char>>();
            var input = Console.ReadLine();
            var longestElement = input.Length;

            while (input != "END")
            {
                if (input.Length > longestElement)
                {
                    longestElement = input.Length;
                }
                var word = new List<char>(input);
                matrix.Add(word);

                input = Console.ReadLine();
            }

            GetFullMatrixSize(matrix, longestElement);

            var rotation = command.Split(new char[] { '(', ')' }).ToArray();
            var rotationAngle = int.Parse(rotation[1]);

            if (rotationAngle % 360 == 0)
            {
                Rotate360(matrix);
            }

            else if (rotationAngle % 180 == 0)
            {
                Rotate180(matrix, longestElement);
            }
            else if (rotationAngle % 90 == 0)
            {
                if (rotationAngle % 270 == 0)
                {
                    Rotate270(matrix, longestElement);
                }
                else
                {
                    Rotate90(matrix, longestElement);
                }
            }
        }

        public static void Rotate360(List<List<char>> matrix)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                var currentRow = matrix[i];

                Console.WriteLine(string.Join("", currentRow));
            }
        }

        public static void Rotate270(List<List<char>> matrix, int longestElement)
        {
            for (int i = longestElement - 1; i >= 0; i--)
            {
                var currentRow = new List<char>();

                foreach (var word in matrix)
                {
                    currentRow.Add(word[i]);
                }

                Console.WriteLine(string.Join("", currentRow));
            }
        }

        public static void Rotate180(List<List<char>> matrix, int longestElement)
        {
            for (int i = matrix.Count - 1; i >= 0; i--)
            {
                var currentRow = matrix[i];
                currentRow.Reverse();

                Console.WriteLine(string.Join("", currentRow));
            }
        }

        public static void GetFullMatrixSize(List<List<char>> matrix, int longestElement)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = matrix[i].Count; j < longestElement; j++)
                {
                    matrix[i].Add(' ');
                }
            }
        }

        public static void Rotate90(List<List<char>> matrix, int longestElement)
        {
            for (int i = 0; i < longestElement; i++)
            {
                var currentRow = new List<char>();

                foreach (var word in matrix)
                {
                    currentRow.Add(word[i]);
                }

                currentRow.Reverse();
                Console.WriteLine(string.Join("", currentRow));
            }
        }
    }
}
