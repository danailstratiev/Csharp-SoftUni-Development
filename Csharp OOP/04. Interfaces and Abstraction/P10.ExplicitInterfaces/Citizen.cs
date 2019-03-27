using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P10.ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        public string GetName()
        {
            return "Mr/Ms/Mrs";
        }

        public string GetName(string name)
        {
            return name;
        }

        public override string ToString()
        {
            return this.Name + Environment.NewLine + GetName() + " " + GetName(this.Name);
        }
    }
}
