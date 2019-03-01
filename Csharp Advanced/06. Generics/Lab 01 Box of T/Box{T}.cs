using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_01_Box_of_T
{
   public class Box <T>
    {
        private List<T> values;

        public Box()
        {
            this.values = new List<T>();
        }

        public void Add (T value)
        {
            this.values.Add(value);
        }

        public T Remove (T value)
        {
            var last = values.Last();
            this.values.RemoveAt(values.Count - 1);
            return last;
        }

        public int Count
        {
            get { return this.values.Count; }
        }
    }
}
