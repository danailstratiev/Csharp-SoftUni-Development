namespace P03.WildFarm.Animals.Birds
{
    using P03.WildFarm.Foods;
    using System;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            var currentFood = food.GetType().Name;

            if (currentFood == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += (food.Quantity * 0.25);
            }
            else
            {
                var inedibleMessage = this.InEdible(food);

                throw new ArgumentException(inedibleMessage);
                
            }
        }
    }
}
