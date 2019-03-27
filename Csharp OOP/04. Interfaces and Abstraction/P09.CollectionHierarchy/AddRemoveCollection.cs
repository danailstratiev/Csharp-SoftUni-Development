using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P09.CollectionHierarchy
{
    public class AddRemoveCollection : IAddable, IRemoveable
    {
        public AddRemoveCollection()
        {
            this.CoolList = new List<string>();
        }

        public List<string> CoolList { get; private set; }

        public string Add(string[] items)
        {
            var zeroIndex = 0;
            var numberOfAdditions = new List<int>();

            foreach (var item in items)
            {
                this.CoolList.Insert(0, item);
                numberOfAdditions.Add(zeroIndex);
            }

            return string.Join(" ", numberOfAdditions);
        }

        public string Remove(int n)
        {
            var removedElements = new List<String>();

            for (int i = 0; i < n; i++)
            {
                var lastElement = this.CoolList.Last();
                removedElements.Add(lastElement);
                var index = this.CoolList.IndexOf(lastElement);
                this.CoolList.RemoveAt(index);
            }

            return string.Join(" ", removedElements);
        }
    }
}
