using System;

namespace P03.WildFarm.Foods
{
    public class Vegetable : Food
    {
        public Vegetable(int quantity) 
            : base(quantity)
        {
        }

        public static implicit operator Vegetable(Fruit v)
        {
            throw new NotImplementedException();
        }
    }
}
