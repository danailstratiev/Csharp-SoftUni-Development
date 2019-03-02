using System;
using System.Collections.Generic;
using System.Text;

namespace P02._2.GenericBoxOfInteger
{
   public class Box <T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public override string ToString()
        {
            return $"{this.item.GetType()}: {item}"; 
        }
    }
}
