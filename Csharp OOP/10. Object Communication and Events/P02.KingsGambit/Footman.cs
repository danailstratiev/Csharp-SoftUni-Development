using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit
{
    public class Footman : Person
    {
        public Footman(string name) : base(name)
        {
        }

        public override string ProtectTheKing()
        {
            return $"Footman {this.Name} is panicking!";
        }
    }
}
