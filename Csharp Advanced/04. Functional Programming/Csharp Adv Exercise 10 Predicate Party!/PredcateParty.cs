using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_10_Predicate_Party_
{
    class PredcateParty
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                var commands = input.Split().ToList();

                var action = commands[0];
                var condition = commands[1];
                var parameter = commands[2];

                if (action == "Double")
                {
                    var doubledGuests = new List<string>();

                    switch (condition)
                    {
                        case "StartsWith":
                            doubledGuests = guests.Where(x => x.StartsWith(parameter)).ToList();                            
                            break;
                        case "EndsWith":
                            doubledGuests = guests.Where(x => x.EndsWith(parameter)).ToList();
                            break;
                        case "Length":
                            var length = int.Parse(parameter);
                            doubledGuests = guests.Where(x => x.Length == length).ToList();
                            break;                       
                    }

                    foreach (var guest in doubledGuests)
                    {
                        var index = guests.IndexOf(guest);

                        guests.Insert(index + 1, guest);
                    }

                }
                else if (action == "Remove")
                {
                    switch (condition)
                    {
                        case "StartsWith":
                            guests.RemoveAll(x => x.StartsWith(parameter));
                            break;
                        case "EndsWith":
                            guests.RemoveAll(x => x.EndsWith(parameter));
                            break;
                        case "Length":
                            var length = int.Parse(parameter);
                            guests.RemoveAll(x => x.Length == length);
                            break;
                    }
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Any() ? $"{string.Join(", ", guests)} are going to the party!" :
                "Nobody is going to the party!");
        }
    }
}
