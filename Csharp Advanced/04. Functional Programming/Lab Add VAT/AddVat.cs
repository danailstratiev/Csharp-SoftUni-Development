using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ").Select(double.Parse)
                .Select(n => n * 1.2).
                ToList();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
