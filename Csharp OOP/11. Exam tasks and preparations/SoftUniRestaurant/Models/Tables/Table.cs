using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        protected int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
            this.Price = 0;
        }

        public int TableNumber { get;protected set; }

        public int Capacity
        {
            get => this.capacity;

            protected set
            {
                if (value < 0)
                {
                    // Place to check in case of failures
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = NumberOfPeople;
            }
        }

        public decimal PricePerPerson { get;protected set; }

        public bool IsReserved { get;protected set; }

        public decimal Price { get; protected set; }

        public void Reserve(int numberOfPeople)
        {
            this.numberOfPeople = numberOfPeople;

            if (this.NumberOfPeople <= this.Capacity)
            {
                this.IsReserved = true;
                this.Price = this.PricePerPerson * numberOfPeople;
            }
            else
            {
                this.IsReserved = false;
            }
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            var totalBill = this.Price;

            foreach (var drink in this.drinkOrders)
            {
                totalBill += drink.Price;
            }

            foreach (var food in this.foodOrders)
            {
                totalBill += food.Price;
            }

            return totalBill;
        }

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.Price = 0;
        }

       public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

       public string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");

            if (this.foodOrders.Any())
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");

                foreach (var food in this.foodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }
            else
            {
                sb.AppendLine("Food orders: None");
            }

            if (this.drinkOrders.Any())
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                foreach (var drink in this.drinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }
            else
            {
                sb.AppendLine("Drink orders: None");
            }

            return sb.ToString().Trim();
        }
    }
}
