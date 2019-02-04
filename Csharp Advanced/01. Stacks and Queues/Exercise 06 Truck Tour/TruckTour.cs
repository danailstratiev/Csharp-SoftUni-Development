using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise_06_Truck_Tour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var petrolPumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                petrolPumps.Enqueue(input);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var currentPump in petrolPumps)
                {
                    int fuel = currentPump[0];
                    int distance = currentPump[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        // We increase the index in order to check if the next pair will fit the solution
                        index++;
                        int[] pumpForRemove = petrolPumps.Dequeue();
                        petrolPumps.Enqueue(pumpForRemove);
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
