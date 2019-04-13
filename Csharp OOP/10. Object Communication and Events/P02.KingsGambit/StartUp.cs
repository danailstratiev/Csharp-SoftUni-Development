using System;
using System.Linq;
using System.Collections.Generic;

namespace P02.KingsGambit
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var kingName = Console.ReadLine();
            var king = new King(kingName);
            var royalGuardNames = Console.ReadLine().Split();
            var royalGuards = new List<Person>();
            var footmen = new List<Person>();

            for (int i = 0; i < royalGuardNames.Length; i++)
            {
                var royalGuard = new RoyalGuard(royalGuardNames[i]);
                royalGuards.Add(royalGuard);
            }

            var footmenNames = Console.ReadLine().Split();

            for (int i = 0; i < footmenNames.Length; i++)
            {
                var footman = new Footman(footmenNames[i]);
                footmen.Add(footman);
            }


            var input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Attack King")
                {
                    Console.WriteLine(king.ProtectTheKing());

                    foreach (var guard in royalGuards)
                    {
                        Console.WriteLine(guard.ProtectTheKing());
                    }

                    foreach (var footman in footmen)
                    {
                        Console.WriteLine(footman.ProtectTheKing());
                    }
                }
                else
                {
                    var name = input.Split()[1];

                    if (royalGuards.Any(x => x.Name == name))
                    {
                        var deadGuard = royalGuards.FirstOrDefault(x => x.Name == name);

                        royalGuards.Remove(deadGuard);
                    }
                    else
                    {
                        var deadFootman = footmen.FirstOrDefault(x => x.Name == name);

                        footmen.Remove(deadFootman);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
