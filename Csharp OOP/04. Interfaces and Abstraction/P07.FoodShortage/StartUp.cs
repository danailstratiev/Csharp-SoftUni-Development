using System;
using System.Linq;
using System.Collections.Generic;

namespace P07.FoodShortage
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var humans = new List<Human>();
            var n = int.Parse(Console.ReadLine());
            var buyers = new HashSet<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();

                if (input.Length == 4)
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var id = input[2];
                    var birthdate = input[3];
                    var citizen = new Citizen(name, age, id, birthdate);
                    humans.Add(citizen);
                }
                else 
                {
                    var name = input[0];
                    var age = int.Parse(input[1]);
                    var group = input[2];
                    var rebel = new Rebel(name, age, group);
                    humans.Add(rebel);
                }
            }

            var buyer = Console.ReadLine();

            while (buyer != "End")
            {
                var currentBuyer = humans.FirstOrDefault(x => x.Name == buyer);

                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                    buyers.Add(currentBuyer);
                }

               buyer = Console.ReadLine();
            }

            var sum = 0;
            foreach (var client in buyers)
            {
                sum += client.Food;
            }

            Console.WriteLine(sum);
        }
    }
}
