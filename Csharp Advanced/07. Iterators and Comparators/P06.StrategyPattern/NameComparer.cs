using System;
using System.Collections.Generic;
using System.Text;

namespace P06.StrategyPattern
{
    public class NameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result != 0)
            {
                return result;
            }
            else
            {
                var firstLetterX = x.Name.ToLower()[0];
                var firstLetterY = y.Name.ToLower()[0];

                return firstLetterX - firstLetterY;
            }
        }
    }
}
