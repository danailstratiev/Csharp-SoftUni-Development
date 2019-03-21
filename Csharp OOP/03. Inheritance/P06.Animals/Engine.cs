using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P06.Animals
{
    public class Engine
    {
        private AnimalFactory animalFactory;

        public Engine()
        {
            this.animalFactory = new AnimalFactory();
        }

        public void Run()
        {
            var animalType = Console.ReadLine();
            var animals = new List<Animal>();

            while (animalType != "Beast!")
            {
                try
                {
                    var animalInput = Console.ReadLine().Split();

                    var type = animalType;
                    var name = animalInput[0];
                    var age = int.Parse(animalInput[1]);
                    var gender = animalInput[2];

                    var animal = animalFactory.CreateAnimal(type, name, age, gender);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine(animal.ToString());
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
