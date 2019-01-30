using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_02_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var conditions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var queueLength = conditions[0];
            var elementsToDequeue = conditions[1];
            var numberToFind = conditions[2];
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < queueLength; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(numberToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
