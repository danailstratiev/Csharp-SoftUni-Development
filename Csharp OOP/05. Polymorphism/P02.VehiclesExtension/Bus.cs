using System;
using System.Collections.Generic;
using System.Text;

namespace P02.VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public string DriveNotEmpty(double distance)
        {
            var distanceTravelled = distance * (this.FuelConsumption + 1.4);

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
    }
}
