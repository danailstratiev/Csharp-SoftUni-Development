using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_10_Poisonous_Plants
{
    class PoisonousPlants
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            var deadPlants = new List<int>();
            var days = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count-1; i++)
                {
                    if (plants[i] < plants[i+1])
                    {
                        deadPlants.Add(i + 1);
                    }
                }

                if (deadPlants.Count == 0)
                {
                    break;
                }

                for (int i = deadPlants.Count - 1; i >= 0; i--)
                {
                    plants.RemoveAt(deadPlants[i]);
                }

                days++;
                deadPlants.Clear();
            }

            Console.WriteLine(days);
        }
    }
}
