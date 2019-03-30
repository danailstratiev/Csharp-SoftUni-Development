namespace P03.WildFarm.Animals
{
    using P03.WildFarm.Animals.Birds;
    using P03.WildFarm.Animals.Mammals;
    using P03.WildFarm.Animals.Mammals.Felines;
    using System;

    public class AnimalFactory
    {
        public Animal CreateAnimal (string[] animalInput)
        {
            var animalType = animalInput[0];
            var animalName = animalInput[1];
            var animalWeight = double.Parse(animalInput[2]);

            switch (animalType)
            {
                case "Owl":
                    var wingSize = double.Parse(animalInput[3]);
                    return new Owl(animalName, animalWeight, wingSize);
                case "Hen":
                    wingSize = double.Parse(animalInput[3]);
                    return new Hen(animalName, animalWeight, wingSize);
                case "Mouse":
                    var livingRegion = animalInput[3];
                    return new Mouse(animalName, animalWeight, livingRegion);
                case "Dog":
                    livingRegion = animalInput[3];
                    return new Dog(animalName, animalWeight, livingRegion);
                case "Cat":
                    livingRegion = animalInput[3];
                    var breed = animalInput[4];
                    return new Cat(animalName, animalWeight, livingRegion, breed);
                case "Tiger":
                    livingRegion = animalInput[3];
                    breed = animalInput[4];
                    return new Tiger(animalName, animalWeight, livingRegion, breed);
            }

            return null;
        }
    }
}
