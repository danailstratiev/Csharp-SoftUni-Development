using System;
using System.Collections.Generic;
using System.Text;

namespace P11_Pokemon_Trainer
{
   public class Trainer
    {
        //Trainers have a name, number of badges 
        //  and a collection of pokemon

        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = pokemons;
        }
        
        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
