using System;
using System.Collections.Generic;
using System.Text;

namespace P06.StrategyPattern
{
    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
