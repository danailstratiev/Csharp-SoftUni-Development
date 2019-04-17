namespace AnimalCentre.Models.Contracts
{
    using System.Collections.Generic;

    public interface IHotel
    {
        void Accommodate(IAnimal animal);

        void Adopt(string animalName, string owner);
    }
}
