using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public class Cat : Animal
    {
        public Cat(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
    }
}
