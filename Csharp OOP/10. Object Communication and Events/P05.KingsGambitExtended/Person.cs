using System;
using System.Collections.Generic;
using System.Text;

namespace P05.KingsGambitExtended
{
    public class Person : IPerson
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual int Lifesleft { get; set; }

        public virtual string ProtectTheKing()
        {
            return null;
        }
    }
}
