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
            var family = new Family();

            for (int i = 0; i < n; i++)
            {
                var man = Console.ReadLine().Split().ToArray();
                var name = man[0];
                var age = int.Parse(man[1]);

                Person person = new Person(name, age);
                
                family.AddMember(person);
            }

            var oldesMember = family.GetOldestMember();

            Console.WriteLine(oldesMember);
        }
    }
}
