using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        protected Drink(string name, int servingSize, decimal price, string brand)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name
        {
            get => this.name;

            protected set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }

                this.name = value;
            }
        }

        public int ServingSize
        {
            get => this.servingSize;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }

                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }

                this.price = value;
            }
        }

        public string Brand
        {
            get => this.brand;

            protected set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Brand cannot be null or white space!");
                }

                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:F2}lv";
        }
    }
}
