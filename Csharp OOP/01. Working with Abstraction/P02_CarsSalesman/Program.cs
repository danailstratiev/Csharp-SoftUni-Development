using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            EngineFactory engineFactory = new EngineFactory();
            CarFactory carFactory = new CarFactory();
            CarSalesman carSalesman = new CarSalesman(engineFactory, carFactory);

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddEngine(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddCar(parameters);
            }

            foreach (var car in carSalesman.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }

}
