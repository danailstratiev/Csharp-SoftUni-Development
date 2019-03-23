using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P05.MordorsCruelPlan
{
    public class MoodFactory
    {
        public Mood Create(List<Food> foods)
        {
            var totalFoodPoints = foods.Sum(x => x.Points);

            if (totalFoodPoints < -5)
            {
                return new Angry(totalFoodPoints);
            }
            else if (totalFoodPoints >= -5 && totalFoodPoints <= 0)
            {
                return new Sad(totalFoodPoints);
            }
            else if (totalFoodPoints >= 1 && totalFoodPoints <= 15)
            {
                return new Happy(totalFoodPoints);
            }
            else
            {
                return new JavaScript(totalFoodPoints);
            }
        }
    }
}
