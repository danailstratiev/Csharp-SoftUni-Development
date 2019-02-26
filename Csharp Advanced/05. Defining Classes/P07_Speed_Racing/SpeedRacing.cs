using System;
using System.Linq;
using System.Collections.Generic;


namespace P07_Speed_Racing
{
   public class SpeedRacing
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ").ToArray();

                var currentCar = new Car()
                {
                    Model = input[0],
                    FuelAmount = decimal.Parse(input[1]),
                    FuelConsumption = decimal.Parse(input[2]),
                    TravelledDistance = 0
                };

                cars.Add(currentCar);
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                var drive = command.Split(" ").ToArray();
                var model = drive[1];
                var distance = decimal.Parse(drive[2]);

                var thisCar = cars.Where(x => x.Model == model).FirstOrDefault();
                thisCar.IsThereEnoughFuel(distance);                  

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance:F0}");
            }
        }
    }
}
