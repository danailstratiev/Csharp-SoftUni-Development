using System;
using System.Collections.Generic;
using System.Text;

namespace P12_Google
{
   public class Pokemon
    {
        //•	“< Name > pokemon<pokemonName> < pokemonType >”

        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Type}";
        }
    }
}
