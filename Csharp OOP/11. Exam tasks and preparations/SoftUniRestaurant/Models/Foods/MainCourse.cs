using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int InitialServingSize = 300;

        public MainCourse(string name, decimal price) 
            : base(name, InitialServingSize, price)
        {
        }
    }
}
