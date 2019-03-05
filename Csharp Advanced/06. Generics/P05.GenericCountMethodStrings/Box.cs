using System;
using System.Collections.Generic;
using System.Text;

namespace P05.GenericCountMethodStrings
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }

        public List<T> Items { get; private set; }

        public void Add (T item)
        {
            this.Items.Add(item);
        }        
    }
}
