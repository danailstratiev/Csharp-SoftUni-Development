using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] input = command.Split();
                var department = input[0];
                var firstName = input[1];
                var secondName = input[2];
                var patient = input[3];
                var doctorsName = firstName + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[doctorsName] = new List<string>();
                }

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int i = 0; i < 20; i++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool isFree = departments[department].SelectMany(x => x).Count() < 60;
                if (isFree)
                {
                    int room = 0;
                    doctors[doctorsName].Add(patient);
                    for (int i = 0; i < departments[department].Count; i++)
                    {
                        if (departments[department][i].Count < 3)
                        {
                            room = i;
                            break;
                        }
                    }
                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
