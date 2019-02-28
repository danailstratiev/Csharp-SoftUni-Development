using System;
using System.Linq;
using System.Collections.Generic;


namespace P10_Car_Salesman
{
    public class CarSalesman
    {
        public static void Main(string[] args)
        {
            var numberOfEngines = int.Parse(Console.ReadLine());
            var allEngines = new List<Engine>();
            var allCars = new List<Car>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                //DSL-13 305 55 A+
                var engineProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var model = engineProperties[0];
                var power = int.Parse(engineProperties[1]);
               
                var engine = new Engine(model, power);
                
                if (engineProperties.Length == 3)
                {
                    if (int.TryParse(engineProperties[2], out int result))
                    {
                        engine.Displacement = result.ToString();
                    }
                    else
                    {
                        engine.Efficiency = engineProperties[2];
                    }
                }
                else if (engineProperties.Length == 4)
                {
                    engine.Displacement = engineProperties[2];
                    engine.Efficiency = engineProperties[3];
                }

                allEngines.Add(engine);
            }

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                //VolkswagenPassat DSL-10 1375 Blue
                var carProperties = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var carModel = carProperties[0];
                var engineModel = carProperties[1];
                var currentEngine = allEngines.FirstOrDefault(x => x.Model == engineModel);

                var car = new Car(carModel, currentEngine);

                if (carProperties.Length == 3)
                {
                    if (int.TryParse(carProperties[2], out int result))
                    {
                        car.Weight = result.ToString();
                    }
                    else
                    {
                        car.Color = carProperties[2];
                    }
                }
                else if (carProperties.Length == 4)
                {
                    car.Weight = carProperties[2];
                    car.Color = carProperties[3];
                }

                allCars.Add(car);
            }

            foreach (var car in allCars)
            {                
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");

            }
        }
    }
}
