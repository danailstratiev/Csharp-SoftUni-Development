using System;
using System.Linq;

namespace P02.VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var carFuel = double.Parse(carInfo[1]);
            var carConsumption = double.Parse(carInfo[2]);
            var carTank = double.Parse(carInfo[3]);
            var car = new Car(carFuel, carConsumption, carTank);
            var truckInfo = Console.ReadLine().Split();
            var truckFuel = double.Parse(truckInfo[1]);
            var truckConsumption = double.Parse(truckInfo[2]);
            var truckTank = double.Parse(truckInfo[3]);
            var truck = new Truck(truckFuel, truckConsumption, truckTank);
            var busInfo = Console.ReadLine().Split();
            var busFuel = double.Parse(busInfo[1]);
            var busConsumption = double.Parse(busInfo[2]);
            var busTank = double.Parse(busInfo[3]);
            var bus = new Bus(busFuel, busConsumption, busTank);

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
                    else if (vehicle == "Bus")
                    {
                        Console.WriteLine(bus.DriveNotEmpty(distance));
                    }
                }
                else if (command == "DriveEmpty")
                {
                    var distance = double.Parse(currentInput[2]);

                    Console.WriteLine(bus.Drive(distance));
                }
                else if (command == "Refuel")
                {
                    var fuel = double.Parse(currentInput[2]);
                    if (vehicle == "Car")
                    {
                        try
                        {
                            car.Refuel(fuel);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (vehicle == "Truck")
                    {
                        try
                        {
                            truck.Refuel(fuel);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (vehicle == "Bus")
                    {
                        try
                        {
                            bus.Refuel(fuel);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
