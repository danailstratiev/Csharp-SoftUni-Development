using System;
using System.Collections.Generic;
using System.Text;

namespace P12_Google
{
   public class Person
    {
        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Child> Children { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
