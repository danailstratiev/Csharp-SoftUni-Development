using System;
using System.Collections.Generic;
using System.Text;

namespace P05.KingsGambitExtended
{
    public class Footman : Person
    {
        public Footman(string name) : base(name)
        {
            Lifesleft = 2;
        }

        public override int Lifesleft { get; set; }

        public override string ProtectTheKing()
        {
            return $"Footman {this.Name} is panicking!";
        }
    }
}
