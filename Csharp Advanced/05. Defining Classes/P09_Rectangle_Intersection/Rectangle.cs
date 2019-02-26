using System;
using System.Collections.Generic;
using System.Text;

namespace P09_Rectangle_Intersection
{
   public class Rectangle
    {
        public string ID { get; set; }

        public double Width { get; set; }
               
        public double Height { get; set; }

        public double CoordinateX { get; set; }

        public double CoordinateY { get; set; }

        public bool Intersect(Rectangle secondRectangle)
        {
            if (this.CoordinateX + this.Width < secondRectangle.CoordinateX ||
                this.CoordinateY + this.Height < secondRectangle.CoordinateY ||
                secondRectangle.CoordinateX + secondRectangle.Width < this.CoordinateX ||
                secondRectangle.CoordinateY + secondRectangle.Height < this.CoordinateY
                )
            {
                return false;
            }

            return true;
        }
    }
}
