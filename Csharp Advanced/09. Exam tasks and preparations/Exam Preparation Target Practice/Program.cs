using System;
using System.Linq;
using System.Collections.Generic;


namespace Exam_Preparation_Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var message = Console.ReadLine();
            var shotParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var shotRow = shotParameters[0];
            var shotCol = shotParameters[1];
            var shotDamage = shotParameters[2];

            var matrixRows = matrixParameters[0];
            var matrixCols = matrixParameters[1];

            var matrix = new char[matrixRows][];
            var index = 0;
            var counter = matrixCols;

            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                matrix[i] = new char[matrixCols];

                if (counter == matrixCols)
                {
                    for (int j = matrixCols - 1; j >= 0; j--)
                    {
                        counter = j;
                        matrix[i][counter] = message[index];

                        if (index < message.Length - 1)
                        {
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    counter = 0;
                }
                else
                {
                    for (int j = 0; j < matrixCols; j++)
                    {
                        counter = j;
                        matrix[i][counter] = message[index];

                        if (index < message.Length - 1)
                        {
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    counter = matrixCols;
                }
            }

            TakeAShot(matrix, shotRow, shotCol, shotDamage);

            ReformMatrix(matrix, matrixCols, matrixRows);

            PrintMatrix(matrix);

        }

        private static void ReformMatrix(char[][] matrix, int matrixCols, int matrixRows)
        {
            var chars = new Queue<char>();

            for (int i = 0; i < matrix[0].Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[j][i] != ' ')
                    {
                        chars.Enqueue(matrix[j][i]);
                    }
                }

                var fillIndex = matrix.Length - chars.Count();

                for (int j = 0; j < fillIndex; j++)
                {
                    matrix[j][i] = ' ';
                }

                for (int k = fillIndex; k < matrix.Length; k++)
                {
                    matrix[k][i] = chars.Dequeue();
                }
            }
        }

        private static void TakeAShot(char[][] matrix, int shotRow, int shotCol, int shotDamage)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    var damageTaken = Math.Pow(shotRow - i, 2) + Math.Pow(shotCol - j, 2);
                    var damageArea = Math.Pow(shotDamage, 2);

                    if (damageTaken <= damageArea)
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }    
    }
}
