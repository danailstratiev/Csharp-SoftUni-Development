namespace P03.WildFarm.Foods
{
    public class FoodFactory
    {
        public Food CreateFood(string[] foodInput)
        {
            var foodName = foodInput[0];
            var foodQuantity = int.Parse(foodInput[1]);
            Food food = null;

            switch (foodName)
            {
                case "Fruit":
                    var fruit = new Fruit(foodQuantity);
                    food = fruit;
                    break;
                case "Meat":
                    var meat = new Meat(foodQuantity);
                    food = meat;
                    break;
                case "Seeds":
                    var seeds = new Seeds(foodQuantity);
                    food = seeds;
                    break;
                case "Vegetable":
                    var vegetable = new Vegetable(foodQuantity);
                    food = vegetable;
                    break;
            }

            return food;
        }
    }
}
