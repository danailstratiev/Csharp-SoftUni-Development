using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.Vehicles
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var carFuel = double.Parse(carInfo[1]);
            var carConsumption = double.Parse(carInfo[2]);
            var car = new Car(carFuel, carConsumption);
            var truckInfo = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInfo[1]);
            var truckConsumption = double.Parse(truckInfo[2]);
            var truck = new Truck(truckFuel, truckConsumption);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentInput = Console.ReadLine().Split();
                var command = currentInput[0];
                var vehicle = currentInput[1];

                if (command == "Drive")
                {
                    var distance = double.Parse(currentInput[2]);
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                }
                else if (command == "Refuel")
                {
                    var fuel = double.Parse(currentInput[2]);
                    if (vehicle == "Car")
                    {
                        car.Refuel(fuel);
                    }
                    else if(vehicle == "Truck")
                    {
                        truck.Refuel(fuel);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
