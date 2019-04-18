namespace SoftUniRestaurant
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SoftUniRestaurant.Core;

    public class StartUp
    {
        public static void Main()
        {
            var restaurantController = new RestaurantController();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = commands[0];

                switch (command)
                {
                    case "AddFood":
                        var type = commands[1];
                        var name = commands[2];
                        var price = decimal.Parse(commands[3]);
                        Console.WriteLine(restaurantController.AddFood(type, name, price));
                        break;
                    case "AddDrink":
                        type = commands[1];
                        name = commands[2];
                        var servingSize = int.Parse(commands[3]);
                        var brand = commands[4];
                        Console.WriteLine(restaurantController.AddDrink(type, name, servingSize, brand));
                        break;
                    case "AddTable":
                        type = commands[1];
                        var tableNumber = int.Parse(commands[2]);
                        var capacity = int.Parse(commands[3]);
                        Console.WriteLine(restaurantController.AddTable(type, tableNumber, capacity));
                        break;
                    case "ReserveTable":
                       var numberOfPeople = int.Parse(commands[1]);
                        Console.WriteLine(restaurantController.ReserveTable(numberOfPeople));
                        break;
                    case "OrderFood":
                        tableNumber = int.Parse(commands[1]);
                        var foodName = commands[2];
                        Console.WriteLine(restaurantController.OrderFood(tableNumber, foodName));
                        break;
                    case "OrderDrink":
                        tableNumber = int.Parse(commands[1]);
                        var drinkName = commands[2];
                        var drinkBrand = commands[3];
                        Console.WriteLine(restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand));
                        break;
                    case "LeaveTable":
                        tableNumber = int.Parse(commands[1]);
                        Console.WriteLine(restaurantController.LeaveTable(tableNumber));
                        break;
                    case "GetFreeTablesInfo":
                        Console.WriteLine(restaurantController.GetFreeTablesInfo());
                        break;
                    case "GetOccupiedTablesInfo":
                        Console.WriteLine(restaurantController.GetOccupiedTablesInfo());
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(restaurantController.GetSummary());
        }
    }
}
