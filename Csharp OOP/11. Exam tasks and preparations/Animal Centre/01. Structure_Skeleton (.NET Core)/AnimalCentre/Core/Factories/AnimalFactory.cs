using AnimalCentre.Models;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            switch (type)
            {
                case "Lion":
                    return new Lion(name, happiness, energy, procedureTime);
                case "Cat":
                    return new Cat(name, happiness, energy, procedureTime);
                case "Dog":
                    return new Dog(name, happiness, energy, procedureTime);
                case "Pig":
                    return new Pig(name, happiness, energy, procedureTime);
                default:
                    return null;
            }
        }
    }
}
