namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get => radius; private set => radius = value; }

        public override double CalculateArea()
        {
            return Math.Pow(this.Radius, 2) * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return this.Radius * 2 * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + "Circle";
        }
    }
}
