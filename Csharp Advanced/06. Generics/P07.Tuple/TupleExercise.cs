using System;
using System.Linq;
using System.Collections.Generic;


namespace P07.Tuple
{
   public class TupleExercise
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();

                switch (i)
                {
                    case 0:
                        var name = $"{input[0]} {input[1]}";
                        var tuple = new Tuple<string, string>(name, input[2]);
                        Console.WriteLine(tuple);
                        break;
                    case 1:
                        var anotherName = input[0];
                        var tuple1 = new Tuple<string, int>(anotherName, int.Parse(input[1]));
                        Console.WriteLine(tuple1);
                        break;
                    case 2:
                        var someName = int.Parse(input[0]);
                        var tuple2 = new Tuple<int, double>(someName, double.Parse(input[1]));
                        Console.WriteLine(tuple2);
                        break;
                }
            }
        }
    }
}
