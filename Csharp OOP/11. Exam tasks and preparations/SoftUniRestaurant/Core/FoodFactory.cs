using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class FoodFactory
    {
        public Food CreateFood(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                case "MainCourse":
                    return new MainCourse(name, price);
                case "Salad":
                    return new Salad(name, price);
                case "Soup":
                    return new Soup(name, price);
                default:
                    return null;
            }
        }
    }
}
