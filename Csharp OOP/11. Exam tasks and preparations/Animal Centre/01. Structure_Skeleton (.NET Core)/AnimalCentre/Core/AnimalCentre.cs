using AnimalCentre.Core.Factories;
using AnimalCentre.Models;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private Dictionary<string, IProcedure> procedures;
        private Dictionary<string, SortedSet<string>> ownersAndPets;
        private AnimalFactory animalFactory;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, IProcedure> {
                {"Chip", new Chip()},
                {"DentalCare", new DentalCare() },
                {"NailTrim", new NailTrim() },
                {"Fitness",  new Fitness() },
                {"Play", new Play() },
                {"Vaccinate", new Vaccinate() }
            };
            this.ownersAndPets = new Dictionary<string, SortedSet<string>>();
            this.animalFactory = new AnimalFactory();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {

            var animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);
            return $"Animal {name} registered successfully";

        }

        public string Chip(string name, int procedureTime)
        {

            this.ValidateAnimal(name);
            var animal = this.hotel.Animals[name];
            this.procedures["Chip"].DoService(animal, procedureTime);
            return $"{name} had chip procedure";

        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.ValidateAnimal(name);
            var animal = this.hotel.Animals[name];

            this.procedures["Vaccinate"].DoService(animal, procedureTime);
            return $"{name} had vaccination procedure";

        }

        public string Fitness(string name, int procedureTime)
        {

            this.ValidateAnimal(name);
            var animalKVP = this.hotel.Animals.FirstOrDefault(x => x.Key == name);
            this.procedures["Fitness"].DoService(animalKVP.Value, procedureTime);
            return $"{name} had fitness procedure";

        }

        public string Play(string name, int procedureTime)
        {

            this.ValidateAnimal(name);
            var animalKVP = this.hotel.Animals.FirstOrDefault(x => x.Key == name);
            this.procedures["Play"].DoService(animalKVP.Value, procedureTime);
            return $"{name} was playing for {procedureTime} hours";

        }

        public string DentalCare(string name, int procedureTime)
        {

            this.ValidateAnimal(name);
            var animalKVP = this.hotel.Animals.FirstOrDefault(x => x.Key == name);
            this.procedures["DentalCare"].DoService(animalKVP.Value, procedureTime);
            return $"{name} had dental care procedure";

        }

        public string NailTrim(string name, int procedureTime)
        {

            this.ValidateAnimal(name);
            var animalKVP = this.hotel.Animals.FirstOrDefault(x => x.Key == name);
            this.procedures["NailTrim"].DoService(animalKVP.Value, procedureTime);
            return $"{name} had nail trim procedure";

        }

        public string Adopt(string animalName, string owner)
        {
            this.ValidateAnimal(animalName);
            var animal = this.hotel.Animals.FirstOrDefault(x => x.Key == animalName).Value;
            this.hotel.Adopt(animalName, owner);
            if (!this.ownersAndPets.ContainsKey(owner))
            {
                this.ownersAndPets[owner] = new SortedSet<string>();
            }

            this.ownersAndPets[owner].Add(animalName);

            if (animal.IsChipped == true)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }

        }

        public string History(string type)
        {
            return procedures[type].History();
        }

        public void ValidateAnimal(string animalName)
        {
            if (!this.hotel.Animals.Any(x => x.Key == animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }

        public Dictionary<string, SortedSet<string>> GetOwnersAndPets()
        {
            return this.ownersAndPets;
        }
    }
}
