using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.MordorsCruelPlan
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var foodFactory = new FoodFactory();
            var allFood = new List<Food>();
            var moodFactory = new MoodFactory();

            foreach (var food in input)
            {
                var currentFood = foodFactory.Create(food);
                allFood.Add(currentFood);
            }

            var mood = moodFactory.Create(allFood);
            Console.WriteLine(mood);
        }
    }
}
