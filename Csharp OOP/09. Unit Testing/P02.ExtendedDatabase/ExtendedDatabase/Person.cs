using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedDatabase
{
    public class Person
    {
        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; private set; }

        public int Id { get; private set; }
    }
}
