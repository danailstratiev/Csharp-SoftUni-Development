using System;

namespace P02.VehiclesExtension
{
    public abstract class Vehicle
    {
        protected double fuelQuantityy;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public double FuelQuantity
        {
            get => this.fuelQuantityy;

            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }

                this.fuelQuantityy = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public string Drive(double distance)
        {
            var distanceTravelled = distance * this.FuelConsumption;

            if (this.FuelQuantity >= distanceTravelled)
            {
                this.FuelQuantity -= distanceTravelled;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel + this.FuelQuantity > this.TankCapacity)
            {
               throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
