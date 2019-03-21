using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P06.Animals
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, int age, string gender)
        {
            type = type.ToLower();

            switch (type)
            {
                case "dog":
                    return new Dog(name, age, gender);
                case "cat":
                    return new Cat(name, age, gender);
                case "frog":
                    return new Frog(name, age, gender);
                case "kitten":
                    return new Kitten(name, age);
                case "tomcat":
                    return new Tomcat(name, age);
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
