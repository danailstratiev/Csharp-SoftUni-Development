using System;
using System.Linq;
using System.Collections.Generic;


namespace Csharp_Adv_Ex_11_Party_Reservation_Filter_Module
{
    class Filter
    {
        public string Status { get; set; }

        public string Type { get; set; }

        public string Parameter { get; set; }

        public int Length { get; set; }
    }
    class PRFM
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split().ToList();
            var input = Console.ReadLine();
            var allFilters = new List<Filter>();

            while (input != "Print")
            {
                var commands = input.Split(";").ToList();

                var action = commands[0];
                var type = commands[1];
                var parameter = commands[2];

                if (action == "Add filter")
                {
                    var currentFilter = new Filter();
                    currentFilter.Status = action;
                    currentFilter.Type = type;
                    if (type == "Length")
                    {
                        currentFilter.Length = int.Parse(parameter);
                    }
                    else
                    {
                        currentFilter.Length = -1;
                        currentFilter.Parameter = parameter;
                    }

                    var oppositeFilter = allFilters.FirstOrDefault(x => x.Status == "Remove filter" &&
                    x.Type == type && (x.Parameter == parameter || x.Length > 0));

                    if (oppositeFilter == null)
                    {
                        allFilters.Add(currentFilter);
                    }
                    else
                    {
                        var index = allFilters.IndexOf(oppositeFilter);
                        allFilters.RemoveAt(index);
                    }
                }
                else if (action == "Remove filter")
                {
                    var currentFilter = new Filter();
                    currentFilter.Status = action;
                    currentFilter.Type = type;
                    if (type == "Length")
                    {
                        currentFilter.Length = int.Parse(parameter);
                    }
                    else
                    {
                        currentFilter.Length = -1;
                        currentFilter.Parameter = parameter;
                    }

                    var oppositeFilter = allFilters.FirstOrDefault(x => x.Status == "Add filter" &&
                    x.Type == type && (x.Parameter == parameter || x.Length > 0));

                    if (oppositeFilter == null)
                    {
                        allFilters.Add(currentFilter);
                    }
                    else
                    {
                        var index = allFilters.IndexOf(oppositeFilter);
                        allFilters.RemoveAt(index);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var filter in allFilters)
            {
                if (filter.Status == "Add filter")
                {
                    switch (filter.Type)
                    {
                        case "Starts with":
                            guests.RemoveAll(x => x.StartsWith(filter.Parameter));
                            break;
                        case "Ends with":
                            guests.RemoveAll(x => x.EndsWith(filter.Parameter));
                            break;
                        case "Contains":
                            guests.RemoveAll(x => x.Contains(filter.Parameter));
                            break;
                        case "Length":
                            var length = filter.Length;
                            guests.RemoveAll(x => x.Length == length);
                            break;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
