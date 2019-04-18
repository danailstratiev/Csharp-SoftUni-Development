using SoftUniRestaurant.Models.Drinks;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class DrinkFactory
    {
        public Drink CreateDrink(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                case "Juice":
                    return new Juice(name, servingSize, brand);
                case "Water":
                    return new Water(name, servingSize, brand);
                default:
                    return null;
            }
        }
    }
}
