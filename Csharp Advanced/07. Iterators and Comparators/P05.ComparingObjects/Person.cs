using System;
using System.Collections.Generic;
using System.Text;

namespace P05.ComparingObjects
{
    public class Person : IComparable <Person>
    {
        private string name;

        private int age;

        private string town;

        public Person(string name, int age, string town )
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person other)
        {
            if (this.name != other.name)
            {
                return -1;
            }
            else
            {
                if (this.age != other.age)
                {
                    return -1;
                }
                else
                {
                    if (this.town != other.town)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
