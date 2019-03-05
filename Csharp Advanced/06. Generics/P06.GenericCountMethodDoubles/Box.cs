using System;
using System.Collections.Generic;
using System.Text;

namespace P06.GenericCountMethodDoubles
{
    public class Box <T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; private set; }

        public void Add(T item)
        {
            Items.Add(item);
        }
    }
}
