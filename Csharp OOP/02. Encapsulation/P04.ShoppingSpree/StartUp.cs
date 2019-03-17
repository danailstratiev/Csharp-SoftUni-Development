using System;
using System.Linq;
using System.Collections.Generic;


namespace P04.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine().Split(";").ToArray();
            var products = Console.ReadLine().Split(";").ToArray();
            var allPeople = new List<Person>();
            var allProducts = new List<Product>();

            foreach (var dude in people)
            {
                var personInfo = dude.Split("=").ToArray();
                var currentPerson = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                allPeople.Add(currentPerson);
            }

            foreach (var item in products)
            {
                var productInfo = item.Split("=").ToArray();
                var currentProduct = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                allProducts.Add(currentProduct);
            }

            var input = Console.ReadLine();

            while (input != "END")
            {
                var currentLine = input.Split(" ").ToArray();
                var currentMan = currentLine[0];
                var currentProduct = currentLine[1];

                var foundPerson = allPeople.FirstOrDefault(x => x.Name == currentMan);
                var foundProduct = allProducts.FirstOrDefault(x => x.Name == currentProduct);

                if (foundPerson != null && foundProduct != null)
                {
                    if (foundPerson.Money - foundProduct.Cost >= 0)
                    {
                        Console.WriteLine($"{foundPerson.Name} bought {foundProduct.Name}");
                        foundPerson.Money -= foundProduct.Cost;
                        foundPerson.BagOfProducts.Add(foundProduct);
                    }
                    else
                    {
                        Console.WriteLine($"{foundPerson.Name} can't afford {foundProduct.Name}");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var person in allPeople)
            {
                if (person.BagOfProducts.Count > 0)
                {
                    var bag = new List<string>();

                    foreach (var product in person.BagOfProducts)
                    {
                        bag.Add(product.Name);
                    }

                    Console.WriteLine($"{person.Name} - {string.Join(", ", bag)}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
            }
        }
    }
}
