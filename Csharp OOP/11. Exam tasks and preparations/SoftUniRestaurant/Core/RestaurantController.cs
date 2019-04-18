namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Tables;
    using System.Collections.Generic;
    using SoftUniRestaurant.Models.Foods;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;
    using System.Linq;
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System.Text;

    public class RestaurantController
    {
        public List<IFood> Foods { get; private set; }
        public List<IDrink> Drinks { get; private set; }
        public List<Table> Tables { get; private set; }
        public decimal TotalIncome { get; private set; }

        public RestaurantController()
        {
            this.Foods = new List<IFood>();
            this.Drinks = new List<IDrink>();
            this.Tables = new List<Table>();
            this.TotalIncome = 0;
        }

        public string AddFood(string type, string name, decimal price)
        {
            var foodFactory = new FoodFactory();

            try
            {
                var food = foodFactory.CreateFood(type, name, price);

                var message = $"Added {food.Name} ({food.GetType().Name}) with price {food.Price} to the pool";
                this.Foods.Add(food);
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drinkFactory = new DrinkFactory();

            try
            {
                var drink = drinkFactory.CreateDrink(type, name, servingSize, brand);
                var message = $"Added {drink.Name} ({drink.Brand}) to the drink pool";
                this.Drinks.Add(drink);
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            var tableFactory = new TableFactory();

            try
            {
                var table = tableFactory.CreateTable(type, tableNumber, capacity);
                var message = $"Added table number {table.TableNumber} in the restaurant";
                Tables.Add(table);
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ReserveTable(int numberOfPeople)
        {
            if (this.Tables.Any(x => x.Capacity >= numberOfPeople))
            {
                var currentTable = this.Tables.FirstOrDefault(x => x.Capacity >= numberOfPeople && x.IsReserved == false);

                if (currentTable != null)
                {
                    currentTable.Reserve(numberOfPeople);

                    return $"Table {currentTable.TableNumber} has been reserved for {numberOfPeople} people";
                }
                else
                {
                    return $"No available table for {numberOfPeople} people";
                }
            }
            else
            {
                return $"No available table for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var currentTable = this.Tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (currentTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }
            else
            {
                var currentFood = this.Foods.FirstOrDefault(x => x.Name == foodName);

                if (currentFood == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    currentTable.OrderFood(currentFood);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var currentTable = this.Tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (currentTable == null)
            {
                return $"Could not find table with {tableNumber}";
            }
            else
            {
                var currentDrink = this.Drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

                if (currentDrink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    currentTable.OrderDrink(currentDrink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }

        }

        public string LeaveTable(int tableNumber)
        {
            var currentTable = this.Tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = currentTable.GetBill();
            this.TotalIncome += bill;

            var sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:F2}");

            currentTable.Clear();
            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (var table in this.Tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetOccupiedTablesInfo()
        {
            var sb = new StringBuilder();

            foreach (var table in this.Tables.Where(x => x.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetSummary()
        {
            return $"Total income: {this.TotalIncome:F2}lv";
        }
    }
}
