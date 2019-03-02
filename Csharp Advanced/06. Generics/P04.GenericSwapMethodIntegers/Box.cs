using System;
using System.Collections.Generic;
using System.Text;

namespace P04.GenericSwapMethodIntegers
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
            this.Items.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in this.Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }
    }
}
