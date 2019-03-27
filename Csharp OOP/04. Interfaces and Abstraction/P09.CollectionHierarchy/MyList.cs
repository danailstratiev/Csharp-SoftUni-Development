using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P09.CollectionHierarchy
{
    public class MyList : IAddable, IRemoveable
    {
        public MyList()
        {
            this.CoolList = new List<string>();
        }

        public List<string> CoolList { get; private set; }

        public int Used { get => this.CoolList.Count; }

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
                var firstElement = this.CoolList.First();
                removedElements.Add(firstElement);
                this.CoolList.RemoveAt(0);
            }

            return string.Join(" ", removedElements);
        }
    }
}
