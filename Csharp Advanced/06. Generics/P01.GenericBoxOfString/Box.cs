using System;
using System.Collections.Generic;
using System.Text;

namespace P01.GenericBoxOfString
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
            return $"{item.GetType()}: {item}";         
        }
    }
}
