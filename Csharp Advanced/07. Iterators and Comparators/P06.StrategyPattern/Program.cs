using System;
using System.Linq;
using System.Collections.Generic;


namespace P06.StrategyPattern
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sortByName = new NameComparer();
            var sortByAge = new AgeComparer();
            var sortedByName = new SortedSet<Person>(sortByName);
            var sortedByAge = new SortedSet<Person>(sortByAge);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var person = new Person(input[0], int.Parse(input[1]));

                sortedByName.Add(person);
                sortedByAge.Add(person);
            }

            foreach (var person in sortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
