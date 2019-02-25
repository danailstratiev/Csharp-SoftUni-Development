
using System.Text;

namespace Lab_02_Car_Extension
{
    public class Car
    {
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
