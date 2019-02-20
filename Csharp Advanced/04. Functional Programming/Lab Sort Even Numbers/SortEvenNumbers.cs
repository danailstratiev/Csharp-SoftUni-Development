using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Sort_Even_Numbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(", ").
                Select(int.Parse).Where(x => x % 2 == 0).
                OrderBy(x => x)));
        }
    }
}
