using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.BorderControl
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var allIds = new List<string>();

            while (input != "End")
            {
                var passenger = input.Split(" ").ToArray();
                allIds.Add(passenger[passenger.Length - 1]);

                input = Console.ReadLine();
            }

            var fakeId = Console.ReadLine();

            foreach (var id in allIds.Where(x => x.EndsWith(fakeId)))
            {
                Console.WriteLine(id);
            }
        }
    }
}
