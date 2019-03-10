using System;
using System.Linq;
using System.Collections.Generic;


namespace P07.EqualityLogic
{
   public class Program
    {
        static void Main(string[] args)
        {
            var people = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(people.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
