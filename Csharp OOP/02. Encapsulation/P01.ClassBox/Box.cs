using System;
using System.Collections.Generic;
using System.Text;

namespace P01.ClassBox
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box (decimal length, decimal width, decimal height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public decimal CalculateLateralSurfaceArea()
        {
            return (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public decimal CalculateVolume()
        {
            return this.length * this.height * this.width;
        }

        public decimal CalculateSurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.length * this.height) + (2*this.width * this.height);
        }
    }
}
