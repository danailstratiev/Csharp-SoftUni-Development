using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Exercise_12_Inferno_III
{
    class Filter
    {
        public string Status { get; set; }

        public string Type { get; set; }

        public int NumberToCompare { get; set; }
    }
    class InfernoIII
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var command = Console.ReadLine();
            var allCommands = new List<Filter>();

            while (command != "Forge")
            {
                var commands = command.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                var status = commands[0];
                var type = commands[1];
                var parameter = int.Parse(commands[2]);

                var currentFilter = new Filter();
                currentFilter.Status = status;
                currentFilter.Type = type;
                currentFilter.NumberToCompare = parameter;

                if (status == "Exclude")
                {
                    var oppositeFilter = allCommands.FirstOrDefault(x => x.Status == "Reverse" &&
                    x.Type == type && x.NumberToCompare == parameter);

                    if (oppositeFilter == null)
                    {
                        allCommands.Add(currentFilter);
                    }
                    else
                    {
                        var index = allCommands.IndexOf(oppositeFilter);
                        allCommands.RemoveAt(index);
                    }
                }
                else
                {
                    var oppositeFilter = allCommands.FirstOrDefault(x => x.Status == "Exclude" &&
                    x.Type == type && x.NumberToCompare == parameter);

                    if (oppositeFilter == null)
                    {
                        allCommands.Add(currentFilter);
                    }
                    else
                    {
                        var index = allCommands.IndexOf(oppositeFilter);
                        allCommands.RemoveAt(index);
                    }
                }

                command = Console.ReadLine();
            }

            var numbersToRemove = new List<int>();

            if (numbers.Count == 1)
            {
                Console.WriteLine(string.Join(" ", numbers));

                return;
            }

            foreach (var filter in allCommands)
            {
                if (filter.Status == "Exclude")
                {
                    switch (filter.Type)
                    {
                        case "Sum Left":
                            for (int i = 1; i < numbers.Count; i++)
                            {
                                if (numbers[i - 1] + numbers[i] == filter.NumberToCompare)
                                {
                                    numbersToRemove.Add(i);
                                }
                            }
                            if (numbers[0] == filter.NumberToCompare)
                            {
                                numbersToRemove.Add(0);
                            }
                            break;
                        case "Sum Right":
                            for (int i = 0; i < numbers.Count - 1; i++)
                            {
                                if (numbers[i + 1] + numbers[i] == filter.NumberToCompare)
                                {
                                    numbersToRemove.Add(i);
                                }
                            }
                            if (numbers[numbers.Count - 1] == filter.NumberToCompare)
                            {
                                numbersToRemove.Add(numbers.Count - 1);
                            }
                            break;
                        case "Sum Left Right":
                            for (int i = 1; i < numbers.Count - 1; i++)
                            {
                                if (numbers[i + 1] + numbers[i] + numbers[i - 1] == filter.NumberToCompare)
                                {
                                    numbersToRemove.Add(i);
                                }
                            }
                            if (numbers[numbers.Count - 1] + numbers[numbers.Count - 2] == filter.NumberToCompare)
                            {
                                numbersToRemove.Add(numbers.Count - 1);
                            }
                            if (numbers[1] + numbers[0] == filter.NumberToCompare)
                            {
                                numbersToRemove.Add(0);
                            }
                            break;
                    }
                }
            }

            var newNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (!numbersToRemove.Contains(i))
                {
                    newNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine(string.Join(" ", newNumbers));
        }
    }
}
