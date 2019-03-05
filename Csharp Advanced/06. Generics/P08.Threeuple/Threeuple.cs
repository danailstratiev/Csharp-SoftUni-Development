using System;
using System.Collections.Generic;
using System.Text;

namespace P08.Threeuple
{
    public class Threeuple <T, K, W>
    {
        private T item1;

        private K item2;

        private W item3;

        public Threeuple(T item1, K item2, W item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
