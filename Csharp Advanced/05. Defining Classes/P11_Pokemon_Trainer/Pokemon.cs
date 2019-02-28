using System;
using System.Collections.Generic;
using System.Text;

namespace P11_Pokemon_Trainer
{
   public class Pokemon
    {
        //Pokemon have a name, an element and health,
        //all values are mandatory

        public Pokemon(string name, string element,
            int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
    }
}
