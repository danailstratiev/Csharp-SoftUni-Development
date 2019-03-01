using System;
using System.Linq;
using System.Collections.Generic;


namespace P12_Google
{
    public class Google
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var people = new List<Person>();

            while (input != "End")
            {
                var currentPerson = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = currentPerson[0];
                var parameter = currentPerson[1];
                var person = people.FirstOrDefault(x => x.Name == name);

                if (person == null)
                {
                    person = new Person
                    {
                        Name = name,
                        Company = new Company(),
                        Car = new Car(),
                        Pokemons = new List<Pokemon>(),
                        Parents = new List<Parent>(),
                        Children = new List<Child>(),
                    };

                    switch (parameter)
                    {
                        case "car":
                            var car = new Car()
                            {
                                Model = currentPerson[2],
                                Speed = int.Parse(currentPerson[3])
                            };

                            person.Car = car;

                            break;
                        case "company":
                            var company = new Company()
                            {
                                Name = currentPerson[2],
                                Department = currentPerson[3],
                                Salary = double.Parse(currentPerson[4])
                            };

                            person.Company = company;

                            break;
                        case "pokemon":
                            var pokemon = new Pokemon()
                            {
                                Name = currentPerson[2],
                                Type = currentPerson[3]
                            };

                            person.Pokemons.Add(pokemon);

                            break;
                        case "parents":
                            var parent = new Parent()
                            {
                                Name = currentPerson[2],
                                Birthday = currentPerson[3]
                            };

                            person.Parents.Add(parent);

                            break;
                        case "children":
                            var child = new Child()
                            {
                                Name = currentPerson[2],
                                Birthday = currentPerson[3]
                            };

                            person.Children.Add(child);

                            break;
                    }

                    people.Add(person);
                }
                else
                {
                    switch (parameter)
                    {
                        case "car":
                            var car = new Car()
                            {
                                Model = currentPerson[2],
                                Speed = int.Parse(currentPerson[3])
                            };

                            person.Car = car;

                            break;
                        case "company":
                            var company = new Company()
                            {
                                Name = currentPerson[2],
                                Department = currentPerson[3],
                                Salary = double.Parse(currentPerson[4])
                            };

                            person.Company = company;

                            break;
                        case "pokemon":
                            var pokemon = new Pokemon()
                            {
                                Name = currentPerson[2],
                                Type = currentPerson[3]
                            };

                            if (person.Pokemons == null)
                            {
                                person.Pokemons = new List<Pokemon>();
                            }

                            person.Pokemons.Add(pokemon);
                            person.Pokemons.Distinct();

                            break;
                        case "parents":
                            var parent = new Parent()
                            {
                                Name = currentPerson[2],
                                Birthday = currentPerson[3]
                            };

                            if (person.Parents == null)
                            {
                                person.Parents = new List<Parent>();
                            }

                            person.Parents.Add(parent);
                            person.Parents.Distinct();

                            break;
                        case "children":
                            var child = new Child()
                            {
                                Name = currentPerson[2],
                                Birthday = currentPerson[3]
                            };

                            if (person.Children == null)
                            {
                                person.Children = new List<Child>();
                            }

                            person.Children.Add(child);
                            person.Children.Distinct();

                            break;
                    }
                }

                input = Console.ReadLine();
            }

            var mainMan = Console.ReadLine();

            var myMan = people.FirstOrDefault(x => x.Name == mainMan);

            Console.WriteLine(mainMan);

            Console.WriteLine("Company:");
            if (myMan.Company.Name != null)
            {
                Console.WriteLine(myMan.Company);
            }

            Console.WriteLine("Car:");
            if (myMan.Car.Model != null)
            {
                Console.WriteLine(myMan.Car);
            }

            Console.WriteLine("Pokemon:");
            if (myMan.Pokemons.Count > 0)
            {
                foreach (var pokemon in myMan.Pokemons)
                {
                    Console.WriteLine(pokemon);
                }
            }

            Console.WriteLine("Parents:");
            if (myMan.Parents.Count > 0)
            {
                foreach (var parent in myMan.Parents)
                {
                    Console.WriteLine(parent);
                }
            }

            Console.WriteLine("Children:");
            if (myMan.Children.Count > 0)
            {
                foreach (var child in myMan.Children)
                {
                    Console.WriteLine(child);
                }
            }
        }
    }
}
