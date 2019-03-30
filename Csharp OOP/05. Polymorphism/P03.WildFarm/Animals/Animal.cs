namespace P03.WildFarm.Animals
{
    using P03.WildFarm.Foods;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();
        
        public virtual void Eat(Food food)
        {
            
        }

        public string InEdible(Food food)
        {
            return $"{this.GetType().Name} does not eat {food.GetType().Name}!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
