namespace SimpleSnake.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int foodPoints = 3;

        public FoodHash(Wall wall) 
            : base(wall, foodSymbol, foodPoints)
        {
        }
    }
}
