namespace P03.WildFarm.Animals.Mammals
{
    using P03.WildFarm.Foods;
    using System;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            var currentFood = food.GetType().Name;

            if (currentFood == "Vegetable" || currentFood == "Fruit")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += (food.Quantity * 0.10);
            }
            else
            {
                var inedibleMessage = this.InEdible(food);

                throw new ArgumentException(inedibleMessage);                
            }
        }
    }
}
