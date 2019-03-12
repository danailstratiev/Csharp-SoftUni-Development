namespace P02_CarsSalesman
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class CarSalesman
    {
        private List<Car> cars;
        private List<Engine> engines;
        private EngineFactory engineFactory;
        private CarFactory carFactory;

        public CarSalesman(EngineFactory engineFactory, CarFactory carFactory)
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
            this.engineFactory = engineFactory;
            this.carFactory = carFactory;
        }

        public void AddEngine(string[] parameters)
        {
            Engine engine = engineFactory.Create(parameters);
            this.engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            Car car = carFactory.Create(parameters, this.engines);
            this.cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}
