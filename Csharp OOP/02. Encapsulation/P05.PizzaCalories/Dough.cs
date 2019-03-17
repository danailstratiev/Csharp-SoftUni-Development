using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P05.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;


        public Dough(string flourType, string bakingTechnique, decimal weigth)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weigth;
        }

        public string FlourType
        {
            get => this.flourType;

            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    InvalidDoughMessage();
                    Environment.Exit(0);
                }

                this.flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    InvalidDoughMessage();
                    Environment.Exit(0);
                }

                this.bakingTechnique = value.ToLower();
            }
        }

        public decimal Weight
        {
            get => this.weight;

            set
            {
                if (value < 1 || value > 200)
                {
                    Exception ex = new ArgumentException("Dough weight should be in the range [1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                this.weight = value;
            }
        }

        public decimal DoughtCalories { get => this.CalorieCounter(); }

        private decimal CalorieCounter()
        {
            var flourModifier = 1m;

            switch (this.FlourType)
            {
                case "white":
                    flourModifier = 1.5m;
                    break;
                case "wholegrain":
                    flourModifier = 1.0m;
                    break;
            }

            var bakeModifier = 1m;
            switch (this.BakingTechnique)
            {
                case "crispy":
                    bakeModifier = 0.9m;
                    break;
                case "chewy":
                    bakeModifier = 1.1m;
                    break;
                case "homemade":
                    bakeModifier = 1.0m;
                    break;
            }

            return flourModifier * bakeModifier * weight * 2;
        }

        private void InvalidDoughMessage()
        {
            Console.WriteLine("Invalid type of dough.");
        }
    }
}
