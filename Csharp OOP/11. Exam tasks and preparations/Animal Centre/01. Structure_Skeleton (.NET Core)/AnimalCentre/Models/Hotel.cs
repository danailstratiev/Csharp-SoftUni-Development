using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;

        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>(Capacity);
        }

        public IReadOnlyDictionary<string, IAnimal> Animals { get => animals.ToImmutableDictionary(); }

        public void Accommodate(IAnimal animal)
        {
            if (this.animals.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");

            }

            if (this.Animals.Any(x => x.Key == animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.Any(x => x.Key == animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
