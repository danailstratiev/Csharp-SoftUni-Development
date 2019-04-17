using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public class Dog : Animal
    {
        public Dog(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
    }
}
