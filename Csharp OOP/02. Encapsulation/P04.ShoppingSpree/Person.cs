using System;
using System.Collections.Generic;
using System.Text;

namespace P04.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public List<Product> BagOfProducts { get; private set; }

        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }

                this.money = value;
            }
        }
    }
}
