using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P05.PizzaCalories
{
    public class Topping
    {
        private string toppingName;
        private decimal weight;

        public Topping(string topping, decimal weight)
        {
            this.ToppingName = topping;
            this.Weight = weight;
        }

        public string ToppingName
        {
            get => this.toppingName;

            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    Exception ex = new ArgumentException($"Cannot place {value} on top of your pizza.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.toppingName = value;
            }
        }

        public decimal Weight
        {
            get => this.weight;

            set
            {
                if (value < 1 || value > 50)
                {
                    Exception ex = new ArgumentException($"{this.ToppingName} weight should be in the range [1..50].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                weight = value;
            }
        }

        public decimal ToppingCalories { get => this.CalculateToppingCalories(); }

        private decimal CalculateToppingCalories()
        {
            var toppingModifier = 1m;

            switch (this.ToppingName.ToLower())
            {
                case "meat":
                    toppingModifier = 1.2m;
                    break;
                case "veggies":
                    toppingModifier = 0.8m;
                    break;
                case "cheese":
                    toppingModifier = 1.1m;
                    break;
                case "sauce":
                    toppingModifier = 0.9m;
                    break;
            }

            return toppingModifier * 2 * this.Weight;
        }
    }
}
