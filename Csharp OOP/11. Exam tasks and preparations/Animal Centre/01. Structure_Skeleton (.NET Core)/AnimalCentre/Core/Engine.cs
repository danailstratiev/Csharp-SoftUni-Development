using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core
{
    public class Engine
    {
        public void Run()
        {
            var animalCentre = new AnimalCentre();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var commands = input.Split();
                var commandType = commands[0];

                try
                {
                    if (commandType == "RegisterAnimal")
                    {
                        var type = commands[1];
                        var name = commands[2];
                        var energy = int.Parse(commands[3]);
                        var happiness = int.Parse(commands[4]);
                        var procedureTime = int.Parse(commands[5]);

                        Console.WriteLine(animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime));
                    }
                    else if (commandType == "Chip")
                    {
                        var name = commands[1];
                        var procedureTime = int.Parse(commands[2]);

                        Console.WriteLine(animalCentre.Chip(name, procedureTime));
                    }
                    else if (commandType == "Vaccinate")
                    {
                        var name = commands[1];
                        var procedureTime = int.Parse(commands[2]);

                        Console.WriteLine(animalCentre.Vaccinate(name, procedureTime));
                    }
                    else if (commandType == "Fitness")
                    {
                        var name = commands[1];
                        var procedureTime = int.Parse(commands[2]);

                        Console.WriteLine(animalCentre.Fitness(name, procedureTime));
                    }
                    else if (commandType == "Play")
                    {
                        var name = commands[1];
                        var procedureTime = int.Parse(commands[2]);

                        Console.WriteLine(animalCentre.Play(name, procedureTime));
                    }
                    else if (commandType == "DentalCare")
                    {
                        var name = commands[1];
                        var procedureTime = int.Parse(commands[2]);

                        Console.WriteLine(animalCentre.DentalCare(name, procedureTime));
                    }
                    else if (commandType == "NailTrim")
                    {
                        var name = commands[1];
                        var procedureTime = int.Parse(commands[2]);

                        Console.WriteLine(animalCentre.NailTrim(name, procedureTime));
                    }
                    else if (commandType == "Adopt")
                    {
                        var name = commands[1];
                        var owner = commands[2];

                        Console.WriteLine(animalCentre.Adopt(name, owner));
                    }
                    else if (commandType == "History")
                    {
                        var procedureType = commands[1];

                        Console.WriteLine(animalCentre.History(procedureType));
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                }
                input = Console.ReadLine();
            }

            var ownersAndPets = animalCentre.GetOwnersAndPets();

            OwnerFinishLines(ownersAndPets);
        }

        private void OwnerFinishLines(Dictionary<string, SortedSet<string>> ownersAndPets)
        {
            foreach (var owner in ownersAndPets.OrderBy(x => x.Key))
            {
                Console.WriteLine($"--Owner: {owner.Key}");
                Console.WriteLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }
        }
    }
}
