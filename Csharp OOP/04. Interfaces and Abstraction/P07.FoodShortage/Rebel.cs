using System;
using System.Collections.Generic;
using System.Text;

namespace P07.FoodShortage
{
    public class Rebel : Human
    {

        public Rebel(string name, int age, string group)
            :base (name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        
        public string Group { get;private set; }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
