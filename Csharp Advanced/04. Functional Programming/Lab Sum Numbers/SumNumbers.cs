using System;
using System.Linq;


namespace Lab_Sum_Numbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ").Select(Parse).ToArray() ;

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }

        public static Func<string, int> Parse = n => int.Parse(n);
    }
}
