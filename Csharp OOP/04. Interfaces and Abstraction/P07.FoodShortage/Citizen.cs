using System;
using System.Collections.Generic;
using System.Text;

namespace P07.FoodShortage
{
    public class Citizen : Human
    {
        public Citizen(string name, int age, string id, string birthdate)
            : base(name, age)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
