using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCentre.Models
{
    public class Pig : Animal
    {
        public Pig(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
    }
}
