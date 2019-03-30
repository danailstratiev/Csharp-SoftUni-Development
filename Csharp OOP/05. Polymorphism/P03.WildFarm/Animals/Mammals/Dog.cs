namespace P03.WildFarm.Animals.Mammals
{
    using P03.WildFarm.Foods;
    using System;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void Eat(Food food)
        {
            var currentFood = food.GetType().Name;

            if (currentFood == "Meat")
            {
                this.FoodEaten += food.Quantity;
                this.Weight += (food.Quantity * 0.40);
            }
            else
            {
                var inedibleMessage = this.InEdible(food);

                throw new ArgumentException(inedibleMessage);                
            }
        }
    }
}
