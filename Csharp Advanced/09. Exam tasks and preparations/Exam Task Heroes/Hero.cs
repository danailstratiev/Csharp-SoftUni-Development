using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        //        •	Name: string
        //•	Level: int
        //•	Item: Item

        public Hero(string name, int level, Item item)
        {
            this.Name = name;

            this.Level = level;

            this.Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            //"Hero: {Name} – {Level}lvl"
            //"Item:"
            //"  * Strength: {Strength Value}"
            //"  * Ability: {Ability Value}"
            //"  * Intelligence: {Intelligence Value}"

            return $"Hero: {this.Name} – {this.Level}lvl" + Environment.NewLine +
                   this.Item.ToString();
        }
    }
}
