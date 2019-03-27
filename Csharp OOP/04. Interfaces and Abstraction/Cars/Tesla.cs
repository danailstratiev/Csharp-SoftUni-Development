namespace Cars
{
    using System;

    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int bateries)
        {
           this.Model = model;
           this.Color = color;
           this.Bateries = bateries;
        }

        public string Model {get; private set;}

        public string Color {get; private set;}

        public int Bateries { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Bateries} Batteries" + Environment.NewLine +
                this.Start() + Environment.NewLine +
                this.Stop();
        }
    }
}
