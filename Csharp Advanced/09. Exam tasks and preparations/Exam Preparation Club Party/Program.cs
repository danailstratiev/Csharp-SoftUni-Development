using System;
using System.Linq;
using System.Collections.Generic;

namespace Exam_Preparation_Club_Party
{
    class Hall
    {
        public Hall(string name, int capacity)
        {
            Name = name;
            Companies = new List<int>();
            Capacity = capacity;
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<int> Companies { get; set; }

        public int UsedCapacity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            var allHalls = new List<Hall>();

            GetHalls(input, allHalls, n);

            FulfilReservations(input, allHalls);
        }

        private static void FulfilReservations(string[] input, List<Hall> allHalls)
        {
            var letter = ' ';
            Hall currentHall = null;
            var hallQueue = new Queue<char>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char.TryParse(input[i], out letter);

                if (char.IsLetter(letter))
                {
                    if (currentHall == null)
                    {
                        currentHall = allHalls.Last();
                    }

                    hallQueue.Enqueue(letter);
                    continue;
                }
                else
                {
                    var currentCompany = int.Parse(input[i]);

                    if (currentHall != null)
                    {
                        if (currentHall.UsedCapacity + currentCompany <= currentHall.Capacity )
                        {
                            currentHall.UsedCapacity += currentCompany;
                            currentHall.Companies.Add(currentCompany);
                        }
                        else
                        {
                            Console.WriteLine($"{currentHall.Name} -> {string.Join(", ", currentHall.Companies)}");
                            allHalls.RemoveAt(allHalls.Count - 1);
                            hallQueue.Dequeue();

                            if (hallQueue.Any())
                            {
                                currentHall = allHalls.Last();

                                if (currentHall.UsedCapacity + currentCompany <= currentHall.Capacity)
                                {
                                    currentHall.UsedCapacity += currentCompany;
                                    currentHall.Companies.Add(currentCompany);
                                }
                            }
                            else
                            {
                                currentHall = null;
                            }
                        }
                    }
                    else
                    {
                        if (hallQueue.Any())
                        {
                            currentHall = allHalls.Last();
                        }
                    }
                }
            }
        }

        private static void GetHalls(string[] input, List<Hall> allHalls, int n)
        {
            var letter = ' ';
            for (int i = input.Length - 1; i >= 0; i--)
            {
                char.TryParse(input[i],out letter);

                if (char.IsLetter(letter))
                {
                    var currentHall = new Hall(letter.ToString(), n);
                    allHalls.Add(currentHall);
                }
            }

            allHalls.Reverse();
        }
    }
}
