namespace P03.WildFarm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using P03.WildFarm.Animals;
    using P03.WildFarm.Foods;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var input = Console.ReadLine();

            while (input != "End")
            {
                var animalInput = input.Split();
                
                var animalFactory = new AnimalFactory();
                var animal = animalFactory.CreateAnimal(animalInput);
                
                Console.WriteLine(animal.ProduceSound());

                var foodInput = Console.ReadLine().Split();
                
                var foodFactory = new FoodFactory();
                var food = foodFactory.CreateFood(foodInput);
                
                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
