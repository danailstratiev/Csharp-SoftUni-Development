using System;

namespace P03.WildFarm.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get;private set; }
    }
}
