namespace P01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get;protected set; }

        public double FuelConsumption { get; protected set; }

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
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
