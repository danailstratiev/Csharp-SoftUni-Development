using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Jagged_Array_Modification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = currentRow;
            }

            string[] input = Console.ReadLine().Split(" ").ToArray();

            while (input[0] != "END")
            {
                var command = input[0];
                var row = int.Parse(input[1]);
                var col = int.Parse(input[2]);
                var value = int.Parse(input[3]);

                if (row < 0 || row > jaggedArray.Length - 1 || col < 0 || col > jaggedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine().Split(" ").ToArray();
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        jaggedArray[row][col] += value;
                        break;
                    case "Subtract":
                        jaggedArray[row][col] -= value;
                        break;
                }

                input = Console.ReadLine().Split(" ").ToArray();
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
