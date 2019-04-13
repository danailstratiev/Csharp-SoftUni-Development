using System;
using System.Collections.Generic;
using System.Text;

namespace P02.KingsGambit
{
    public class King : Person
    {
        public King(string name) : base(name)
        {
        }

        public override string ProtectTheKing()
        {
            return $"King {this.Name} is under attack!";
        }
    }
}
