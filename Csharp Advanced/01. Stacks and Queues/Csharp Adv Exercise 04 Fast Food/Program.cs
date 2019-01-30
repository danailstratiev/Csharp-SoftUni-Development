using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_04_Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var preparedFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var bestClient = -1;
            var queue = new Queue<int>(orders);

            for (int i = 0; i < orders.Length; i++)
            {
                if (preparedFood <= 0)
                {
                    break;                    
                }
                var currentOrder = orders[i];

                if (currentOrder > bestClient)
                {
                    bestClient = currentOrder;
                }

                preparedFood -= currentOrder;

                if (preparedFood >= 0)
                {
                    queue.Dequeue();
                }
                
            }

            if (preparedFood < 0)
            {
                Console.WriteLine(bestClient);
                Console.Write("Orders left: ");
                Console.WriteLine(string.Join(" ", queue));
            }
            else
            {
                Console.WriteLine(bestClient);
                Console.WriteLine("Orders complete");
            }
        }
    }
}
