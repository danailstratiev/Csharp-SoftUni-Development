using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit
{
    public class Person : IPerson
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual string ProtectTheKing()
        {
            return null;
        }
    }
}
