using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models
{
    public class Lion : Animal
    {
        public Lion(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
    }
}
