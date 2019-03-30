namespace P03.WildFarm.Animals.Mammals.Felines
{
    using P03.WildFarm.Foods;
    using System;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void Eat(Food food)
        {
            var currentFood = food.GetType().Name;

            if (currentFood == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += (food.Quantity * 1.00);
            }
            else
            {
                var inedibleMessage = this.InEdible(food);

                throw new ArgumentException(inedibleMessage);                
            }
        }
    }
}
