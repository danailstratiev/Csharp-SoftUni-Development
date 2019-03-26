using System;
using System.Collections.Generic;
using System.Text;

namespace P07.FoodShortage
{
    public abstract class Human : IBuyer
    {
        protected Human(string name, int age)
        {
            Name = name;
            Age = age;
            Food = 0;
        }

        public string Name { get; protected set; }

        public int Age { get; protected set; }

        public int Food { get; set; }

        public abstract void BuyFood();
        
    }
}
