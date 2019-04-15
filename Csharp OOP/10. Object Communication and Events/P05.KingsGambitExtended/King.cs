using System;
using System.Collections.Generic;
using System.Text;

namespace P05.KingsGambitExtended
{
    public class King : Person
    {
        public King(string name) : base(name)
        {
            this.Lifesleft = int.MaxValue;
        }

        public override int Lifesleft { get => base.Lifesleft; set => base.Lifesleft = value; }

        public override string ProtectTheKing()
        {
            return $"King {this.Name} is under attack!";
        }
    }
}
