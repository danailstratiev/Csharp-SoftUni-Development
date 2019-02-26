using System;
using System.Collections.Generic;
using System.Text;

namespace P07_Speed_Racing
{
   public class Car
    {
        // model, fuel amount, fuel consumption for 1 kilometer 

        public string Model { get; set; }

        public decimal FuelAmount { get; set; }

        public decimal FuelConsumption { get; set; }

        public decimal TravelledDistance { get; set; }

        public void IsThereEnoughFuel(decimal distance)
        {
            var canMoveOn = this.FuelAmount - this.FuelConsumption * distance >= 0;

            if (canMoveOn == false)
            {
               Console.WriteLine ("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= FuelConsumption * distance;
                this.TravelledDistance += distance;
            }
        }
    }
}
