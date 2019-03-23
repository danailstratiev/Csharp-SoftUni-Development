using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P05.MordorsCruelPlan
{
    public class FoodFactory
    {
        public Food Create(string name)
        {
            switch (name.ToLower())
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "honeycake":
                    return new HoneyCake();
                case "melon":
                    return new Melon();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new RandomFood();
            }
        }
    }
}
