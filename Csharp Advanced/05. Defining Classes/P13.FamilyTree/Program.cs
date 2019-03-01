using System;
using System.Linq;
using System.Collections.Generic;


namespace P13.FamilyTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var data = Console.ReadLine();

            var connections = new List<Connection>();
            var peopleInfo = new List<Person>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                if (input.Contains('-'))
                {
                    var splitInput = input.Split(" - ").ToArray();

                    var parentArgument = splitInput[0];
                    var childArgument = splitInput[1];

                    var parent = new Person(parentArgument);
                    var child = new Person(childArgument);

                    var connection = new Connection(parent, child);

                    connections.Add(connection);
                }
                else
                {
                    var splitInput = input.Split(" ").ToArray();

                    var name = $"{splitInput[0]} {splitInput[1]}";
                    var birthdate = splitInput[2];

                    var person = new Person(name, birthdate);

                    peopleInfo.Add(person);
                }

                input = Console.ReadLine();
            }

            var mainPerson = peopleInfo.FirstOrDefault(x => x.Name == data || x.Birthdate == data);

            var filteredConnections = connections.Where(x => x.Parent.Birthdate == mainPerson.Birthdate ||
            x.Parent.Name == mainPerson.Name ||
            x.Child.Birthdate == mainPerson.Birthdate ||
            x.Child.Name == mainPerson.Name);

            var result = new Result();
            result.MainPerson = mainPerson;

            foreach (var connection in filteredConnections)
            {
                bool isChildByDate = connection.Child.Birthdate == mainPerson.Birthdate;
                bool isChildByName = connection.Child.Name == mainPerson.Name;

                bool isParentByDate = connection.Parent.Birthdate == mainPerson.Birthdate;
                bool isParentByName = connection.Parent.Name == mainPerson.Name;

                if (isChildByDate || isChildByName)
                {
                    Person parent = peopleInfo.
                        FirstOrDefault(x => x.Name == connection.Parent.Name ||
                    x.Birthdate == connection.Parent.Birthdate);

                    result.Parents.Add(parent);
                }
                else if (isParentByDate || isParentByName)
                {
                    Person child = peopleInfo.
                        FirstOrDefault(x => x.Name == connection.Child.Name ||
                    x.Birthdate == connection.Child.Birthdate);

                    result.Children.Add(child);
                }
            }

            Console.WriteLine(result);
        }
    }
}
