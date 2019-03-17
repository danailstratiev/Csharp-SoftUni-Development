using System;
using System.Collections.Generic;
using System.Text;

namespace P05.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    Exception ex = new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                this.name = value;
            }
        }

        public void Add(Topping topping)
        {
            if (this.toppings.Count <= 10)
            {
                this.toppings.Add(topping);
            }
            else
            {
                Exception ex = new ArgumentException("Number of toppings should be in range [0..10].");
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }

        public Dough Dough
        {
            get => dough;

            set
            {
                dough = value;
            }
        }

        public int CountOfToppings { get => this.toppings.Count; }

        public decimal TotalCalories { get => this.CalculateTotalCalories();}

        public decimal CalculateTotalCalories()
        {
            var totalCalories = 0m;

            foreach (var topping in this.toppings)
            {
                totalCalories += topping.ToppingCalories;
            }

            totalCalories += this.dough.DoughtCalories;

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:F2} Calories.";
        }
    }
}
