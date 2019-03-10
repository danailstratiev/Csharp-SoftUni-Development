using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int CompareTo(Person other)
        {
            var nameResult = this.Name.CompareTo(other.Name);

            if (nameResult == 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return nameResult;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                return this.Name == person.Name && this.Age == person.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
