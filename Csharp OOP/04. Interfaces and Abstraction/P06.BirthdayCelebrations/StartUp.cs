using System;
using System.Linq;
using System.Collections.Generic;

namespace P06.BirthdayCelebrations
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var livingCreatures = new List<LivingCreature>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var info = input.Split().ToArray();

                if (info[0] != "Robot")
                {
                    if (info[0] == "Citizen")
                    {
                        var name = info[1];
                        var age = int.Parse(info[2]);
                        var id = info[3];
                        var birthdate = info[4];

                        var citizen = new Citizen(name, age, id, birthdate);

                        livingCreatures.Add(citizen);
                    }
                    else if (info[0] == "Pet")
                    {
                        var name = info[1];
                        var birthdate = info[2];

                        var pet = new Pet(name, birthdate);
                        livingCreatures.Add(pet);
                    }
                }

                input = Console.ReadLine();
            }

            var birthYear = Console.ReadLine();

            foreach (var creature in livingCreatures.Where(x => x.Birthdate.EndsWith(birthYear)))
            {
                Console.WriteLine(creature.Birthdate);
            }
        }
    }
}
