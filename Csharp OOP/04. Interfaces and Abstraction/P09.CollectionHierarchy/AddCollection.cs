using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P09.CollectionHierarchy
{
    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            this.AddStack = new Stack<string>();
        }

        public Stack<string> AddStack { get;private set; }

        public string Add(string[] items)
        {
            var counter = 0;
            var addIndexes = new List<int>();
            foreach (var item in items)
            {
                this.AddStack.Push(item);
                addIndexes.Add(counter);
                counter++;
            }

            return string.Join(" ", addIndexes);
        }
    }
}
