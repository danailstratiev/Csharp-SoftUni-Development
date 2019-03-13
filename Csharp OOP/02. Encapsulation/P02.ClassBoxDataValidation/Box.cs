using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ClassBoxDataValidation
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal heigth;

        public Box(decimal length, decimal width, decimal heigth)
        {
            this.Length = length;
            this.Width = width;
            this.Heigth = heigth;
        }

        public decimal Length
        {
            get => this.length;

            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);
                }

                this.width = value;
            }
        }

        public decimal Heigth
        {
            get => this.heigth ;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Heigth cannot be zero or negative.");
                    Environment.Exit(0);
                }

                this.heigth = value;
            }
        }

        public decimal CalculateLateralSurfaceArea()
        {
            return (2 * this.Length * this.Heigth) + (2 * this.Width * this.Heigth);
        }

        public decimal CalculateVolume()
        {
            return this.Length * this.Heigth * this.Width;
        }

        public decimal CalculateSurfaceArea()
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Heigth) + (2 * this.Width * this.Heigth);
        }
    }
}
