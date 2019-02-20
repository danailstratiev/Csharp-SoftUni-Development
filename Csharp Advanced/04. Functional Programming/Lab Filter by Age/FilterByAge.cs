using System;
using System.Linq;
using System.Collections.Generic;


namespace Lab_Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var peopleWithAge = Console.ReadLine().Split(", ").ToArray();

                people.Add(peopleWithAge[0], int.Parse(peopleWithAge[1]));
            }

            var condition = Console.ReadLine();
            var ageBoundary = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            people.Where(p => condition == "younger" ? p.Value < ageBoundary : p.Value >= ageBoundary).ToDictionary(x => x.Key, y => y.Value);
            foreach (var person in people)
            {
                switch (format)
                {
                    case "name age":
                        Console.WriteLine($"{person.Key} - {person.Value}");
                        break;
                    case "name":
                        Console.WriteLine($"{person.Key}");
                        break;
                    case "age":
                        Console.WriteLine($"{person.Value}");
                        break;
                }
            }
        }
    }
}
