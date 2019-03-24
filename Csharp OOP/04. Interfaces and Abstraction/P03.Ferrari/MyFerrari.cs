using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Ferrari
{
    public class MyFerrari : IMoveable
    {
        public MyFerrari(string name)
        {
            this.Name = name;
        }

        public string Name { get;private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"488-Spider/{this.Brakes()}/{this.Gas()}/{this.Name}";
        }
    }
}
