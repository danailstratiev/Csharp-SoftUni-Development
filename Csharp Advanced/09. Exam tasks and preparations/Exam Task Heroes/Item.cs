using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;

            this.Ability = ability;

            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public override string ToString()
        {
            //            "Item:"
            //"  * Strength: {Strength Value}"
            //"  * Ability: {Ability Value}"
            //"  * Intelligence: {Intelligence Value}"

            return "Item:" + Environment.NewLine +
                $"  * Strength: {this.Strength}" + Environment.NewLine +
                $"  * Ability: {this.Ability}" + Environment.NewLine +
                $"  * Intelligence: {this.Intelligence}";
        }
    }
}
