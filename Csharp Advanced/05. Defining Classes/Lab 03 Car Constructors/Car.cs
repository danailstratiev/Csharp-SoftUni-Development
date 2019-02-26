using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_03_Car_Constructors
{
    public class Car
    {
        /// <summary>
        ///    This class represents a car. 
        /// </summary>
        // This adds comments for the class (hint)

        private string make;
        private string model;
        private int year;

        // By adding "this" we can simply add the properties we need
        public Car()
            :this ("VW", "Golf", 2025)
        {

        }

        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(
           string make,
           string model,
           int year,
           double fuelQuantuty,
           double fuelConsumption)
           : this(make, model, year)
        {
            this.FuelQuantity = FuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            var canContinue = this.FuelQuantity - this.FuelConsumption * distance >= 0;

            if (canContinue)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
            }
            else
            {
                throw new CarCannotContinueExeption("Not enough fuel!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.Append($"Fuel: {this.FuelQuantity:F2}L");
            return sb.ToString();
        }
    }
}
