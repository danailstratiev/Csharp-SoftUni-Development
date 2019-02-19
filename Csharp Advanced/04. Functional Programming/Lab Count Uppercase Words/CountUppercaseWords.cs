using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Count_Uppercase_Words
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).
                Where(w => char.IsUpper(w[0])).
                Select(w =>
                {
                    Console.WriteLine(w);
                    return w;
                }).Count();
        }
    }
}
