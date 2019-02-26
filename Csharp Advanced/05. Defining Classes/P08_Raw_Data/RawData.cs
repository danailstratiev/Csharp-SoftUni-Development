using System;
using System.Linq;
using System.Collections.Generic;


namespace P08_Raw_Data
{
   public class RawData
    {
       public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                //“< Model > < EngineSpeed > < EnginePower > < CargoWeight > < CargoType > < Tire1Pressure >
                //    < Tire1Age > < Tire2Pressure > < Tire2Age > < Tire3Pressure >
                //    < Tire3Age > < Tire4Pressure > < Tire4Age >” 
                var currentCar = Console.ReadLine().Split(" ").ToArray();
                var model = currentCar[0];
                var engineSpeed = int.Parse(currentCar[1]);
                var enginePower = int.Parse(currentCar[2]);
                var cargoWeight = int.Parse(currentCar[3]);
                var cargoType = currentCar[4];
                var tire1Pressure = double.Parse(currentCar[5]);
                var tire1Age = int.Parse(currentCar[6]);
                var tire2Pressure = double.Parse(currentCar[7]);
                var tire2Age = int.Parse(currentCar[8]);
                var tire3Pressure = double.Parse(currentCar[9]);
                var tire3Age = int.Parse(currentCar[10]);
                var tire4Pressure = double.Parse(currentCar[11]);
                var tire4Age = int.Parse(currentCar[12]);

                var tire1 = new Tire()
                {
                    TireAge = tire1Age,
                    TirePressure = tire1Pressure
                };
                var tire2 = new Tire()
                {
                    TireAge = tire1Age,
                    TirePressure = tire1Pressure
                };
                var tire3 = new Tire()
                {
                    TireAge = tire1Age,
                    TirePressure = tire1Pressure
                };
                var tire4 = new Tire()
                {
                    TireAge = tire1Age,
                    TirePressure = tire1Pressure
                };

                var tires = new List<Tire>();

                tires.Add(tire1);
                tires.Add(tire2);
                tires.Add(tire3);
                tires.Add(tire4);

                var engine = new Engine
                {
                    EnginePower = enginePower,
                    EngineSpeed = engineSpeed
                };

                var cargo = new Cargo
                {
                    CargoType = cargoType,
                    CargoWeight = cargoWeight
                };

                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            var command = Console.ReadLine();
            var filteredCars = new List<Car>();

            if (command == "fragile")
            {
                filteredCars = cars.Where(x => x.Cargo.CargoType == "fragile").
                    Where(y => y.Tires.Any(t => t.TirePressure < 1)).ToList();
            }
            else if (command == "flamable" )
            {
                filteredCars = cars.Where(x => x.Cargo.CargoType == "flamable").
                    Where(e => e.Engine.EnginePower > 250).ToList();
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
