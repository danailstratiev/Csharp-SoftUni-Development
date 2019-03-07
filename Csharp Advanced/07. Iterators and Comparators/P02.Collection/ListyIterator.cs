using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P02.Collection
{
    public class ListyIterator<T> : IEnumerable <T>
    {
        private int index;

        public ListyIterator(List<T> coolList)
        {
            this.coolList = coolList;
            index = 0;
        }

        public List<T> coolList { get; set; }


        public bool Move()
        {
            if (index + 1 < coolList.Count)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (index + 1 < coolList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Print()
        {
            if (coolList.Count == 0)
            {
                throw new IndexOutOfRangeException("Invalid Operation!");
            }
            return coolList[index];
        }

        public string PrintAll()
        {
            if (coolList.Count == 0)
            {
                throw new IndexOutOfRangeException("Invalid Operation!");
            }

            return string.Join(" ", coolList);
        }

        public IEnumerator <T> GetEnumerator()
        {
            foreach (var item in this.coolList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    }
}
