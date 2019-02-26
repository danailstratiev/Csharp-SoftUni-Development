using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var man = Console.ReadLine().Split();
                var name = man[0];
                var age = int.Parse(man[1]);

                var person = new Person(name, age);

                people.Add(person);
            }

            foreach (var person in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
