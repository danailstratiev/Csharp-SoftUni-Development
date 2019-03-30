namespace P03.WildFarm.Animals.Birds
{
    using P03.WildFarm.Foods;
    using System;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += (food.Quantity * 0.35);
        }
    }
}
