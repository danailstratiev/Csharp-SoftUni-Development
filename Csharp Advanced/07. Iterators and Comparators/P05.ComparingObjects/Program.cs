using System;
using System.Linq;
using System.Collections.Generic;


namespace P05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var people = new List<Person>();

            while (input != "END")
            {
                var currentPerson = input.Split().ToArray();
                var person = new Person(currentPerson[0], int.Parse(currentPerson[1]), currentPerson[2]);
                people.Add(person);

                input = Console.ReadLine();
            }

            var index = int.Parse(Console.ReadLine());

            if (index >= people.Count)
            {
                Console.WriteLine("No matches");
                return;
            }

            var equalPeople = 0;
            var notEqualPeople = 0;
            var mainMan = people[index];

            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].CompareTo(mainMan) == 0)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }

            if (equalPeople > 1)
            {
                Console.WriteLine("No matches");

                return;
            }

            Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
        }
    }
}
