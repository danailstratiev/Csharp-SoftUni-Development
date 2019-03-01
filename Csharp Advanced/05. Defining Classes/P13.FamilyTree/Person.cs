using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace P13.FamilyTree
{
    public class Person
    {
        public Person(string data)
        {
            if (int.TryParse(data[0].ToString(), out _))
            {
                this.Birthdate = data;
            }
            else
            {
                this.Name = data;
            }
        }

        public Person(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthdate}";
        }
    }
}
