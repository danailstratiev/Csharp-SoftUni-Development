using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedList
{
    public class CoolStack
    {
        private List<object> values;

        public CoolStack()
        {
            this.values = new List<object>();
        }

        public int Count
        {
            get
            {
                return this.values.Count;
            }
        }

        public void Push (object value)
        {
            this.values.Add(value);
        }

        public object Pop ()
        {
            if (this.values.Count == 0)
            {
                throw new InvalidOperationException("Cool stack is empty.");
            }

            var lastIndex = this.values.Count - 1;
            var last = this.values[lastIndex];
            this.values.RemoveAt(lastIndex);
            return last;
        }

        public void ForEach (Action <object> action)
        {
            foreach (var item in values)
            {
                action(item);
            }
        }
    }
}
