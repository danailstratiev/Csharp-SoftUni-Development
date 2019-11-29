using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat,
            string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        private string GetIngredientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }

        public override SandwichPrototype Clone()
        {
            var ingredients = this.GetIngredientsList();

            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return this.MemberwiseClone() as SandwichPrototype;
        }
    }
}
