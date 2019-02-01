using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_06_Auto_Repair_and_Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var carStatus = new Dictionary<string, string>();
            var cars = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            var queue = new Queue<string>(cars);
            var input = Console.ReadLine();
            var stack = new List<string>();

            while (input != "End")
            {
                var commands = input.Split(new char[] {' ','-'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = commands[0];

                if (command == "Service" && queue.Count > 0)
                {
                    var car = queue.Dequeue();
                    stack.Add(car);
                    Console.WriteLine($"Vehicle {car} got served.");
                }
                else if (command == "CarInfo")
                {
                    var carName = commands[1];

                    if (queue.Contains(carName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command == "History")
                {
                    Print(stack);
                }

                input = Console.ReadLine();
            }

            if (queue.Count > 0)
            {
                Console.Write("Vehicles for service: ");
                PrintQ(queue);
            }

            Console.Write("Served vehicles: ");
            Print(stack);
        }

        private static void PrintQ(Queue<string> queue)
        {
            while (queue.Count > 1)
            {
                Console.Write($"{queue.Dequeue()}, ");
            }

            Console.WriteLine(queue.Dequeue());

        }

        private static void Print(List<string> stack)
        {
            for (int i = stack.Count - 1; i >= 1; i--)
            {
                Console.Write($"{stack[i]}, ");
            }
            Console.WriteLine(stack[0]);

        }
    }
}
